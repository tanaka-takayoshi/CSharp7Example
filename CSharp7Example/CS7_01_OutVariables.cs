using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace CSharp7Example
{
    public class CS7_01_OutVariables
    {
        public void Run()
        {
            PrintCoordinates(new Point(-3, 4));
            Overload(new Point(2, 4));
            PrintStars("4");
            PrintStars("abc");
        }

        void OldStyle(Point p)
        {
            int x, y; //事前に変数を宣言する必要があった
            p.GetCoordinates(out x, out y);
            WriteLine($"({x}, {y})");
        }

        //out variavles
        void PrintCoordinates(Point p)
        {
            //WriteLine(x1); //変数のスコープ内であっても宣言前には参照できない
            p.GetCoordinates(out var x1, out int y1);
            WriteLine($"(x1,y1)=({x1}, {y1})"); //変数のスコープはメソッド呼び出しと同じスコープ内            
        }

        void PrintCoordinates2(Point p)
        {
            //WriteLine(x1); //変数のスコープ内であっても宣言前には参照できない
            p.GetCoordinates(out var x1, out var y1);
            WriteLine($"(x1,y1)=({x1}, {y1})"); //変数のスコープはメソッド呼び出しと同じスコープ内
            p.GetCoordinates(out var x, out int _);
            WriteLine($"x={x}");
            //WriteLine($"_={_}"); //_ は変数として参照できない
            p.GetCoordinates(out var _, out int y);
            WriteLine($"y={y}");
            
        }

        void PrintStars(string s)
        {
            if (int.TryParse(s, out var i))
                WriteLine(new string('*', i));
            else
                WriteLine("Cloudy - no stars tonight!");
            WriteLine($"input value is : {i}");//can access i
        }

        void DeclareUnderscore(Point p)
        {
            var _ = 1;
            p.GetCoordinates(out var _, out int y);
            WriteLine(_);
        }

        void UseDeclareAgain(Point p)
        {
            p.GetXSetY(out int x, x = 2);
            //p.GetXSetY(out var x1, x1 = 2);
        }

        void Overload(Point p)
        {
            p.GetX(out int x);
            //p.GetX(out var x1); varだとオーバーロード解決できない
        }
    }
}
