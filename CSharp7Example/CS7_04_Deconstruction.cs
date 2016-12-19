using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace CSharp7Example
{
    public class CS7_04_Deconstruction
    {
        public void Run()
        {
            // calls Deconstruct(out myX, out myY);
            (var myX, var myY) = new Point(3, 5); 
            WriteLine($"{myX} {myY}");
            //discard
            (var x1, var _) = new Point(4, -3);
            WriteLine($"{x1}");
        }
    }
}
