using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            //Output with a ternary
            String output = args.Length > 0 ? $"Hello {args[0]}!" : $"Hello Stranger!";
            Console.WriteLine(output);

            //Print all parameters with a loop
            if (args.Length > 0)
            {
                foreach (var arg in args)
                {
                    Console.WriteLine($"Hello {arg}!");
                }
            }
            else
            {
                Console.WriteLine($"Hello Stranger!");
            }
        }
    }
}
