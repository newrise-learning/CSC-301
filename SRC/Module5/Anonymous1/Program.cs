using System;
using Symbion;
using Symbolicon.Data;

namespace Anonymous1
{
    public class Program
    {
        static dynamic Add(dynamic v1, dynamic v2)
        {
            return v1 + v2;
        }

        static void ShowAccount(dynamic obj)
        {
            Console.Write("Code:", obj.ID);
            Console.Write("Name:", obj.Name);
            Console.Write("Balance:", obj.Balance);
        }

        static void Show(dynamic obj)
        {
            Console.WriteLine(obj.Name);
        }
        static void Main(string[] args)
        {
            Show(new { Name = "Phillip" });
            Console.WriteLine(Add(99, 66));
            Console.WriteLine(Add(1.99, 66.1));
            Console.WriteLine(Add('C', 2));
            Console.WriteLine(Add("Hello!", "Goodbye!"));
            Console.WriteLine(Add(DateTime.Now, new TimeSpan(1, 2, 3, 4)));
        }
    }
}
