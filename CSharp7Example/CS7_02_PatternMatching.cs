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
            PrintShape(null);
            PrintShapeWithDefaultFirst(null);
            PrintShapeWithDefaultFirst(new Circle(3));
            PrintShapeOrder(new Circle(4));
        }

        void OldPrintStars(object o)
        {
            if (o is string)
            {
                WriteLine("must not be string");
                return;
            }
            var i = o as int?;
            if (i != null)
            {
                WriteLine(new string('*', i.Value));
            }
        }

        public void PrintStars(object o)
        {
            if (o is null) return; // constant pattern "null"
            if (o is int.MaxValue) return;
            if (o is "a") return;
            if (!(o is int i)) // type pattern "int i"
            {
                //WriteLine(i); //trueのときのみ変数が割り当てられるのでiを参照するとコンパイルエラー
                return; 
            }
            
            WriteLine(new string('*', i)); //上のif文でfalseのときにreturnもしくは例外をスローせずにiを参照すると、確実に代入される保証がないのでコンパイルエラーになる

            if (o is var j) // var patternはnullの時も含め常にtrueとなり割り当てられる
            {
                WriteLine(j);
            }
        }

        void OldPrintStarts(SomeObject o)
        {
            var value = o?.Inner?.Value;
            if (value.HasValue)
                WriteLine(new string('*', value.Value));
        }

        void PrintStarts(SomeObject o)
        {
            if (o?.Inner?.Value is int i)
                WriteLine(new string('*', i));
        }

        public void PrintShape(object shape)
        {
            switch (shape)
            {
                //C# 6.0以前のcase節
                case 0:
                    WriteLine("should not be '0'");
                    break;
                //C# 6.0以前のcaseにガード節追加
                case 1 when IsDebug(shape):
                    WriteLine("should not be '1' if debug is enabled");
                    break;
                //type pattern
                //case Circle: のようにプリミティブでない型をC# 6.0以前のように記述するとコンパイルエラー。変数宣言として記述しないといけない。
                case Circle c:
                    WriteLine($"circle with radius {c.Radius}");
                    break;
                //キャストした変数が不要な場合は_が利用できる
                case int _:
                    WriteLine("should not be integer");
                    break;
                //type patternにガード節
                case Rectangle s when (s.Length == s.Height):
                    WriteLine($"{s.Length} x {s.Height} square");
                    break;
                //上のガード節に一致しない場合のtype pattern
                case Rectangle r:
                    WriteLine($"{r.Length} x {r.Height} rectangle");
                    break;    
                //var パターンも利用可能
                case var i when IsDebug(i):
                    WriteLine("debug is enabled.");
                    break;
                default:
                    WriteLine("<unknown shape>");
                    break;
            }
        }

        public void PrintShapeWithDefaultFirst(object shape)
        {
            switch (shape)
            {
                default:
                    WriteLine("<unknown shape>");
                    break;
                case Circle c:
                    WriteLine($"circle with radius {c.Radius}");
                    break;
                case null:
                    WriteLine("<null>");
                    break;
            }
        }

        public void PrintShapeOrder(object shape)
        {

            switch (shape)
            {
                case Rectangle r:
                    WriteLine($"{r.Length} x {r.Height} rectangle");
                    break;
                    //コンパイラが到達不可能であることを検出できる場合はコンパイルエラーとなる
                    //case Rectangle s when (s.Length == s.Height):
                    //    WriteLine($"{s.Length} x {s.Height} square");
                    //    break;
            }

            var flg = true;
            switch (shape)
            {
                case Rectangle r when flg:
                    WriteLine($"{r.Length} x {r.Height} rectangle");
                    break;
                //到達不可能であるが、現時点でのコンパイラは検出しない
                case Rectangle s when (s.Length == s.Height):
                    WriteLine($"{s.Length} x {s.Height} square");
                    break;
            }
        }

        private bool IsDebug(object i) => i is 1;
    }

    class SomeObject
    {
        public AnotherObject Inner { get; set; }
    }
    class AnotherObject
    {
        public int Value { get; set; }
    }
}
