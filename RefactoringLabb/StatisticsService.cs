using RefactoringLabb;
using RefactoringLabb.Interfaces;
using RefactoringLabb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringLabb
{
    public class StatisticsService
    {
        private readonly IUI _io;
        private readonly FormatPlayerStatistics _formatter;
        public StatisticsService(FormatPlayerStatistics formatter, IUI io)
        {
            _formatter = formatter;
            _io = io;
        }
        public void ShowTopList()
        {
            StreamReader resultTextFile = _io.GetResultStreamReader();
            List<PlayerData> allPlayerDatas = new List<PlayerData>();
            string playerDataLine;
            while (!string.IsNullOrEmpty((playerDataLine = _io.ReadNextLine(resultTextFile))))
            {
                var playerData = GetPlayerDataWithRecentNumberOfGuesses(playerDataLine);
                UpdateOrCreatePlayerDatas(allPlayerDatas, playerData);


            }
            var topList = allPlayerDatas.OrderBy(p => p.AverageGuessesPerGame());
            _io.WriteTopListHeaders();
            foreach (PlayerData playerData in allPlayerDatas)
            {
                _io.WriteLine(_formatter.FormatPlayerData(playerData));
            }
            resultTextFile.Close();
        }
        private void UpdateOrCreatePlayerDatas(List<PlayerData> allPlayerDatas,
            PlayerDataWithRecentNumberOfGuesses playerData)
        {
            int playerDataPosition = allPlayerDatas.IndexOf(playerData.PlayerData);
            if (playerDataPosition < 0)
            {
                allPlayerDatas.Add(playerData.PlayerData);
            }
            else
            {
                allPlayerDatas[playerDataPosition].UpdateTotalGuesses(playerData.RecentNumberOfGuesses);
            }
        }

        private PlayerDataWithRecentNumberOfGuesses GetPlayerDataWithRecentNumberOfGuesses(string line)
        {
            string[] nameAndScore = line.Split(new string[] { Constants.StatisticsSeparator }, StringSplitOptions.None);
            string name = nameAndScore[0];
            int guesses = Convert.ToInt32(nameAndScore[1]);
            return new PlayerDataWithRecentNumberOfGuesses(new PlayerData(name, guesses), guesses);
        }
        public void OutputStatisticsToFile(string name, int numberOfGuesses)
        {
            StreamWriter output = new StreamWriter("gameresults.txt", append: true);
            output.WriteLine(name + Constants.StatisticsSeparator + numberOfGuesses);
            output.Close();
        }

        public class PlayerData
        {
            public string Name { get; private set; }
            public int NumberOfGames { get; private set; }
            int TotalGuesses;


            public PlayerData(string name, int guesses)
            {
                this.Name = name;
                NumberOfGames = 1;
                TotalGuesses = guesses;
            }

            public void UpdateTotalGuesses(int guesses)
            {
                TotalGuesses += guesses;
                NumberOfGames++;
            }

            public double AverageGuessesPerGame()
            {
                return (double)TotalGuesses / NumberOfGames;
            }


            public override bool Equals(Object p)
            {
                return Name.Equals(((PlayerData)p).Name);
            }


            public override int GetHashCode()
            {
                return Name.GetHashCode();
            }

        }
    }
}