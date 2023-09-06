using RefactoringLabb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringLabb
{

    public class FormatPlayerStatistics
    {

        public string FormatPlayerData(StatisticsService.PlayerData player)
        {
            string formattedData =
                $"{FormatName(player.Name)}" +
                $"{FormatNumberOfGames(player.NumberOfGames)}" +
                $"{FormatAverageGuesses(player.AverageGuessesPerGame())}";
            return formattedData;
        }

        private string FormatName(string name)
        {
            return name.PadRight(9);
        }

        private string FormatNumberOfGames(int numberOfGames)
        {
            return numberOfGames.ToString("D").PadLeft(5);
        }

        private string FormatAverageGuesses(double averageGuesses)
        {
            return averageGuesses.ToString("F2").PadLeft(9);
        }
    }

}
