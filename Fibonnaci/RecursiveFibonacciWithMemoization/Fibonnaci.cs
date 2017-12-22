using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace RecursiveFibonacciWithMemoization
{
    public class Fibonacci
    {
        private  Dictionary<long,long> map;

        public Dictionary<long, long> Map { get => map; set => map = value; }


        public Fibonacci() => map = new Dictionary<long, long>();

        public long FindFibonacciValue(long number)
        {

            if (number == 0 || number == 1)
            {
                return number;
            }
            else if (map.ContainsKey(number))
            {
                map.TryGetValue(number, out var outValue);
                return outValue;
            }
            else
            {
                
                var fibonacciValue = FindFibonacciValue(number - 2) + FindFibonacciValue(number - 1);
                map.Add(number, fibonacciValue);
                //Thread.Sleep(100);

                return fibonacciValue;
               
            }
        }
    }

}
