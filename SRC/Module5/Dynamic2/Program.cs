using System;
using System.Dynamic;

namespace Dynamic2
{
    public class Program
    {
        static void Main()
        {
            dynamic expandoObject = new ExpandoObject();

            // Adding properties dynamically
//            expandoObject.Name = "John";
//           expandoObject.Age = 25;

           Console.WriteLine(expandoObject.Name);
            Console.WriteLine(expandoObject.Age);
            Console.WriteLine(expandoObject.FullName);
            Console.WriteLine(expandoObject.Greeting());
        }
    }
}
