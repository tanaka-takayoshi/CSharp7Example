using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace CSharp7Example
{
    public class CS7_06_RefReturns
    {
        public void Run()
        {
            RefUsage();
            RefLocals();
            ref var j = ref M5();
            WriteLine(j);
            j = 3;
            System.GC.Collect();
            WriteLine(j);
        }

        void RefUsage()
        {
            int[] array = { 1, 15, -39, 0, 7, 14, -12 };
            ref int place = ref Find(7, array); //値が7の配列要素の参照を取得
            place = 9; // 配列要素の参照先を書き換える
            WriteLine(array[4]); // 5番目の要素が9に書き換わっている
        }

        ref int Find(int number, int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == number)
                {
                    return ref numbers[i]; // 配列の値ではなく参照元を返す
                }
            }
            throw new IndexOutOfRangeException($"{nameof(number)} not found");
        }

        void RefLocals()
        {
            var a = 100;
            ref int b = ref a; //bとaの参照は同じ
            var c = b; //cにbのその時の値=100を代入
            ref var d = ref b; //dとbの参照は同じ = aとも同じ参照
            ++b; //bに１足すので、a,b,dとも101
            ++a; //さらにaに１足すので、a,b,dとも102
            ++c; //cに１足して、cだけ101
            WriteLine($"{a},{b},{c},{d}"); //102,102,101,102
        }

        ref int M1(ref int i) => ref i;
        //ref int M2(int i) => ref i; //通常の引数を参照渡しにするとコンパイルエラー
        //ref int M3() => ref 1; //定数リテラルを参照渡しにするとコンパイルエラー
        //ref int M4()
        //{
        //    var x = int.Parse(Console.ReadLine());
        //    return ref x; //ローカル変数を参照渡しにするとコンパイルエラー
        //}

        ref int M5()
        {
            var x = 1;
            ref var y = ref M1(ref x);
            ref var z = ref M1(ref y);
            //return ref z; // ここで大本のxが値で初期化しているためコンパイルエラー
            return ref new int[] { 1, 2, 3}[0]; //オブジェクトの参照は返せる
        }
    }
}
