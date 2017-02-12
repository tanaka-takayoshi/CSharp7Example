using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharp7Example
{
    class CS7_07_GeneralizedAsyncReturnTypes
    {
        internal void Run()
        {
            async Task Inner()
            {
                var res = await SearchAsync(100);
                WriteLine(res);
                res = await SearchAsync(1);
                WriteLine(res);
            }
            Inner().GetAwaiter().GetResult();
        }

        async ValueTask<int> SearchAsync(int a)
        {
            if (a != 100)
                return 0;
            await Task.Delay(1000);
            return 1;
        }
    }
}
