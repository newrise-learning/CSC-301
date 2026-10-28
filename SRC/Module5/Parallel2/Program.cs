using System;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel2
{
    class Program
    {
        static void Main(string[] args)
        {
            void Task1() { Console.WriteLine("Task 1"); Thread.Sleep(4000); }
            void Task2() { Console.WriteLine("Task 2"); Thread.Sleep(4000); }
            void Task3() { Console.WriteLine("Task 3"); Thread.Sleep(4000); }
            Action[] tasks = { Task1, Task2, Task3 };
            Parallel.Invoke(tasks);
            Console.WriteLine("Finish");
        }
    }
}
