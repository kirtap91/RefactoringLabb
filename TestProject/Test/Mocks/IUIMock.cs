using RefactoringLabb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringLabb.Test.Mocks
{
    public class IUIMock : IUI
    {
        public List<string> LinesInTextFile = new();
        private int CurrentLine = 0;
        public List<string> LinesWrittenToPlayer = new();

        public StreamReader GetResultStreamReader()
        {
            return new StreamReader(new MemoryStream());
        }

        public string ReadNextLine(StreamReader resultTextFile)
        {
            if(LinesInTextFile.Count < CurrentLine + 1)
            {
                return string.Empty;
            }

            var line = LinesInTextFile[CurrentLine];
            CurrentLine++;
            return line;
        }

        public void WriteLine(string textToWrite)
        {
            LinesWrittenToPlayer.Add(textToWrite);
        }

        public void WriteTopListHeaders()
        {
            return;
        }

        public void PutString(string s)
        {
            throw new NotImplementedException();
        }

        public string GetString()
        {
            throw new NotImplementedException();
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }
    }
}
