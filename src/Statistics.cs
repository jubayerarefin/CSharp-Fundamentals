using System;

namespace GradeBook
{
    public class Statistics
    {
        public double Total;
        public double Average
        {
            get
            {
                return Total / Count;
            }
        }
        public double High;
        public double Low;
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90:
                        return 'A';
                    case var d when d >= 80:
                        return 'B';
                    case var d when d >= 70:
                        return 'C';
                    case var d when d >= 60:
                        return 'D';
                    default:
                        return 'F';
                }
            }
        }
        public int Count;

        public Statistics()
        {
            Total = 0;
            Count = 0;
            High = ushort.MinValue;
            Low = ushort.MaxValue;
        }

        public void Add(double number)
        {
            Total += number;
            Count += 1;
            High = Math.Max(number, Low);
            Low = Math.Min(number, High);
        }
    }
}