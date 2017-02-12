using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace CSharp7Example
{
    class CS7_09_ExpressoinBodiedMembers
    {
        internal void Run()
        {
            
        }
    }

    class Example
    {
        private static int counter = 0;
        private string name;
        private IDictionary<string, string> dictionary = new Dictionary<string, string>();

        public Example() => ++counter; // コンストラクタ
        ~Example() => --counter;            // デストラクタ
        public string Name
        {
            get => name;                                 // getter
            set => name = value;                         // setter
        }
        public string this[string key]
        {
            get => dictionary[key]; //インデクサのgetter
            set => dictionary[key] = value; //インデクサsetter
        }
        public event Action E
        {
            add => ++counter;
            remove => --counter;
        }
    }

}
