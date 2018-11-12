using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPCLinterpreter
{
    class ArgumentData
    {
        public string[] commands;
        public string argument;
        public ArgumentData(string input)
        {
            input += "/";
            List<string> data = new List<string>();
            string temp = "";
            for(int i = 0; i < input.Length; i++)
            {
                if(input[i]=='/')
                {
                    data.Add(temp);
                    temp = "";
                }
                else
                {
                    temp += input[i];
                }
            }
            argument = data[0];
            commands = new string[data.Count - 1];
            for(int i = 1; i < data.Count; i++)
            {
                commands[i - 1] = data[i];
            }
        }
        public ArgumentData(string input,char seperator)
        {
            input += seperator;
            List<string> data = new List<string>();
            string temp = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == seperator)
                {
                    data.Add(temp);
                    temp = "";
                }
                else
                {
                    temp += input[i];
                }
            }
            argument = data[0];
            commands = new string[data.Count - 1];
            for (int i = 1; i < data.Count; i++)
            {
                commands[i - 1] = data[i];
            }
        }
    }
}
