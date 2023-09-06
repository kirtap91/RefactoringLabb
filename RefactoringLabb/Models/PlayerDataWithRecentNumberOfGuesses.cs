using RefactoringLabb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RefactoringLabb.StatisticsService;

namespace RefactoringLabb.Models
{
    public class PlayerDataWithRecentNumberOfGuesses
    {
        public PlayerDataWithRecentNumberOfGuesses(PlayerData playerData, int guesses)
        {
            PlayerData = playerData;
            RecentNumberOfGuesses = guesses;
        }
        public PlayerData PlayerData { get; set; }
        public int RecentNumberOfGuesses { get; set; }
    }
}
