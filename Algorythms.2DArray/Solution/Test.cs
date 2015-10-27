using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace Solution
{
    [TestFixture]
    public class Test
    {
        [TestCase("Solution.62.txt", 62)]
        public void Check(string testFileResourceName, int expectedResult)
        {
            var data = GetData(testFileResourceName);

            List<string>.Enumerator enumerator = data.GetEnumerator();

            Func<string> dataFunc = () =>
            {
                enumerator.MoveNext();

                string result = enumerator.Current;

                return result;
            };

            short[,] matrix = Solution.GetMatrix(dataFunc);

            int maxHourglassSum = Solution.CountMaxHourglassSum(matrix);

            Assert.AreEqual(expectedResult, maxHourglassSum);
        }

        private static List<string> GetData(string path)
        {
            List<string> data = new List<string>();
            using (Stream stream = typeof(Test).Assembly.GetManifestResourceStream(path))
            {
                if (stream != null)
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        while (!reader.EndOfStream)
                        {
                            string newLine = reader.ReadLine();

                            data.Add(newLine);
                        }
                    }
                }
            }
            return data;
        }
    }
}
