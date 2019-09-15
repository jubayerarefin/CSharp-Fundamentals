using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        private String name;

        public NamedObject(String name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException($"Invalid {nameof(value)}");
                }
            }
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        void ShowStatistics();
        event GradeAddedDelegate GradeAdded;
        List<Double> GetGrades();
        ushort GetMaxGradeCount();
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(Double grade);

        public abstract List<double> GetGrades();

        public abstract ushort GetMaxGradeCount();

        public abstract Statistics GetStatistics();

        public abstract void ShowStatistics();
    }
    public class InMemoryBook : Book
    {
        private List<Double> grades = new List<double>();

        private const ushort maxGradeCount = 4;

        public override List<Double> GetGrades()
        {
            return grades;
        }

        public override ushort GetMaxGradeCount()
        {
            return maxGradeCount;
        }

        public InMemoryBook(String name) : base(name)
        {
            grades = new List<Double>();
            Name = name;
        }

        //Add Grade to Grades List
        public override void AddGrade(Double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                if (grades.Count < maxGradeCount)
                {
                    grades.Add(grade);
                    GradeAdded?.Invoke(this, new EventArgs());
                }
                else
                {
                    Console.WriteLine($"Reached maximum grade count of: {maxGradeCount}");
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override event GradeAddedDelegate GradeAdded;

        //Calculate Grade from a Double Type List
        public override Statistics GetStatistics()
        {
            Statistics result = new Statistics();
            //Calculate Total, Average, Max & Min
            foreach (var mark in grades)
            {
                result.Add(mark); ;
            }

            return result;
        }

        public override void ShowStatistics()
        {
            var result = this.GetStatistics();
            Console.WriteLine($"Result: {result.Total:N2}");
            Console.WriteLine($"Average: {result.Average:N2}");
            Console.WriteLine($"Max: {result.High:N2}");
            Console.WriteLine($"Min: {result.Low:N2}");
            Console.WriteLine($"The Letter Grade is: {result.Letter}");
        }
    }

    public class DiskBook : Book
    {
        private List<Double> grades = new List<double>();
        private const ushort maxGradeCount = 4;

        public override event GradeAddedDelegate GradeAdded;

        public DiskBook(string name) : base(name)
        {
            Name = name;
        }

        public override List<Double> GetGrades()
        {
            return grades;
        }

        public override ushort GetMaxGradeCount()
        {
            return maxGradeCount;
        }

        public override void AddGrade(double grade)
        {
            try
            {
                if (grade <= 100 && grade >= 0)
                {
                    if (grades.Count < maxGradeCount)
                    {
                        grades.Add(grade);
                        using (var writer = File.AppendText($"../../../DiskBook/{Name}.txt"))
                        {
                            writer.WriteLine(grade);
                            GradeAdded?.Invoke(this, new EventArgs());
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Reached maximum grade count of: {maxGradeCount}");
                    }
                }
                else
                {
                    throw new ArgumentException($"Invalid {nameof(grade)}");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override Statistics GetStatistics()
        {
            Statistics result = new Statistics();
            //Calculate Total, Average, Max & Min
            using (var reader = File.OpenText($"../../../DiskBook/{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    result.Add(double.Parse(line));
                    line = reader.ReadLine();
                }
            }

            return result;
        }

        public override void ShowStatistics()
        {
            var result = this.GetStatistics();
            Console.WriteLine($"Result: {result.Total:N2}");
            Console.WriteLine($"Average: {result.Average:N2}");
            Console.WriteLine($"Max: {result.High:N2}");
            Console.WriteLine($"Min: {result.Low:N2}");
            Console.WriteLine($"The Letter Grade is: {result.Letter}");
        }

        public void WriteStatistics()
        {
            var result = this.GetStatistics();
            var writer = File.AppendText($"../../../DiskBook/{Name}.txt");
            writer.WriteLine();
            writer.WriteLine($"Result: {result.Total:N2}");
            writer.WriteLine($"Average: {result.Average:N2}");
            writer.WriteLine($"Max: {result.High:N2}");
            writer.WriteLine($"Min: {result.Low:N2}");
            writer.WriteLine($"The Letter Grade is: {result.Letter}");
            writer.Close();
        }
    }
}