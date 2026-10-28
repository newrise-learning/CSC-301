using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks1
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> task4 = new Task<int>(() => {
                Console.WriteLine("Task 4");
                Thread.Sleep(4000); return 123;
            });
            task4.Start(); task4.Wait();
            Console.WriteLine(task4.Result);
        }
    }
}
