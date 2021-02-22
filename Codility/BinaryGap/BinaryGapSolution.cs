using System;
using System.Collections.Generic;
using System.Linq;

namespace Codility_Console.BinaryGap
{
    class BinaryGapSolution : ISolution
    {
        List<int> binaryData;

        public BinaryGapSolution()
        {
            binaryData = new List<int>();
        }

        public void Run()
        {
            Console.WriteLine("---- Codility Practice demo for BINARYGAP ----");
            Console.Write("Enter a number to find a longest binary gap: ");
            var data = Console.ReadLine();
            _ = int.TryParse(data, out int input);
            var result = EvaluateSolution(input);
            Console.WriteLine($"The Longest BinaryGap for {input} is {result}");
        }

        int EvaluateSolution(int N)
        {
            GetBinaryData(N);

            // reverse the binaryData array to get the actual Binary value of the given number N
            binaryData.Reverse();
            Console.WriteLine($"{string.Join(string.Empty, binaryData)}");

            // try to check the binary gap
            var result = FindLongestBinaryGap();

            return result;
        }

        void GetBinaryData(int N)
        {
            if (N >= 1)
            {
                var x = N % 2;
                binaryData.Add(x);
                N = N / 2;
                GetBinaryData(N);
            }

            if (N == 0)
                return;
        }

        int FindLongestBinaryGap()
        {
            // use the local variable rather than global, so it would get initialized and counted for.
            // previous version had this as global variable and this list was getting appended with the values from previous executions. That was causing issues.
            List<int> gaps = new List<int>();
            int gapCtr = 0;

            var allOnes = binaryData.FindAll(ones => ones == 1);
            if (allOnes.Count < 2 || allOnes.Count == binaryData.Count) return 0;

            for (int loop = 0; loop < binaryData.Count; loop++)
            {
                var x = binaryData[loop];
                if (x == 1)
                {
                    gaps.Add(gapCtr);
                    gapCtr = 0;
                }
                else
                    gapCtr++;
            }
            return gaps.Max();
        }
    }
}
