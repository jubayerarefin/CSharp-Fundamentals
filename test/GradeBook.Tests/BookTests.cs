using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            // arrange
            var book = new Book("");
            book.AddGrade(10);
            book.AddGrade(20);
            book.AddGrade(30);
            book.AddGrade(40);
            // act
            var result = book.GetStatistics();

            //assert
            Assert.Equal(100, result.Total);
            Assert.Equal(25, result.Average);
            Assert.Equal(40, result.High);
            Assert.Equal(10, result.Low);

        }
    }
}
