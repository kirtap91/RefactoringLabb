using RefactoringLabb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringLabb
{
    public class ConsoleIO : IUI
    {
        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Exit()
        {
            System.Environment.Exit(0);
        }

        public StreamReader GetResultStreamReader()
        {
            return new StreamReader("result.txt");
        }

        public string GetString()
        {
            return Console.ReadLine();
        }

        public void PutString(string s)
        {
            Console.WriteLine(s);
        }

        public string ReadNextLine(StreamReader resultTextFile)
        {
            return resultTextFile.ReadLine();
        }

        public void WriteLine(string textToWrite)
        {
            Console.WriteLine(textToWrite);
        }

        public void WriteTopListHeaders()
        {
            Console.WriteLine("Player   games average");
        }
    }
}
