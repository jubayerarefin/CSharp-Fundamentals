using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private List<Double> grades;
        public String Name;

        public Book(String name)
        {
            grades = new List<Double>();
            Name = name;
        }
        //Add Grade to Grades List
        public void AddGrade(Double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                Console.WriteLine("Invalid Grade Value");
            }
        }

        //Calculate Grade from a Double Type List
        public Statistics GetStatistics()
        {
            Statistics result = new Statistics();
            result.Total = 0;
            result.Average = 0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            //Calculate Total, Average, Max & Min
            foreach (var mark in grades)
            {
                result.High = Math.Max(mark, result.High);
                result.Low = Math.Min(mark, result.Low);
                result.Total += mark;
            }
            result.Average = result.Total / grades.Count;

            return result;
        }

        public void ShowStatistics()
        {
            var result = this.GetStatistics();
            Console.WriteLine($"Result: {result.Total:N2}");
            Console.WriteLine($"Average: {result.Average:N2}");
            Console.WriteLine($"Max: {result.High:N2}");
            Console.WriteLine($"Min: {result.Low:N2}");
        }
    }
}