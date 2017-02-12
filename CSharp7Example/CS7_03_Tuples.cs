using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using static System.Console;

namespace CSharp7Example
{
    public class CS7_03_Tuples
    {
        public void Run()
        {
            OldStyle();
            ValueTuple();
            TupleBasicUsage();
            TupleUnderlyingTypes();
        }

        void OldStyle()
        {
            //文字列をすべて小文字にしたものとすべて大文字にしたものを取得する

            //匿名オブジェクトを利用
            var texts = 
            new[] { "aaA", "bBb", "cCC" }
            .Select(x => new { lower = x.ToLower(), upper = x.ToUpper() });
            foreach (var text in texts)
            {
                WriteLine($"lower={text.lower}, upper={text.upper}");
            }

            //System.Tupleを利用
            foreach (var text in Convert(new[] { "aaA", "bBb", "cCC" }))
            {
                WriteLine($"lower={text.Item1}, upper={text.Item2}");
            }
        }

        IEnumerable<Tuple<string, string>> Convert(IEnumerable<string> texts)
        {
            return texts.Select(x => new Tuple<string, string>(x.ToLower(), x.ToUpper()));
        }

        void ValueTuple()
        {
            foreach (var text in ConvertToValueTuple(new[] { "aaA", "bBb", "cCC" }))
            {
                WriteLine($"lower={text.lower}, upper={text.upper}");
            }
        }

        IEnumerable<(string lower, string upper)> ConvertToValueTuple(IEnumerable<string> texts)
        {
            return texts.Select(x => (lower: x.ToLower(), upper: x.ToUpper()));
        }

        void TupleBasicUsage()
        {
            var text = "aaAA";
            //タプルリテラルで宣言
            var t1 = (text.ToLower(), text.ToUpper()); //要素名は任意
            var t2 = (lower: text.ToLower(), upper: text.ToUpper());
            //new形式はコンパイルエラー
            //var t3 = new(int, int)(0, 1); 
            var t4 = (lower: text.ToLower(), text.ToUpper()); //一部のみ要素名を省略することも可
            WriteLine($"{t4.lower}, {t4.Item2}");
            //同じ要素名で重複するとコンパイルエラー
            //var t5 = (lower: text.ToLower(), lower: text.ToLower());
        }

        void TupleUnderlyingTypes()
        {
            var t = (sum: 0, count: 1);
            t.sum = 1;         
            t.Item1 = 1; //要素名を指定していてもItemNで参照できる。Visual StudioではデフォルトでRoslynの警告メッセージが表示される

            var t1 = (0, 1);          
            t1.Item1 = 1;  //要素名を指定していなければ警告メッセージはでない

            WriteLine(t.ToString()); //(1, 1) と出力される。ｌToStringなどobjectクラスが持っているメソッドも利用できる
            
            //var t3 = (ToString: 0, ObjectEquals: 1); //もとのクラスが持っているメンバーの名前と同じ要素名を指定するとコンパイルエラー
            var t4 = (Item1: 0, Item2: 1);  //Item1,Item2という要素名は利用できるが
            //var t5 = (misc: 0, Item1: 1); //ことなる位置で利用するとコンパイルエラー
        }

        void TupleIdentityConversion()
        {
            var t = (sum: 0, count: 1);
            ValueTuple<int, int> vt = t; // 同一の型に変換
            (int moo, int boo) t2 = vt;  //要素名が異なっても同一の型となる     

            t2.moo = 1;
        }

        (int sum, int count) moo()
        {
            return (count: 1, sum: 3); //コンパイル警告は表示されるが異なる要素名でリテラルを宣言できる
        }

        void NameErasure()
        {
            object o = (a: 1, b: 2);             // boxing conversion 
            var t = ((int moo, int boo))o;       // unboxing conversion
            WriteLine(t.moo); //1
        }

        void TargetTyping()
        {
            (string name, byte age) t = (null, 5); // 左辺でstringを指定しているためnullを指定できる

            var t2 = ("John", 5); 
            //var t3 = (null, 5);  //nullは型を持たないためコンパイルエラー
            //((1, 2, null), 5).ToString();  //同じくコンパイルエラー

            //ImmutableArray.Create((() => 1, 1));     //ラムダ式自体は型を持たないためエラー
            ImmutableArray.Create(((Func<int>)(()=>1), 1)); // ラムダ式をキャストしているためOK

            var t4 = (name: "John", age: 5);
            t4.age++;
        }

        void M1((int x, int y) arg) => WriteLine("called M1((int x, int y) arg)");
        void M1((object x, object y) arg) => WriteLine("called ((object x, object y) arg)");

        void Overload()
        {
            M1((1, 2));             // called M1((int x, int y) arg)
            M1(("hi", "hello"));   // called ((object x, object y) arg)
        }

        void M2((int x, Func<(int, int)>) arg) => Write("called M2((int x, Func<(int, int)>) arg)");
        void M2((int x, Func<(int, byte)>) arg) => WriteLine("called M2((int x, Func<(int, byte)>) arg)");

        void Overload2()
        {
            M2((1, () => (2, 3))); //called M2((int x, Func<(int, int)>) arg)
        }
        
        ((int x, int y, int z)?, int t)? SpaceTime()
        {
            return ((1, 2, 3), 7);
        }

        (int price, int discount) GetPrice(int itemId)
        {
            var product = (500, 100);
            return product;
        }
    }

    class Base
    {
        public virtual void M1(ValueTuple<int, int> arg) {/*...*/}
    }
    class Derived : Base
    {
       // public override void M1((int c, int d) arg) {/*...*/} // 要素名が異なるのでオーバーライドできない
    }
    class Derived2 : Derived
    {
        public override void M1((int, int) arg) {/*...*/} // 要素名を省略した場合は同一であるためオーバーライド可能
    }

    class InvalidOverloading
    {
        public virtual void M1((int c, int d) arg) {/*...*/}
        //public virtual void M1((int x, int y) arg) {/*...*/}  //要素名が異なるだけではオーバーロードできない
        //public virtual void M1(ValueTuple<int, int> arg) {/*...*/}  //同じく省略してもオーバーロードできない
        public virtual void M1((int c, string d) arg) {/*...*/}
    }
}
