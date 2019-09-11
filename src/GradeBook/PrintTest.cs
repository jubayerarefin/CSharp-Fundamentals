using System;
namespace GradeBook
{
    class PrintTest
    {
        //Printing variable length CLI args
        public static void Print(string[] args)
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