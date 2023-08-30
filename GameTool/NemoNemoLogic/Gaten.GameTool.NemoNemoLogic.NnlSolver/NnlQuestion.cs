using System;
using System.Collections.Generic;
using System.Linq;

namespace Gaten.GameTool.NemoNemoLogic.NnlSolver
{
    public class NnlQuestion
    {
        public int Width
        {
            get; private set;
        }

        public int Height
        {
            get; private set;
        }

        private int[][] colNumbers;
        private int[][] rowNumbers;

        public int[] GetColNumbers(int index)
        {
            return colNumbers[index];
        }

        public int[] GetRowNumbers(int index)
        {
            return rowNumbers[index];
        }
        void ThrowIfContainLessThanOne(int[] numbers)
        {
            foreach (int number in numbers)
                if (number < 1)
                {
                    throw new ArgumentException("invalid number");
                }
        }

        public void SetColNumbers(int index, int[] numbers)
        {
            ThrowIfContainLessThanOne(numbers);
            colNumbers[index] = numbers;
        }

        public void SetRowNumbers(int index, int[] numbers)
        {
            ThrowIfContainLessThanOne(numbers);
            rowNumbers[index] = numbers;
        }

        public NnlQuestion(int width, int height)
        {
            colNumbers = new int[Width = width][];
            rowNumbers = new int[Height = height][];
        }

        public NnlQuestion() :
            this("0\n\n0\n")
        { }

        int[] StringToNumbers(string line)
        {
            string[] split = line.Trim().Split(new char[] { ' ', ',' });
            if (split.Length == 0) throw new ArgumentException();
            int[] numbers;
            try
            {
                numbers = split.Where(x => !x.Equals("")).Select(Int32.Parse).ToArray();
            }
            catch (FormatException)
            {
                throw new ArgumentException();
            }
            if (numbers.Length == 1 && numbers[0] == 0) return new int[0];
            if (numbers.Any((x) => x < 1)) throw new ArgumentException();
            return numbers;
        }

        public NnlQuestion(string text)
        {
            LinkedList<int[]> col = new LinkedList<int[]>();
            LinkedList<int[]> row = new LinkedList<int[]>();
            System.IO.StringReader reader = new System.IO.StringReader(text);
            string line;
            while (true)
            {
                line = reader.ReadLine();
                if (line == null || line.Equals("")) break;
                col.AddLast(StringToNumbers(line));
            }
            while (true)
            {
                line = reader.ReadLine();
                if (line == null || line.Equals("")) break;
                row.AddLast(StringToNumbers(line));
            }
            if (!col.Any() || !row.Any()) throw new ArgumentException();
            colNumbers = col.ToArray();
            rowNumbers = row.ToArray();
            Width = colNumbers.Length;
            Height = rowNumbers.Length;
        }

        public NnlQuestion(bool[,] pixels)
        {
            Width = pixels.GetLength(0);
            Height = pixels.GetLength(1);
            if (Width < 1 || Height < 1)
            {
                throw new ArgumentException();
            }
            colNumbers = new int[Width][];
            rowNumbers = new int[Height][];
            for (int i = 0; i < Width; ++i)
            {
                LinkedList<int> numbers = new LinkedList<int>();
                int currentNumber = 0;
                for (int j = 0; j < Height; ++j)
                {
                    if (pixels[i, j])
                    {
                        ++currentNumber;
                    }
                    else
                    {
                        if (currentNumber != 0)
                        {
                            numbers.AddLast(currentNumber);
                            currentNumber = 0;
                        }
                    }
                }
                if (currentNumber != 0)
                {
                    numbers.AddLast(currentNumber);
                }
                colNumbers[i] = numbers.ToArray();
            }
            for (int i = 0; i < Height; ++i)
            {
                LinkedList<int> numbers = new LinkedList<int>();
                int currentNumber = 0;
                for (int j = 0; j < Width; ++j)
                {
                    if (pixels[j, i])
                    {
                        ++currentNumber;
                    }
                    else
                    {
                        if (currentNumber != 0)
                        {
                            numbers.AddLast(currentNumber);
                            currentNumber = 0;
                        }
                    }
                }
                if (currentNumber != 0)
                {
                    numbers.AddLast(currentNumber);
                }
                rowNumbers[i] = numbers.ToArray();
            }
        }

        public bool VerifySolution(bool[,] pixels)
        {
            if (pixels.GetLength(0) != Width || pixels.GetLength(1) != Height) return false;
            for (int i = 0; i < Width; ++i)
            {
                var numbers = new LinkedList<int>();
                int cur = 0;
                for (int j = 0; j < Height; ++j)
                {
                    if (!pixels[i, j] && cur != 0)
                    {
                        numbers.AddLast(cur);
                        cur = 0;
                    }
                    else if (pixels[i, j])
                    {
                        ++cur;
                    }
                }
                if (cur != 0) numbers.AddLast(cur);

                var numbersA = numbers.ToArray();
                if (numbersA.Length != colNumbers[i].Length) return false;
                for (int j = 0; j < numbersA.Length; ++j)
                {
                    if (numbersA[j] != colNumbers[i][j]) return false;
                }
            }

            for (int i = 0; i < Height; ++i)
            {
                var numbers = new LinkedList<int>();
                int cur = 0;
                for (int j = 0; j < Width; ++j)
                {
                    if (!pixels[j, i] && cur != 0)
                    {
                        numbers.AddLast(cur);
                        cur = 0;
                    }
                    else if (pixels[j, i])
                    {
                        ++cur;
                    }
                }
                if (cur != 0) numbers.AddLast(cur);

                var numbersA = numbers.ToArray();
                if (numbersA.Length != rowNumbers[i].Length) return false;
                for (int j = 0; j < numbersA.Length; ++j)
                {
                    if (numbersA[j] != rowNumbers[i][j]) return false;
                }
            }

            return true;
        }
    }
}
