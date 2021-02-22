using Codility_Console;
using Codility_Console.ArrayRotation;
using Codility_Console.BinaryGap;
using System;

namespace Codility
{
    class Program
    {
        static void Main(string[] args)
        {
            ISolution solution = new OddManInArray();
                // new ArrayRotation();
                // new BinaryGapSolutionV2(); // new BinaryGapSolution();
            solution.Run();
            // Console.Read();
        }
    }
}
