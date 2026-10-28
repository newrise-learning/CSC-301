using System;
using System.Threading;
using System.Threading.Tasks;

susing System;
using System.Threading;

namespace Tasks2
{
    class Program
    {
        static void Main(string[] args)
        {
            var cs = new CancellationTokenSource();
            var ct = cs.Token;

            var task1 = new Task(() =>
            {
                while (true)
                {
                    var input = Console.ReadKey(true);
                    if (input.Key == ConsoleKey.Escape)
                    {
                        cs.Cancel();
                        break;
                    }
                }
            });

            var task2 = new Task(() => {
                while (true)
                {
                    Thread.Sleep(2000);
                    Console.WriteLine("Task still running...");
                    if (ct.IsCancellationRequested)
                    {
                        Console.WriteLine("Task cancelled.");
                        break;
                    }
                }
            }, ct);// associated cancellation token with Task

            try
            {
                task2.Start();
                task1.Start();
                task2.Wait();
            }
            catch (Exception) {
                if (task2.IsCanceled) Console.WriteLine("Task was cancelled.");
                else Console.WriteLine("Error occurred in task.");
            }
        }
    }
}
