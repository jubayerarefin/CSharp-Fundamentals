using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            //Testing basic printing from cli args
            printTest(args);
            //Calculate Grade from a Double Type List
            List<Double> Grades = new List<Double>() { 32.50, 46.50, 50.29, 49.99 };
            calculateGrade(Grades);
        }

        //Printing variable length CLI args
        public static void printTest(string[] args)
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

        //Calculate Grade from a Double Type List
        public static void calculateGrade(List<Double> Grades)
        {
            Double total = 0.0;
            Double avg;
            //Sum and Average grade
            foreach (var marks in Grades)
            {
                total += marks;
            }
            avg = total / Grades.Count;
            Console.WriteLine($"Total: {total}");
            Console.WriteLine($"Result: {avg}");
        }
    }
}
