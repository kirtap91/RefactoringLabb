// See httpusing System;
using System.IO;
using System.Collections.Generic;
using System.Reflection.Metadata;
using RefactoringLabb.Models;
using RefactoringLabb;
using RefactoringLabb.Interfaces;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace RefactoringLabb
{

    class Program
    {

        static void Main(string[] args)
        {
            //skapa klasser och peta in alla metoder där de hör hemma.
            //skriv enhetstester en testklass per klass
            FormatPlayerStatistics formatPlayerStatistics = new FormatPlayerStatistics();
            IUI ui = new ConsoleIO();
            StatisticsService statisticsService = new StatisticsService(formatPlayerStatistics, ui);
            CowsGame cowsGame = new CowsGame();
            GameController controller = new GameController(statisticsService, ui, cowsGame);
            controller.RunGame();
        }
    }

}        
