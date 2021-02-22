using System;
using System.Collections.Generic;
using System.Linq;

namespace Codility_Console.BinaryGap
{
    public class BinaryGapSolutionV2 : ISolution
    {
        string binaryData = string.Empty;
        // List<int> gaps;

        public BinaryGapSolutionV2()
        {
            binaryData = string.Empty;
        }

        public void Run()
        {
            int inputNumber;
            do
            {
                inputNumber = GetInput();
                if (inputNumber <= 0) return;
                var output = RunSolution(inputNumber);
                Console.WriteLine($"The Longest Binary Gap for {inputNumber}({binaryData}) is {output}");
            } while (inputNumber != 0);
        }

        int GetInput()
        {
            Console.Write("Enter a number to get the Longest binary Gap (Enter 0 to exit): ");
            var data = Console.ReadLine();
            _ = int.TryParse(data, out int input);
            return input;
        }

        int RunSolution(int N)
        {
            int gap = 0;

            // get the binary value for the given N
            binaryData = Convert.ToString(N, 2);

            // get the longest binary gap
            gap = FindLongestBinaryGap();

            return gap;
        }

        int FindLongestBinaryGap()
        {
            var allOnes = binaryData.ToList().FindAll(ones => ones == '1');
            if (allOnes.Count < 2 || allOnes.Count == binaryData.Length) return 0;

            int gapCtr = 0;
            List<int> gaps = new List<int>();
            for (int loop = 0; loop < binaryData.Length; loop++)
            {
                var x = binaryData[loop];
                if (x == '1')
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
