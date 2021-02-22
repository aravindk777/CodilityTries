using System;
using System.Collections.Generic;
using System.Text;

namespace Codility_Console.ArrayRotation
{
    public class ArrayRotation : ISolution
    {
        public void Run()
        {
            int[] testInputs = { -4 }; //{ 3, 8, 9, 7, 6 };
            int rotation = 3;
            Console.Write("Given input - ");
            PrintArray(testInputs);

            var result = Execute(testInputs, rotation);
            Console.Write($"Rotated {rotation} times to achieve: ");
            PrintArray(result);
        }

        void PrintArray(int[] arr)
        {
            Console.WriteLine($"{string.Join(",", arr)}");
        }

        int[] Execute(int[] input, int noOfRotation)
        {
            int[] output = new int[input.Length];
            if (noOfRotation <= 0) return input;
            for (int rotationCtr = 1; rotationCtr <= noOfRotation; rotationCtr++)
            {
                output = new int[input.Length];
                for (int arrayCtr = 0; arrayCtr < input.Length; arrayCtr++)
                {
                    if ((arrayCtr + 1) >= input.Length)
                        output[(arrayCtr + 1)- input.Length] = input[arrayCtr];
                    else
                        output[arrayCtr + 1] = input[arrayCtr];
                }
                PrintArray(output);
                input = output;
            }
            return output;
        }
    }
}
