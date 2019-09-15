using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            //Calculate Grade Statistics
            InMemoryBook gradebook = new InMemoryBook("InMemoryBook");
            DiskBook book_1 = new DiskBook("DiskBook");
            gradebook.GradeAdded += OnGradeAdded;
            book_1.GradeAdded += OnGradeAdded;

            try
            {
                EnterGradesInMemoryBook(gradebook);
                gradebook.ShowStatistics();

                EnterGradesDiskBook(book_1);
                book_1.ShowStatistics();
                book_1.WriteStatistics();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Please start again!");
            }
        }

        private static void EnterGradesInMemoryBook(InMemoryBook gradebook)
        {
            while (true)
            {
                Console.WriteLine($"Enter grades for {gradebook.Name}");
                Console.WriteLine($"Enter `q` to quit/stop\nThe program will also stop automatically after you've entered 4 grades.");
                var input = Console.ReadLine().ToLower();
                if (!input.Equals("q"))
                {
                    var grade = Double.Parse(input);
                    gradebook.AddGrade(grade);
                    if (gradebook.GetGrades().Count == gradebook.GetMaxGradeCount())
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("You've successfully invoked your right to stop!");
                    break;
                }
            }
        }

        private static void EnterGradesDiskBook(DiskBook book)
        {
            while (true)
            {
                Console.WriteLine($"Enter grades for {book.Name}");
                Console.WriteLine($"Enter `q` to quit/stop\nThe program will also stop automatically after you've entered 4 grades.");
                var input = Console.ReadLine().ToLower();
                if (!input.Equals("q"))
                {
                    var grade = Double.Parse(input);
                    book.AddGrade(grade);
                    if (book.GetGrades().Count == book.GetMaxGradeCount())
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("You've successfully invoked your right to stop!");
                    break;
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine($"A Grade was added for {sender.ToString()}");
        }
    }
}
