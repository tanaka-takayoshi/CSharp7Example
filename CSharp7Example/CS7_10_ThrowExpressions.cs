using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7Example
{
    class CS7_10_ThrowExpressions
    {
        internal void Run()
        {
            
        }

        class Person2
        {
            public string Name { get; }
            public Person2(string name) => Name = name ?? throw new ArgumentNullException(name);
            public string GetFirstName()
            {
                var parts = Name.Split(' ');
                return (parts.Length > 0) ? parts[0] : throw new InvalidOperationException("No name!");
            }
            public string GetLastName() => throw new NotImplementedException();
        }

    }
}
