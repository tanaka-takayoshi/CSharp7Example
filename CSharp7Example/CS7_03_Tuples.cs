using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace CSharp7Example
{
    public class CS7_03_Tuples
    {
        public void Run()
        {
            var names = GetPrice(1);
            WriteLine($"found {names.Item1} {names.Item2}."); // access by previous style
            WriteLine($"found {names.price} {names.discount}."); // access by property names
            (int first, int middle) = GetPrice(4); // tuple elements have names
            (int price, int _) = GetPrice(6); // discard the property. And cannot infer `var`
        }

        (int price, int discount) GetPrice(int itemId)
        {
            var product = (500, 100);
            return product;
        }

    }
}
