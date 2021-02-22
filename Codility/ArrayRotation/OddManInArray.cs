using System;
using System.Linq;

namespace Codility_Console.ArrayRotation
{
    public class OddManInArray : ISolution
    {
        public void Run()
        {
            var input = new int[] { 9, 3, 9, 3, 9, 7, 9, 6, 9 };
            Console.Write("Input - "); PrintArray(input);

            var result = Solution1(input); // Execute(input);
            Console.WriteLine($"Resulting odd man value: {result}");
        }

        void PrintArray(int[] arr)
        {
            Console.WriteLine($"{string.Join(",", arr)}");
        }

        int Solution1(int[] input)
        {
            // if array is not of length in odd number
            if (input.Length % 2 == 0) return 0;

            // if the array length is beyond the threshold
            if (input.Length < 1 || input.Length > 1000000) return 0;

            // check if the values in the array are beyond the allowable threshold values
            if (input.Any(v => v > 1000000000 || v < 1)) return 0;

            // this is very ideal to use, as how the sql group by and having would work. and finding out the odd man out
            var result =
                input
                .OrderBy(v => v)
                .GroupBy(v => v)
                .Where(grp => grp.Count() == 1)
                .Select(grp => grp.Key)
                .FirstOrDefault();

            return result;
        }

        int Solution2(int[] input)
        {
            int oddManValue = 0;
            // if array is not of length in odd number
            if (input.Length % 2 == 0) return 0;

            // if the array length is beyond the threshold
            if (input.Length < 1 || input.Length > 1000000) return 0;

            // check if the values in the array are beyond the allowable threshold values
            if (input.Any(v => v > 1000000000 || v < 1)) return 0;

            QuickSortArray(input);

            // classis loop execution
            for (int mainLoop = 0; mainLoop < input.Length;mainLoop++)
            {
                for (int innerLoop = mainLoop +1; innerLoop < input.Length;innerLoop++)
                {
                    if (input[mainLoop] == 0) break;
                    if (input[mainLoop] == input[innerLoop])
                    {
                        input[mainLoop] = input[innerLoop] = 0;
                        PrintArray(input);
                        continue;
                    }
                }
            }

            QuickSortArray(input);

            // get the odd man from the loop
            for (int loop = 0; loop < input.Length; loop++)
                if (input[loop] != 0) { oddManValue = input[loop]; break; }
                else continue;

            // return the odd Man
            return oddManValue;
        }

        int[] QuickSortArray(int[] input)
        {
            // sort the array
            for (int mainLoop = 0; mainLoop < input.Length; mainLoop++)
            {
                for (int innerLoop = mainLoop + 1; innerLoop < input.Length; innerLoop++)
                {
                    if (input[mainLoop] == input[innerLoop]) continue;
                    if (input[mainLoop] > input[innerLoop])
                    {
                        input[mainLoop] = input[mainLoop] + input[innerLoop];
                        input[innerLoop] = input[mainLoop] - input[innerLoop];
                        input[mainLoop] = input[mainLoop] - input[innerLoop];
                        PrintArray(input);
                        //continue;
                    }
                }
            }

            return input;
        }
    }
}
