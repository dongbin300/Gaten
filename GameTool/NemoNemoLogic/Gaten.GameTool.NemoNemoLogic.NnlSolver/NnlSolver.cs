using System;
using System.Collections.Generic;
using System.Linq;

namespace Gaten.GameTool.NemoNemoLogic.NnlSolver
{
    public enum PixelStateEnum
    {
        UNKNOWN,
        ON,
        OFF
    }

    public class NnlSolver
    {
        public class StepTouch
        {
            public int colIndex, rowIndex;
            public bool on;
        }

        public class StepMove
        {
            public bool moveToCol;
            public int index;
        }

        public PixelStateEnum[,] pixelStates;
        delegate void GetSliceDel(int rowIndex, out BitArray on, out BitArray off);

        public static bool[,] ConvertToPureSolution(PixelStateEnum[,] pixels)
        {
            bool[,] ret = new bool[pixels.GetLength(0), pixels.GetLength(1)];
            for (int x = 0; x < pixels.GetLength(0); ++x)
            {
                for (int y = 0; y < pixels.GetLength(1); ++y)
                {
                    switch (pixels[x, y])
                    {
                        case PixelStateEnum.ON:
                            ret[x, y] = true;
                            break;
                        case PixelStateEnum.OFF:
                            ret[x, y] = false;
                            break;
                        default:
                            throw new ArgumentException();
                    }
                }
            }
            return ret;
        }

        void GetColSlice(int colIndex, out BitArray on, out BitArray off)
        {
            int size = pixelStates.GetLength(1);
            on = new BitArray(size);
            off = new BitArray(size);
            for (int i = 0; i < size; ++i)
            {
                switch (pixelStates[colIndex, i])
                {
                    case PixelStateEnum.ON:
                        on.Set(i);
                        break;
                    case PixelStateEnum.OFF:
                        off.Set(i);
                        break;
                }
            }
        }

        void GetRowSlice(int rowIndex, out BitArray on, out BitArray off)
        {
            int size = pixelStates.GetLength(0);
            on = new BitArray(size);
            off = new BitArray(size);
            for (int i = 0; i < size; ++i)
            {
                switch (pixelStates[i, rowIndex])
                {
                    case PixelStateEnum.ON:
                        on.Set(i);
                        break;
                    case PixelStateEnum.OFF:
                        off.Set(i);
                        break;
                }
            }
        }

        public enum ResultEnum
        {
            SOLVING,
            CONTRADICTORY,
            INDEFINITE,
            FINISHED
        }

        public ResultEnum Result
        {
            get; private set;
        }

        public bool ContradictoryInCols
        {
            get; private set;
        }

        public int ContradictoryIndex
        {
            get; private set;
        }

        public int FirstUnknownColIndex
        {
            get; private set;
        }

        public int FirstUnknownRowIndex
        {
            get; private set;
        }

        static IEnumerable<int[]>
            EnumNumberSpaces(int[] numbers, int length)
        {
            int[] spaces = new int[numbers.Length];
            length -= numbers.Sum();
            if (length < numbers.Length - 1) yield break;
            for (int i = 1; i < numbers.Length; ++i)
            {
                spaces[i] = 1;
            }
            while (true)
            {
                yield return (int[])spaces.Clone();
                int nextAdd = numbers.Length - 1;
                while (true)
                {
                    ++spaces[nextAdd];
                    if (length >= spaces.Sum()) break;
                    spaces[nextAdd] = 1;
                    --nextAdd;
                    if (nextAdd == -1) yield break;
                }
            }
        }

        static LinkedList<BitArray> GetAllCandidates(int[] numbers, int length)
        {
            LinkedList<BitArray> result = new LinkedList<BitArray>();
            if (numbers.Length == 0)
            {
                result.AddLast(new BitArray(length));
            }
            else
            {

                foreach (int[] spaces in EnumNumberSpaces(numbers, length))
                {
                    BitArray can = new BitArray(length);
                    int pos = 0;
                    for (int i = 0; i < spaces.Length; ++i)
                    {
                        pos += spaces[i];
                        for (int j = 0; j < numbers[i]; ++j)
                        {
                            can.Set(pos++);
                        }
                    }
                    result.AddLast(can);
                }
            }
            return result;
        }

        private bool usePresetCandidates = false;
        private LinkedList<BitArray>[][] candidates;

        private static LinkedList<BitArray>[][] GetInitCandidatesSet(NnlQuestion question)
        {
            var candidates = new LinkedList<BitArray>[2][]{
                    new LinkedList<BitArray>[question.Width],
                    new LinkedList<BitArray>[question.Height]
                };
            for (int coli = 0; coli < question.Width; ++coli)
            {
                candidates[0][coli] = GetAllCandidates(question.GetColNumbers(coli), question.Height);
            }
            for (int rowi = 0; rowi < question.Height; ++rowi)
            {
                candidates[1][rowi] = GetAllCandidates(question.GetRowNumbers(rowi), question.Width);
            }
            return candidates;
        }

        private static LinkedList<BitArray>[][] CloneCandidatesSet(LinkedList<BitArray>[][] c)
        {
            var candidates = new LinkedList<BitArray>[2][]{
                    new LinkedList<BitArray>[c[0].Length],
                    new LinkedList<BitArray>[c[1].Length]
                };
            for (int i = 0; i < c[0].Length; ++i)
            {
                candidates[0][i] = new LinkedList<BitArray>();
                foreach (var b in c[0][i]) candidates[0][i].AddLast(b);
            }
            for (int i = 0; i < c[1].Length; ++i)
            {
                candidates[1][i] = new LinkedList<BitArray>();
                foreach (var b in c[1][i]) candidates[1][i].AddLast(b);
            }
            return candidates;
        }

        public IEnumerable<object> SolveByStep(NnlQuestion question)
        {
            Result = ResultEnum.SOLVING;

            if (pixelStates == null)
                pixelStates = new PixelStateEnum[question.Width, question.Height];
            if (pixelStates.GetLength(0) != question.Width ||
                pixelStates.GetLength(1) != question.Height)
            {
                throw new InvalidOperationException("The initial state of pixelStates is invalid");
            }
            if (!usePresetCandidates)
            {
                candidates = GetInitCandidatesSet(question);
            }

            int width = question.Width;
            int height = question.Height;
            int hw;
            var GetSlice = new GetSliceDel[] {
                GetColSlice,GetRowSlice
            };
            while (true)
            {
                bool worked = false;
                for (int flip = 0; flip < 2; ++flip, hw = width, width = height, height = hw)
                {
                    for (int index = 0; index < width; ++index)
                    {
                        yield return new StepMove
                        {
                            moveToCol = flip == 0,
                            index = index
                        };

                        BitArray onSlice, offSlice;
                        GetSlice[flip](index, out onSlice, out offSlice);

                        var node = candidates[flip][index].First;
                        while (node != null)
                        {
                            var next = node.Next;
                            if (!node.Value.AndIsZero(offSlice) || !node.Value.NotAndIsZero(onSlice))
                            {
                                candidates[flip][index].Remove(node);
                            }
                            node = next;
                        }

                        if (!candidates[flip][index].Any())
                        {
                            Result = ResultEnum.CONTRADICTORY;
                            ContradictoryInCols = flip == 0;
                            ContradictoryIndex = index;
                            yield break;
                        }

                        onSlice.Not();
                        offSlice.Not();
                        foreach (BitArray bits in candidates[flip][index])
                        {
                            onSlice.And(bits);
                            offSlice.AndNot(bits);
                        }
                        for (int i = 0; i < height; ++i)
                        {
                            int x, y;
                            if (flip == 0)
                            {
                                x = index;
                                y = i;
                            }
                            else
                            {
                                x = i;
                                y = index;
                            }
                            if (onSlice.Test(i))
                            {
                                worked = true;
                                pixelStates[x, y] = PixelStateEnum.ON;
                                yield return new StepTouch
                                {
                                    colIndex = x,
                                    rowIndex = y,
                                    on = true
                                };
                            }
                            else if (offSlice.Test(i))
                            {
                                worked = true;
                                pixelStates[x, y] = PixelStateEnum.OFF;
                                yield return new StepTouch
                                {
                                    colIndex = x,
                                    rowIndex = y,
                                    on = false
                                };
                            }
                        }

                    }
                }

                if (worked == false) break;

            }

            for (int ci = 0; ci < question.Width; ++ci)
                for (int ri = 0; ri < question.Height; ++ri)
                {
                    if (pixelStates[ci, ri] == PixelStateEnum.UNKNOWN)
                    {
                        FirstUnknownColIndex = ci;
                        FirstUnknownRowIndex = ri;
                        Result = ResultEnum.INDEFINITE;
                        goto tag_indefinite;
                    }
                }
            Result = ResultEnum.FINISHED;
            tag_indefinite:


            yield break;
        }

        public ResultEnum Solve(NnlQuestion question)
        {
            foreach (var step in SolveByStep(question)) ;
            return Result;
        }

        public static IEnumerable<bool[,]> SolveBySearching(NnlQuestion question)
        {
            var works = new LinkedList<PixelStateEnum[,]>();
            var candidatesList = new LinkedList<LinkedList<BitArray>[][]>();
            works.AddFirst(new PixelStateEnum[question.Width, question.Height]);
            candidatesList.AddFirst(GetInitCandidatesSet(question));
            var solver = new NnlSolver
            {
                usePresetCandidates = true
            };
            while (works.Any())
            {
                solver.pixelStates = works.First();
                solver.candidates = candidatesList.First();
                works.RemoveFirst();
                candidatesList.RemoveFirst();
                switch (solver.Solve(question))
                {
                    case ResultEnum.FINISHED:
                        yield return ConvertToPureSolution(solver.pixelStates);
                        break;
                    case ResultEnum.INDEFINITE:
                        PixelStateEnum[,] a, b;
                        a = solver.pixelStates;
                        b = (PixelStateEnum[,])a.Clone();
                        LinkedList<BitArray>[][] cloneCan;
                        cloneCan = CloneCandidatesSet(solver.candidates);
                        a[solver.FirstUnknownColIndex, solver.FirstUnknownRowIndex]
                            = PixelStateEnum.OFF;
                        b[solver.FirstUnknownColIndex, solver.FirstUnknownRowIndex]
                            = PixelStateEnum.ON;
                        works.AddFirst(a);
                        works.AddFirst(b);
                        candidatesList.AddFirst(solver.candidates);
                        candidatesList.AddFirst(cloneCan);
                        break;
                }
            }
            yield break;
        }
    }
}
