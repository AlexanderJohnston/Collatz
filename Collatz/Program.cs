using System;
using System.Collections.Generic;

namespace Collatz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" How many numbers to test on Collatz?");
            var test = Console.ReadLine();
            var numberTries = Int32.Parse(test);
            for (int i = 1; i < numberTries; i++)
            {
                double n = i;
                var sequence = new List<double>();
                while (n != 4)
                {
                    n = NextCollatz(n);
                    sequence.Add(n);
                }
                // Final sequence of all runs.
                sequence.Add(2);
                sequence.Add(1);

                Console.Write($"Collatz {i}: ");
                foreach (var integer in sequence)
                {
                    Console.Write($"{integer},");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        static double NextCollatz(double n)
        {
            var sequence = n % 2;
            return sequence switch
            {
                0.0d => n / 2,
                1.0d => (3 * n) + 1,
                _ => throw new NotImplementedException()
            };
        }

    }
}
