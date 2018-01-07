using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RecursiveFibonacciWithMemoization
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
        /// 
        /// </summary>
        /// <param name="args">One of the integers that are part of the sequence
        /// 10946 (number 21 of the sequence) anything bigger than that will cause System.StackOverflow on purpose.
        /// </param>
        static void Main(string[] args)
        {
            Console.WriteLine("Enter one number from the Fibonacci sequence and hit ENTER: ");
            Int64.TryParse(Console.ReadLine().Trim(), out var input);

            Fibonacci f = new Fibonacci();
            var number=f.FindFibonacciValue(input);


            ConsumeCpuBeforeDisplayingAnswer(f);
            DisplayAnswer(input, f.Map);
        }


        /// <summary>
        /// This method is only meant to consume CPU time and % of utilization 
        /// to showcase the Hot Lines on a VS 2017 CPU prolifing session  using Sampling.
        /// </summary>
        /// <param name="fib"></param>
        private static void ConsumeCpuBeforeDisplayingAnswer(Fibonacci fib)
        {
            
            var tasks = new List<Task>();

            foreach (var item in fib.Map)
            {
                var t2 = Task.Run(() => SumKeyValue(item));

                tasks.Add(t2);
                
                
            }
            Task.WaitAll(tasks.ToArray());
        }

        private static void SumKeyValue(KeyValuePair<long, long> item)
        {
            var delay = 1000; //1000ms delay
            var sum = item.Key + item.Value;
            Thread.Sleep(delay);
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
