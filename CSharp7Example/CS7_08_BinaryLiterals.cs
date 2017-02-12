using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7Example
{
    public class CS7_08_BinaryLiterals
    {
        public void Run()
        {
            int a1 = 10;
            int a2 = 0b01011;
            int a3 = 0B101011100;
            uint a4 = 0b101011100u;
            long a5 = 0b101011100L;
            ulong a6 = 0b101011100uL;
            Console.WriteLine($"{a1} {a2} {a3} {a4} {a5} {a6}");
        }
    }
}
