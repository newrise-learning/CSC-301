using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel1
{
    class Program
    {
       // static List<string> list1 = new List<string>();
        static ConcurrentBag<string> list1 = new ConcurrentBag<string>();
        static int ScanDirectory1(string path)
        {
            try
            {
                var files = Directory.GetFiles(path);
                foreach (string file in files) lock(list1) list1.Add(file);
                var directories = Directory.GetDirectories(path);
                int count = files.Length;
                foreach (var directory in directories)
                    count += ScanDirectory1(directory);
                return count;
            }
            catch (Exception)
            {
                return 0;
            }
        }

  //      static List<string> list2 = new List<string>();
        static ConcurrentBag<string> list2 = new ConcurrentBag<string>();

        static int ScanDirectory2(string path)
        {
            try
            {
                var files = Directory.GetFiles(path);
                foreach (string file in files) lock(list2) list2.Add(file);
                var directories = Directory.GetDirectories(path);
                int count = files.Length;
                Parallel.ForEach (directories, directory =>
                  Interlocked.Add(ref count, ScanDirectory2(directory)));
                return count;
            }
            catch (Exception)
            {
                return 0;
            }
        }


        static void Main(string[] args)
        {
            var watch1 = Stopwatch.StartNew();
            int count1 = ScanDirectory1("C:\\Windows");
            watch1.Stop();
            var watch2 = Stopwatch.StartNew();
            int count2 = ScanDirectory2("C:\\Windows");
            watch2.Stop();

            Console.WriteLine(watch1.ElapsedMilliseconds);
            Console.WriteLine(watch2.ElapsedMilliseconds);
            Console.WriteLine(count1);
            Console.WriteLine(count2);
            Console.WriteLine(list1.Count);
            Console.WriteLine(list1.Count);
        }
    }
}
