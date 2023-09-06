using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RefactoringLabb;
using RefactoringLabb.Interfaces;

namespace TestProject.Test
{
    [TestClass]
    public class CowsGameTests
    {

        private CowsGame game;

        [TestInitialize]
        public void Initialize()
        {            
            // Arrange: Create the CowsGame instance with mock dependencies
            game = new CowsGame();
        }

        [TestMethod]
        public void CreateWinningNumbers_ReturnsNonEmptyString()
        {
            // Act
            string winningNumbers = game.CreateWinningNumbers();

            // Assert
            Assert.IsNotNull(winningNumbers);
            Assert.AreNotEqual("", winningNumbers);
        }

        [TestMethod]
        public void IsValidGuess_ValidGuess_ReturnsTrue()
        {
            // Arrange
            string validGuess = "1234";

            // Act
            bool isValid = game.IsValidGuess(validGuess);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsValidGuess_InvalidGuess_ReturnsFalse()
        {
            // Arrange
            string invalidGuess = "12A4"; // Contains a non-numeric character

            // Act
            bool isValid = game.IsValidGuess(invalidGuess);

            // Assert
            Assert.IsFalse(isValid);
        }

        // Add more test methods as needed
    }
}
