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

    class Person
    {
        private static ConcurrentDictionary<int, string> names = new ConcurrentDictionary<int, string>();
        
        private int id = GetId();

        private static int GetId()
        {
            return 1;
        }

        public Person(string name) => names.TryAdd(id, name); // constructors
        ~Person() => names.TryRemove(id, out _);              // destructors
        public string Name
        {
            get => names[id];                                 // getters
            set => names[id] = value;                         // setters
        }

    }

}
