using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace CSharp7Example
{
    public class CS7_01_OutVariables
    {
        public void Run()
        {
            PrintCoordinates(new Point(-3, 4));
            PrintStars("4");
            PrintStars("abc");
        }


        //out variavles
        void PrintCoordinates(Point p)
        {
            p.GetCoordinates(out var x1, out var y1);
            p.GetCoordinates(out var x, out var _);
            p.GetCoordinates(out var _, out var y);
            WriteLine($"({x}, {y})");
        }

        void PrintStars(string s)
        {
            if (int.TryParse(s, out var i))
                WriteLine(new string('*', i));
            else
                WriteLine("Cloudy - no stars tonight!");
            WriteLine($"input value is : {i}");//can access i
        }

    }
}
