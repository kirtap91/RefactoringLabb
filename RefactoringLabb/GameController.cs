using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using RefactoringLabb.Interfaces;
using RefactoringLabb.Models;

namespace RefactoringLabb
{
    public class GameController
    {
        private readonly IUI ui;
        private readonly StatisticsService statisticsService;
        private readonly CowsGame game;


        public GameController(StatisticsService statisticsService, IUI ui, CowsGame game)
        {
            this.statisticsService = statisticsService;
            this.ui = ui;
            this.game = game;
        }

        public void RunGame()
        {
            try
            {
                var name = GetUserName();
                bool playOn;

                do
                {
                    int numberOfGuesses = 1;
                    string winningNumbers = game.CreateWinningNumbers();

                    ui.PutString("New game:\n" + winningNumbers);

                    while (true)
                    {
                        var guessResult = MakeGuess(winningNumbers);
                        if (guessResult == Constants.CorrectGuess)
                            break;

                        numberOfGuesses++;
                        ui.PutString("That guess was incorrect, try again");
                    }

                    statisticsService.OutputStatisticsToFile(name, numberOfGuesses);
                    statisticsService.ShowTopList();

                    string answer = ValidateInputToContinueGameOrNot("Continue? (y/n):", "y", "n");
                    playOn = (answer == "y");
                } while (playOn);
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        private string ValidateInputToContinueGameOrNot(string prompt, string validOption1, string validOption2)
        {
            string answer;
            do
            {
                ui.PutString(prompt);
                answer = ui.GetString();
            } while (string.IsNullOrEmpty(answer) || (answer != validOption1 && answer != validOption2));

            return answer;
        }

        private void HandleError(Exception ex)
        {
            ui.PutString("An error occurred: " + ex.Message);
        }

        public string GetUserName()
        {
            string userName;

            do
            {
                ui.PutString("Enter your user name:\n");
                userName = ui.GetString();

                if (string.IsNullOrEmpty(userName))
                {
                    ui.PutString("Invalid input. Please enter a non-empty user name.");
                }
            }
            while (string.IsNullOrEmpty(userName));

            return userName;
        }

        public string MakeGuess(string goal)
        {
            try
            { 
                string guess = GetValidGuess();
                var intermediateGuessResult = game.CompareGuessToGoal(goal, guess);
                var guessResult = game.FormatGuessResult(intermediateGuessResult);
                DisplayGuessResult(guessResult);
                return guessResult;
            }
            catch (Exception ex)
            {
                HandleError(ex);
                return string.Empty;
            }
        }

        private string GetValidGuess()
        {
            ui.PutString("Enter your guess:\n");
            var guess = ui.GetString();

            var guessIsValid = game.IsValidGuess(guess);

            if (!guessIsValid)
            {
                guess = GetValidGuess();
            }
            return guess;
        }

        private void DisplayGuessResult(string result)
        {
            ui.PutString(result + "\n");
        }


    }
}
