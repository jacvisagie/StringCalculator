//using StringCalculator;
using StringCalculator.Web.Business;
using System;
using Xunit;

namespace StringCalculatorTests
{
    public class StringAddTests
    {
        [Fact]
        public void Add_Empty_String_Returns_Zero()
        {
            //Arrange
            var input = "";
            var expectedOutput = 0;

            //Act
            var actualOutput = NumbersAdding.Add(input);

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Add_Single()
        {
            //Arrange
            var input = "1";
            var expectedOutput = 1;

            //Act
            var actualOutput = NumbersAdding.Add(input);

            //Assert
            Assert.Equal(expectedOutput, actualOutput);

        }

        [Fact]
        public void Add_Multi()
        {
            //Arrange
            var input = "1,2";
            var expectedOutput = 3;

            //Act
            var actualOutput = NumbersAdding.Add(input);

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Add_Multi_With_NewLine()
        {
            //Arrange
            var input = "1\n2,3";
            var expectedOutput = 6;

            //Act
            var actualOutput = NumbersAdding.Add(input);

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Add_Multi_With_NewLine_And_New_Seperator()
        {
            //Arrange
            var input = "//;\n1;2";
            var expectedOutput = 3;

            //Act
            var actualOutput = NumbersAdding.Add(input);

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Add_Multi_With_Negative_Throws_Exception()
        {
            // Arrange
            var input = "-4,5,-2";
            var expectedOutput = "negatives not allowed : -4,-2";

            //Act
            var ex = Assert.Throws<Exception>(() => NumbersAdding.Add(input));

            //Assert
            Assert.Equal(expectedOutput, ex.Message);
        }

        [Fact]
        public void Add_With_Multi_Seperators()
        {
            //Arrange
            var input = "//[*][%]\n1*2%3";
            var expectedOutput = 6;

            //Act
            var actualOutput = NumbersAdding.Add(input);

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Add_With_Multi_Char_Multi_Seperators()
        {
            //Arrange
            var input = "//[*%][%*]\n1*%2%*3";
            var expectedOutput = 6;

            //Act
            var actualOutput = NumbersAdding.Add(input);

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Add_val_greater_than_1000_Ignored()
        {
            //Arrange
            var input = "1,1004,2";
            var expectedOutput = 3;

            //Act
            var actualOutput = NumbersAdding.Add(input);

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Add_val_handle_newlines_as_delimiters()
        {
            //Arrange
            var input = "1,2\n3";
            var expectedOutput = 6;

            //Act
            var actualOutput = NumbersAdding.Add(input);

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
