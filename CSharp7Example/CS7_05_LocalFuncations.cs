using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using static System.Console;

namespace CSharp7Example
{
    public class CS7_05_LocalFuncations
    {
        public void Run()
        {
            void Add(int x, int y)
            {
                WriteLine($"{x} + {y} = {x + y}");
            }
            void Multiply(int x, int y)
            {
                WriteLine($"{x} * {y} = {x * y}");
                Add(30, 10);
            }
            Add(20, 50);
            Multiply(20, 50);

            //maybe stackoverflowexception
            // WriteLine(GetFactorial(9000));
            WriteLine(GetFactorialUsingLocal(9000));
        }

        private static BigInteger GetFactorial(int number)
        {
            return number * GetFactorial(number - 1);
        }

        private static BigInteger GetFactorialUsingLocal(int number)
        {
            BigInteger result = number;
            while (number > 1)
            {
                Multiply(number - 1);
                number--;
            }
            void Multiply(int x) => result *= x;
            return result;
        }

    }
}
