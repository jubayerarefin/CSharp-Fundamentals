using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private List<Double> grades;
        private String name;

        public Book(String name)
        {
            grades = new List<Double>();
            this.name = name;
        }
        //Add Grade to Grades List
        public void AddGrade(Double grade)
        {
            grades.Add(grade);
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