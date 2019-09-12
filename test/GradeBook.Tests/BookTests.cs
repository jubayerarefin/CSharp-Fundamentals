using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrades()
        {
            // arrange
            var book = new Book("");
            book.AddGrade(60);
            book.AddGrade(90);
            book.AddGrade(70);
            book.AddGrade(60);
            // act
            var result = book.GetStatistics();

            //assert
            Assert.Equal(280, result.Total);
            Assert.Equal(70, result.Average);
            Assert.Equal(90, result.High);
            Assert.Equal(60, result.Low);
            Assert.Equal('C', result.Letter);
        }

        [Fact]
        public void BookCalculatesAnAverageGradesFromCLIInput()
        {
            // arrange
            var book = new Book("");
            book.AddGrade(60);
            book.AddGrade(90);
            book.AddGrade(70);
            book.AddGrade(60);
            book.AddGrade(10);
            book.AddGrade(10);
            // act
            var result = book.GetStatistics();

            //assert
            Assert.Equal(book.GetMaxGradeCount(), book.GetGrades().Count);
            Assert.Equal(280, result.Total);
            Assert.Equal(70, result.Average);
            Assert.Equal(90, result.High);
            Assert.Equal(60, result.Low);
            Assert.Equal('C', result.Letter);
        }
    }
}
