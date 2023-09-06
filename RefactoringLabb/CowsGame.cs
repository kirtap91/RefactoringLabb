using RefactoringLabb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringLabb
{
     public class CowsGame
    {

        public string CreateWinningNumbers()
        {
            try
            {
                Random randomGenerator = new Random();
                HashSet<string> winningNumbers = new HashSet<string>();

                while (winningNumbers.Count < 4)
                {
                    var randomDigit = randomGenerator.Next(10).ToString();
                    winningNumbers.Add(randomDigit);
                }

                return string.Join("", winningNumbers);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while creating winning numbers: " + ex.Message);
                return "Error";
            }
        }

        public bool IsValidGuess(string guess)
        {
            if (string.IsNullOrEmpty(guess) || guess.Length != 4 || !int.TryParse(guess, out _))
            {
                Console.WriteLine("Invalid input, guess with 4 numbers");
                return false;
            }

            return true;
        }

        public string FormatGuessResult(IntermediateGuessResult result)
        {
            return $"{new string('B', result.RightNumberRightPlace)},{new string('C', result.RightNumberWrongPlace)}";
        }



        public IntermediateGuessResult CompareGuessToGoal(string goal, string guess)
        {

            try
            {
                int rightNumberRightPlace = 0, rightNumberWrongPlace = 0;

                for (int index = 0; index < 4; index++)
                {
                    char goalDigit = goal[index];
                    char guessDigit = guess[index];

                    if (goalDigit == guessDigit)
                    {
                        rightNumberRightPlace++;
                    }
                    else if (goal.Contains(guessDigit))
                    {
                        rightNumberWrongPlace++;
                    }
                }

                return new IntermediateGuessResult
                {
                    RightNumberRightPlace = rightNumberRightPlace,
                    RightNumberWrongPlace = rightNumberWrongPlace,
                };
            }
            catch (Exception ex)
            {
 
                Console.WriteLine("An error occurred: " + ex.Message);
                return new IntermediateGuessResult();
            }
        }
    }
}
