using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace CSharp7Example
{
    public class CS7_02_PatternMatching
    {
        public void Run()
        {
            PrintStars(3);
            PrintStars("3");
            PrintShape(new Circle(4));
            PrintShape(new Rectangle(4, 4));
            PrintShape(new Rectangle(4, 6));
            PrintShape(new object());
        }

        public void PrintStars(object o)
        {
            if (o is null) return;     // constant pattern "null"
            if (!(o is int i)) return; // type pattern "int i"
            WriteLine(new string('*', i));
        }

        public void PrintShape(object shape)
        {
            switch (shape)
            {
                case Circle c:
                    WriteLine($"circle with radius {c.Radius}");
                    break;
                case Rectangle s when (s.Length == s.Height):
                    WriteLine($"{s.Length} x {s.Height} square");
                    break;
                case Rectangle r:
                    WriteLine($"{r.Length} x {r.Height} rectangle");
                    break;
                default:
                    WriteLine("<unknown shape>");
                    break;
                case null:
                    throw new ArgumentNullException(nameof(shape));
            }
        }
    }
}
