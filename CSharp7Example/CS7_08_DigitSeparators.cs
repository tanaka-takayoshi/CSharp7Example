using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace CSharp7Example
{
    public class CS7_08_DigitSeparators
    {
        public void Run()
        {
            int i1 = 0b1000_0110_1110;
            long i2 = 0xdead_beaf;
            var i3 = 123_456_789;
            var i4 = 1___2__3_____4; //1234
            WriteLine(i1);
            WriteLine(i2);
            WriteLine(i3);
            WriteLine(i4    );
        }
    }
}
