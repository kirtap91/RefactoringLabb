using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringLabb.Interfaces
{
    public interface IUI
    {
        void PutString(string s);
        string GetString();
        void Exit();
        void Clear();

        StreamReader GetResultStreamReader();
        string ReadNextLine(StreamReader resultTextFile);
        void WriteTopListHeaders();
        void WriteLine(string textToWrite);
    }
}
