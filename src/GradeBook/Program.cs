using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            //Calculate Grade Statistics
            Book gradebook = new Book("Someones Grade Book");

            try
            {
                var input = "";
                do
                {
                    Console.WriteLine($"Enter `q` to quit/stop\nThe program will also stop automatically after you've entered 4 numbers.");
                    input = Console.ReadLine();
                    if (!input.Equals("q"))
                    {
                        if (gradebook.GetGrades().Count < gradebook.GetMaxGradeCount())
                        {
                            var grade = Double.Parse(input);
                            gradebook.AddGrade(grade);
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("You've successfully invoked your right to stop!");
                    }
                } while (input != "q");

                gradebook.ShowStatistics();
            }
            catch (System.FormatException)
            {
                Console.WriteLine($"Invalid Input");
            }
        }
    }
}
