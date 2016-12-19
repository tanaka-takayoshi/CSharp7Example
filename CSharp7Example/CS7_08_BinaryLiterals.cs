using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7Example
{
    public class CS7_08_BinaryLiterals
    {
        public void Run()
        {
            int a1 = 50;
            int a2 = 0b01011;
            int a3 = 0B101011100;
            Console.WriteLine($"{a1} {a2} {a3}");
        }
    }
}
