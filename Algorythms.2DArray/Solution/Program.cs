using System;

namespace Solution
{
    class Solution
    {
        private const short MatrixSize = 6;

        private static readonly short[,] Start =
        {
            {0, 0}, {1, 0}, {2, 0},
                    {1, 1},
            {2, 0}, {2, 1}, {2, 2}
        };

        static void Main(string[] args)
        {
            short[,] data = GetMatrix(Console.ReadLine);

            int result = CountMaxHourglassSum(data);

            Console.Write(result);
        }

        public static int CountMaxHourglassSum(short[,] data)
        {
            int result = -1;

            if (data != null && data.GetLength(0) == MatrixSize && data.GetLength(1) == MatrixSize)
            {
                Figure f = new Figure(Start, MatrixSize);

                result = f.CurrentSum;

                while (f.Move())
                {
                    if (result < f.CurrentSum)
                    {
                        result = f.CurrentSum;
                    }
                }
            }

            return result;
        }

        private class Figure
        {
            private readonly short[,] currentPosition;

            private readonly short[,] newPosition;

            private readonly short matrixSize;

            protected internal Figure(short[,] currentPosition, short matrixSize)
            {
                this.currentPosition = currentPosition;

                newPosition = (short[,]) currentPosition.Clone();

                this.matrixSize = matrixSize;

                this.CurrentSum = CountSum();
            }

            internal int CurrentSum { get; set; }

            internal bool Move()
            {
                return false;
            }

            private int CountSum()
            {
                throw new NotImplementedException();
            }
        }

        public static short[,] GetMatrix(Func<string> readFunc)
        {
            short[,] data = new short[MatrixSize, MatrixSize];

            for (short lineNumber = 0; lineNumber < MatrixSize; lineNumber++)
            {
                string newLine = readFunc();

                if (!string.IsNullOrEmpty(newLine))
                {
                    newLine = newLine.Trim();

                    string[] parts = newLine.Split(' ');

                    if (parts.Length < MatrixSize)
                    {
                        Console.WriteLine("Tool long row: {0}", newLine);

                        return data;
                    }

                    TryFillMatrixLine(parts, data, lineNumber);
                }
            }
            return data;
        }

        private static void TryFillMatrixLine(string[] parts, short[,] data, int lineNumber)
        {
            for (short digitIndex = 0; digitIndex < MatrixSize; digitIndex++)
            {
                string part = parts[digitIndex];
                short nextNumber;

                var isParsed = short.TryParse(part, out nextNumber);

                if (isParsed)
                {
                    data[digitIndex, lineNumber] = nextNumber;
                }
                else
                {
                    Console.WriteLine("Not a number: {0}", part);
                }
            }
        }
    }
}