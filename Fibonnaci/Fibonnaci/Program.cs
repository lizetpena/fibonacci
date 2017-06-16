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

			if (input == fiboSeq[fiboSeq.Count - 1])
			{
				Console.WriteLine(fiboSeq[fiboSeq.Count - 2]);
				Console.WriteLine(fiboSeq[fiboSeq.Count - 3]);

			}
			else
			{
				Console.WriteLine("ERROR");
			}


			Console.ReadLine();
        }
    }
}