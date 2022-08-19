using Gaten.Net.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Gaten.GameTool.NemoNemoLogic.NnlSolver
{
    internal class NnlProblem
    {
        /// <summary>
        /// Width of board
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// height of board
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Horizontal hints and empties
        /// </summary>
        public List<NnlLine> Horizontal { get; }

        /// <summary>
        /// Vertical hints and empties
        /// </summary>
        public List<NnlLine> Vertical { get; }

        public NnlProblem()
        {
            Horizontal = new();
            Vertical = new();
        }

        public NnlProblem(int width, int height, List<NnlLine> horizontal, List<NnlLine> vertical)
        {
            Width = width;
            Height = height;
            Horizontal = horizontal;
            Vertical = vertical;
        }

        /// <summary>
        /// Solve a NNL problem
        /// </summary>
        /// <returns></returns>
        public NnlProblemResult Solve()
        {
            var result = new NnlProblemResult();

            // 1. 라인 별로 모든 경우의 수 구하기
            foreach (var line in Horizontal)
            {
                GetAllLineCases(line, Width);
            }

            // 2. 보드 기준으로 라인의 모든 경우의 수 구하기
            var boards = GetAllBoardCases(Horizontal, Height);

            // 3. 나올 수 있는 모든 보드를 세로 라인으로 검증 후 필터링
            var answerBoards = VerifyBoard(boards);

            result.Answer = answerBoards;
            return result;
        }

        /// <summary>
        /// Filter all boards
        /// </summary>
        /// <param name="boards"></param>
        /// <returns></returns>
        private List<NnlBoard> VerifyBoard(List<NnlBoard> boards)
        {
            var result = new List<NnlBoard>();
            bool fail;
            foreach (var board in boards)
            {
                fail = false;
                for (int i = 0; i < Vertical.Count; i++)
                {
                    if (!IsValid(Vertical[i].Hint, board.Data.GetColumn(i).ToList()))
                    {
                        fail = true;
                        break;
                    }
                }
                if (!fail)
                {
                    result.Add(board);
                }
            }

            return result;
        }

        /// <summary>
        /// Draw a line by horizontal hint and empty
        /// </summary>
        /// <param name="board"></param>
        /// <param name="lineNumber"></param>
        /// <param name="hint"></param>
        /// <param name="empty"></param>
        private void DrawLine(NnlBoard board, int lineNumber, List<int> hint, List<int> empty)
        {
            var result = new List<bool>();
            for (int i = 0; i < hint.Count; i++)
            {
                result.AddRange(Enumerable.Repeat(false, empty[i]));
                result.AddRange(Enumerable.Repeat(true, hint[i]));
            }
            result.AddRange(Enumerable.Repeat(false, empty[^1]));

            for (int i = 0; i < board.Data.GetLength(0); i++)
            {
                board.Data[lineNumber, i] = result[i];
            }
        }

        /// <summary>
        /// Draw a board by horizontal lines
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="hLine"></param>
        /// <returns></returns>
        private NnlBoard DrawBoard(int width, int height, List<NnlLine> hLine)
        {
            var board = new NnlBoard(width, height);
            for(int i = 0; i < height; i++)
            {
                DrawLine(board, i, hLine[i].Hint, hLine[i].SelectedEmpty);
            }
            return board;
        }

        /// <summary>
        /// Check valid data
        /// </summary>
        /// <param name="hint"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private bool IsValid(List<int> hint, List<bool> data)
        {
            bool on = false;
            int c = 0;
            var inspect = new List<int>();
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i])
                {
                    on = true;
                    c++;
                }
                else
                {
                    if (on)
                    {
                        inspect.Add(c);
                        c = 0;
                    }
                    on = false;
                }
            }
            if (on)
            {
                inspect.Add(c);
            }

            return hint.SequenceEqual(inspect);
        }

        /// <summary>
        /// The Method that make all line cases to be happen
        /// </summary>
        /// <param name="line"></param>
        /// <param name="length">Rectangle count</param>
        private void GetAllLineCases(NnlLine line, int length)
        {
            if (line.Hint[0] == 0)
            {
                line.EmptyCases.Add(new List<int>() { length });
                return;
            }

            var emptyLength = length - line.Hint.Sum();
            var emptyBlockCount = line.Hint.Count + 1;
            var caseCount = emptyLength - emptyBlockCount + 3;
            var temp = new int[emptyBlockCount];
            Array.Fill(temp, caseCount);
            var counts = temp.ToList();
            YieldCombination(line.EmptyCases, new List<int>(), counts, counts.Count - 1, emptyLength);
            foreach(var item in line.EmptyCases)
            {
                item[0]--;
                item[^1]--;
            }
        }

        /// <summary>
        /// The Method that make all board cases to be happen
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="length">Line count</param>
        /// <returns></returns>
        private List<NnlBoard> GetAllBoardCases(List<NnlLine> lines, int length)
        {
            var result = new List<NnlBoard>();

            var emptyCaseCounts = lines.Select(x => x.EmptyCases.Count);
            var indexCollection = new List<List<int>>();
            YieldLineCombination(indexCollection, new List<int>(), emptyCaseCounts.ToList(), emptyCaseCounts.Count() - 1);

            foreach(var index in indexCollection)
            {
                for(int i = 0; i < length; i++)
                {
                    lines[i].SelectedIndex = index[i];
                }

                result.Add(DrawBoard(Width, Height, lines));
            }

            return result;
        }

        /// <summary>
        /// The Method that help to yield empty combination by hint
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="value"></param>
        /// <param name="counts"></param>
        /// <param name="left"></param>
        /// <param name="emptyLength"></param>
        private void YieldCombination(List<List<int>> collection, List<int> value, List<int> counts, int left, int emptyLength)
        {
            for (var i = 1; i <= counts.First(); i++)
            {
                var list = value.ToList();
                list.Add(i);

                if (left == 0)
                {
                    if(list.Sum() == emptyLength + 2)
                    {
                        collection.Add(list.ToList());
                    }
                }
                else
                {
                    YieldCombination(collection, list, counts.Skip(1).ToList(), left - 1, emptyLength);
                }
            }
        }

        /// <summary>
        /// The Method that help to yield NNL board combination by NNL line
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="value"></param>
        /// <param name="counts"></param>
        /// <param name="left"></param>
        private void YieldLineCombination(List<List<int>> collection, List<int> value, List<int> counts, int left)
        {
            for (var i = 0; i < counts.First(); i++)
            {
                var list = value.ToList();
                list.Add(i);

                if (left == 0)
                {
                    collection.Add(list.ToList());
                }
                else
                {
                    YieldLineCombination(collection, list, counts.Skip(1).ToList(), left - 1);
                }
            }
        }
    }
}
