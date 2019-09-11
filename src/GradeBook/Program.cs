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
            gradebook.AddGrade(34.50);
            gradebook.AddGrade(46.49);
            gradebook.AddGrade(50.29);
            gradebook.AddGrade(49.99);
            gradebook.ShowStatistics();
        }
    }
}
