using System;
using System.Collections.Generic;
using System.Linq;

namespace RecursiveFibonacciWithMemoization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter one number from the Fibonacci sequence and hit ENTER: ");
            Int64.TryParse(Console.ReadLine().Trim(), out var input);

            Fibonacci f = new Fibonacci();
            var number=f.FindFibonacciValue(input);

            DisplayAnswer(input, f.Map);
        }


        private static void DisplayAnswer(long input, Dictionary<long,long> fiboSeq)
        {
            if ((fiboSeq.Count > 1) && (fiboSeq.ContainsValue(input)))
            {
                var key = from x in fiboSeq
                          where x.Value == input
                          select x.Key;


                Console.WriteLine("The two preceding Fibonacci numbers are: ");

                fiboSeq.TryGetValue((key.ToList<long>())[0] - 1, out var val1);
                Console.WriteLine(val1);


                fiboSeq.TryGetValue((key.ToList<long>())[0] - 2, out var val2);
                Console.WriteLine(val2);

            }
            else if (fiboSeq.Count == 1)
            {
                Console.WriteLine("The two preceding Fibonacci numbers are: ");
                Console.WriteLine(fiboSeq[1]);
                Console.WriteLine(fiboSeq[0]);
            }
            else
            {
                Console.WriteLine($"ERROR: the integer {input} is not part of the Fibonacci sequence");
            }


            Console.ReadLine();
        }
    }

}
