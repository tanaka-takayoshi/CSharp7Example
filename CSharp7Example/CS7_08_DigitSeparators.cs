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
            var i3 = 123_456_789.987_654;//123456789.987654
            var i4 = 1___2__3_____4; //1234 
            //var i5 = _123; //先頭に使うとコンパイルエラー
            //var i6 = 123_.4; //小数点の直前に使うとコンパイルエラー
            //var i7 = 123._4; //小数点の直後に使うとコンパイルエラー
            //var i8 = 123_; //末尾に使うとコンパイルエラー
            WriteLine(i1);
            WriteLine(i2);
            WriteLine(i3);
            WriteLine(i4);
        }
    }
}
