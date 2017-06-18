using System;
using System.Collections.Generic;

namespace Fibonnaci
{
    class Program
    {
		/// <summary>
		/// This program receives an integer in its console input, 
		/// If the integer is part of the Fibonnaci Sequence 
		/// it displays the previous two integers of the sequence. 
		/// If the integer is not part of the sequence, it displays "ERROR" on the Console
		/// Output.
		/// Note:
		/// In mathematics, the Fibonacci numbers are the numbers in the following integer sequence, 
		/// called the Fibonacci sequence, and characterized by the fact that every number after the first two is the sum of the two preceding ones.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
        {
            Console.WriteLine("Enter one number from the Fibonacci sequence and hit ENTER: ");
            long input = 0;
            Int64.TryParse(Console.ReadLine().Trim(), out input);

            long start = 0;
            long next = 1;


            //Initialize
            List<long> fiboSeq = new List<long>();
            fiboSeq.Add(start);
            fiboSeq.Add(next);


            //calculate

            while (input > fiboSeq[fiboSeq.Count-1])
            {

                long nextFiboNumber = start + next;
                fiboSeq.Add(nextFiboNumber);

                start = next;
                next = nextFiboNumber;
            }

            //display answer
            DisplayAnswer(input, fiboSeq);

            Console.ReadLine();
        }
        /// <summary>
        /// Displays the two previous Fibonacci numbers given an input
        /// </summary>
        /// <param name="input">The integer entered on screen</param>
        /// <param name="fiboSeq">The list holding the generated Fibonacci sequence so far</param>
        private static void DisplayAnswer(long input, List<long> fiboSeq)
        {
            if ((fiboSeq.Count > 1) && (input == fiboSeq[fiboSeq.Count - 1]))
            {
                Console.WriteLine("The two preceding FIbonacci numbers are: ");
                Console.WriteLine(fiboSeq[fiboSeq.Count - 2]);
                Console.WriteLine(fiboSeq[fiboSeq.Count - 3]);

            }
            else if (fiboSeq.Count == 1)
            {
                Console.WriteLine("The two preceding FIbonacci numbers are: ");
                Console.WriteLine(fiboSeq[1]);
                Console.WriteLine(fiboSeq[0]);
            }
            else
            {
                Console.WriteLine("ERROR");
            }
        }
    }
}