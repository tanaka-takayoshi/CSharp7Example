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
            DeconstructionUsage();
            DeconstructionAssignment();
        }

        void DeconstructionUsage()
        {
            var tuple = (name: "Tom", age: 34);
            string name; int age;
            (name, age) = tuple; //宣言済みの変数（=式）に分解して代入する
            WriteLine(age);

            int x, y;
            (x, y) = new Point(3, 5); //Deconstructメソッドを持つインスタンスを分解する
            WriteLine($"{x} {y}");

            //分解して新しく宣言した変数に代入する
            (var newName, var newAge) = tuple;
            (var myX, var myY) = new Point(3, 5);

            //式と変数宣言の併用はコンパイルエラー
            //(x, var y2) = new Point(3, 4);

            //out variableと同じく_で無視できる
            (var x1, var _) = new Point(4, -3);
            WriteLine($"{x1}");
            //var _ は変数宣言扱いなので変数への代入と併用するとコンパイルエラー
            //(x1, var _) = new Point(4, -3);
        }

        void DeconstructionAssignment()
        {
            string name; byte b;
            (name, b) = ("a", 1); //左辺のbがbyteであり、右辺の1はbyteとして宣言できるためOK
            //(name, b) = ("a", 1234); 1234はbyteにキャストできないのでコンパイルエラー
            var t = ("a", 1);
            //(name, b) = t; 暗黙的に型付けするとt は(string, int)であるため、intをbyteにキャストできないためコンパイルエラー

            int x; double y;
            (x, y) = new Point(2, 4); //doubleはintから暗黙的に変換できるのでOK
            //(x, b) = new Point(2, 4); // byteはintから暗黙的に変換できないのでコンパイルエラー

            (x, y) = Tuple.Create(1, 3); //C# 6.0以前のTupleでも利用可能
            //(x, y) = new { x = 1, y = 2 }; //匿名オブジェクトは不可

            var p = new int[2];
            (p[0], p[1]) = (3, 4); //左辺の要素が代入可能であれば利用できる
            int i;
            (i, i) = (1, 2); //割り当ては要素の順番に従って行われる
            WriteLine(i); //2
        }

        void DeconstuctionDeclaration()
        {
            //暗黙的な型変換が存在すればOK
            (double myX, long myY) = new Point(3, 5);
            //拡張メソッドは解決できない
            //(byte x2, byte y2) = new Point(3, 4);
            (var s1, var y) = new C1();
            //outパラメーターの数が同じ複数のDeconstructメソッドがオーバーロードされている場合、
            //左辺の要素の数がその同じ数だけ分解しようとしている場合、コンパイルエラーになる (※1)
            //(string x2, bool b2, int y2) = new C1();
        }


    }

    static class PointExtensions
    {
        public static void Deconstruct(this Point p, out byte x, out byte y)
        {
            x = (byte)p.X;
            y = (byte)p.Y;
        }
        
    }

    class C1
    {
        public void Deconstruct(out string x, out int y)
        {
            x = "a";
            y = 1;
        }
        //(※1)outパラメーターの数が同じ複数のDeconstructメソッドをオーバーロード宣言すること自体は許可されている
        public void Deconstruct(out string x, out bool b, out int y)
        {
            x = "a";
            b = true;
            y = 1;
        }
        public void Deconstruct(out string x, out bool b1, out bool b2)
        {
            x = "a";
            b1 = true;
            b2 = false;
        }
    }
}
