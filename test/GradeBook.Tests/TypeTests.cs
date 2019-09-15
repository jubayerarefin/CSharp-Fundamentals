using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        int count = 0;
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello there!");

            Assert.Equal(3, count);
        }

        private string IncrementCount(string logMessage)
        {
            count++;
            return logMessage.ToLower();
        }
        private string ReturnMessage(string logMessage)
        {
            count++;
            return logMessage;
        }

        [Fact]
        public void StringBehaveLikeValueType()
        {
            String name = "Odin";
            var upper = MakeNameUpperCase(name);

            Assert.Equal("Odin", name);
            Assert.Equal("ODIN", upper);
        }

        private String MakeNameUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void Test1()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByReference()
        {
            // arrange
            var book1 = GetBook("InMemoryBook 1");
            GetBookSetNameByRef(ref book1, "New Name");
            // act

            //assert
            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetNameByRef(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            // arrange
            var book1 = GetBook("InMemoryBook 1");
            GetBookSetName(book1, "New Name");
            // act

            //assert
            Assert.Equal("InMemoryBook 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            // arrange
            var book1 = GetBook("InMemoryBook 1");
            SetName(book1, "New Name");
            // act

            //assert
            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            // arrange
            var book1 = GetBook("InMemoryBook 1");
            var book2 = GetBook("InMemoryBook 2");

            // act

            //assert
            Assert.Equal("InMemoryBook 1", book1.Name);
            Assert.Equal("InMemoryBook 2", book2.Name);
            Assert.NotSame(book1, book2);
        }
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            // arrange
            var book1 = GetBook("InMemoryBook 1");
            var book2 = book1;

            // act

            //assert
            Assert.Equal(book1, book2);
            Assert.True(object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
