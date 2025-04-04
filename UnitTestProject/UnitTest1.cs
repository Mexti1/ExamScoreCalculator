using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExamScoreCalculator; // Импортируем namespace, где находится класс
using System;

namespace UnitTestProject
{
    [TestClass]
    public class ScoreCalculatorTests
    {
        private ScoreCalculator _calculator;
        // Полное имя класса

        [TestInitialize]
        public void TestInitialize()
        {
            _calculator = new ScoreCalculator();
            // Полное имя класса
        }

        [TestMethod]
        public void ParseScore_ValidInput_ReturnsCorrectValue()
        {
            // Arrange
            string input = "15";
            int maxScore = 22;
            string fieldName = "Test";

            // Act
            int result = _calculator.ParseScore(input, maxScore, fieldName);

            // Assert
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseScore_NonNumericInput_ThrowsException()
        {
            // Arrange
            string input = "abc";
            int maxScore = 22;
            string fieldName = "Test";

            // Act
            _calculator.ParseScore(input, maxScore, fieldName);
        }
    }
}