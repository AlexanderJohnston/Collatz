using System;
using System.Collections.Generic;

namespace Collatz
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAndAsk();
            while (Console.ReadLine() == string.Empty)
            {
                RunAndAsk();
            }
        }

        private static void RunAndAsk()
        {
            CalculateCollatz();
            Console.WriteLine("Run again?");
        }

        private static void CalculateCollatz()
        {
            int numberTries = AskUserForMaximumInteger();
            for (int i = 1; i <= numberTries; i++)
            {
                var sequence = GetCollatzSequence(i);
                WriteCollatz(i, sequence);
            }
        }

        private static List<double> GetCollatzSequence(int i)
        {
            List<double> sequence = FindUniquePortion(i);
            // Final sequence of all runs.
            sequence.Add(2);
            sequence.Add(1);

            return sequence;
        }

        private static void WriteCollatz(int i, List<double> sequence)
        {
            Console.Write($"Collatz {i}: ");
            foreach (var integer in sequence)
            {
                Console.Write($"{integer},");
            }
            Console.WriteLine();
        }

        private static List<double> FindUniquePortion(int i)
        {
            double n = i;
            var sequence = new List<double>();
            while (n != 4)
            {
                n = NextCollatz(n);
                sequence.Add(n);
            }

            return sequence;
        }

        private static int AskUserForMaximumInteger()
        {
            Console.WriteLine(" How many numbers to test on Collatz?");
            var test = Console.ReadLine();
            var numberTries = Int32.Parse(test);
            return numberTries;
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
