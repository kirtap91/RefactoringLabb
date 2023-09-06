using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactoringLabb.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RefactoringLabb.Test
{
    [TestClass]
    public class StatisticsServiceTests
    {
        private readonly FormatPlayerStatistics _formatter = new();
        private readonly IUIMock _io = new();

        [TestMethod]
        public void ShowTopList_Writes_Ordered_Results_To_Player()
        {
            //Arrange
            var linesInTextFile = new List<string>
            {
                "Henric" + Constants.StatisticsSeparator + "1",
                "Patrik" + Constants.StatisticsSeparator + "2"
            };

            _io.LinesInTextFile = linesInTextFile;
            var service = CreateService();

            //Act
            service.ShowTopList();


            //Assert
            Assert.AreEqual(2, _io.LinesWrittenToPlayer.Count);
            Assert.AreEqual("Henric       1     1,00", _io.LinesWrittenToPlayer[0]);
            Assert.AreEqual("Patrik       1     2,00", _io.LinesWrittenToPlayer[1]);
        }


        private StatisticsService CreateService()
        {
            return new StatisticsService(_formatter, _io);
        }
    }
}
