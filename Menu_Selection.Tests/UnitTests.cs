using System;
using Xunit;

namespace Menu_Selection.Tests
{
    public class UnitTests
    {
        [Theory]
        [InlineData("Breakfast 1, 2, 3", "Eggs, Toast, Coffee")]
        [InlineData("Breakfast 2,3,1", "Eggs, Toast, Coffee")]
        [InlineData("Breakfast 1,2,3,3,3", "Eggs, Toast, Coffee(3)")]
        [InlineData("Breakfast 1", "Unable to process: Side is missing")]
        public void Breakfast(string input, string expected)
        {
            string actual = Program.ParseUserText(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Lunch 1,2,3", "Sandwich, Chips, Soda")]
        [InlineData("Lunch 1,2", "Sandwich, Chips, Water")]
        [InlineData("Lunch 1,1,2,3", "Unable to process: Sandwich cannot be ordered more than once")]
        [InlineData("Lunch 1,2,2", "Sandwich, Chips(2), Water")]
        [InlineData("Lunch", "Unable to process: Main is missing, side is missing")]
        public void Lunch(string input, string expected)
        {
            string actual = Program.ParseUserText(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Dinner 1,2,3,4", "Steak, Potatoes, Wine, Water, Cake")]
        [InlineData("Dinner 1,2,3", "Unable to process: Dessert is missing")]
        public void Dinner(string input, string expected)
        {
            string actual = Program.ParseUserText(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Dinner 1,2,4,4")]
        [InlineData("Lunch 1,2,1,3")]
        [InlineData("Breakfast 1,3")]
        public void CorrectInput(string input)
        {
            bool actual = Program.ValidateInput(input);
            Assert.True(actual);
        }

        [Theory]
        [InlineData("Dinner 1,2, 4,")]
        [InlineData("Lunch 2,3,4")]
        [InlineData("Breakfast 2 3 1")]
        public void IncorrectInput(string input)
        {
            bool actual = Program.ValidateInput(input);
            Assert.False(actual);
        }
    }
}
