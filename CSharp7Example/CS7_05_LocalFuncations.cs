using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharp7Example
{
    public class CS7_05_LocalFuncations
    {
        public void Run()
        {
            Fibonacci(10);
            //無限に再帰する関数を呼び出すと実行時エラー
            //RecursiveLocalFunction();

            Apply(new[] { 1, 4, 5 }, i => i.ToString());

            //非同期メソッドのTaskのキャッシュ。最初の実行は３秒かかるが
            var r = GetAsync().GetAwaiter().GetResult();
            WriteLine(r);
            //次の実行はすぐに完了する
            r = GetAsync().GetAwaiter().GetResult();
            WriteLine(r);

            CaptureVariable();
            Goto();

            //単純なメソッドの再帰呼び出すは実行時エラー
            //WriteLine(GetFactorial(9000));

            WriteLine(GetFactorialUsingLocal(9000));
        }

        void Fibonacci(int i)
        {
            //匿名関数で再帰する場合は最初に宣言しないといけない
            Func<int, int> f2 = null;
            f2 = n => n >= 1 ? n * f2(n - 1) : 1;
            var res = f2(i);
            WriteLine(i);

            //ローカル関数は通常の関数同様再帰を記述できる
            int f(int x) => x >= 1 ? x * f(x - 1) : 1;
            //ローカル関数を暗黙的に型宣言するとコンパイルエラー
            //var f3(int x) => x >= 1 ? x * f(x - 1) : 1;
            res = f(i);
            WriteLine(i);
        }

        //ローカル関数内でお互いの関数を呼び出すコードは記述できる
        //が、無限に再帰する場合は実行時エラーとなる
        void RecursiveLocalFunction()
        {
            void Add(int x, int y)
            {
                WriteLine($"{x} + {y} = {x + y}");
                Multiply(x, y);
            }
            void Multiply(int x, int y)
            {
                WriteLine($"{x} * {y} = {x * y}");
                Add(30, 10);
            }
            Add(2, 3);
        }

        //LINQのSelectメソッドで同一のことができるが、サンプルとして記述
        IEnumerable<string> Apply(IEnumerable<int> source, Func<int, string> converter)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (converter == null) throw new ArgumentNullException(nameof(converter));

            IEnumerable<string> Inner()
            {
                foreach (var x in source)
                    yield return converter(x);
            }
            return Inner();
        }

        Task<int> cache;

        Task<int> GetAsync()
        {
            async Task<int> inner()
            {
                await Task.Delay(3000);
                return 1;
            }
            cache = cache ?? inner();
            return cache;
        }

        void CaptureVariable()
        {
            int x;
            //初期化されていないローカル変数をキャプチャすることができる
            void AddTo(int y) => x = x + y;
            //xが初期化される前にローカル関数を呼び出すとコンパイルエラー
            //var res0 = AddTo(3);
            x = 5;
            AddTo(3);
            WriteLine(x); //8
        }

        //3 5 の順に出力される
        void Goto()
        {
                goto Assign;
            Before:
                goto Read;
            Declare:
                int x = 5;
                goto Read;
            Assign:
                //WriteLine(x); 初期化されていない扱いなのでコンパイルエラー
                x = 3;
                goto Before;
            Read:
                WriteLine(x);
                if (x == 3) goto Declare;
        }

        BigInteger GetFactorial(int number)
        {
            return number * GetFactorial(number - 1);
        }

        BigInteger GetFactorialUsingLocal(int number)
        {
            BigInteger result = number;
            while (number > 1)
            {
                Multiply(number - 1);
                number--;
            }
            void Multiply(int x) => result *= x;
            return result;
        }        
    }
}
