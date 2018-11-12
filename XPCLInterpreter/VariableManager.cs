using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPCLinterpreter
{
    class VariableManager
    {
        public Variable[] Resources;
        public string[] rawdata;
        public VariableManager(string name)
        {
            rawdata = File.ReadAllLines(Environment.CurrentDirectory + "\\" + name);
            List<Variable> data = new List<Variable>();
            for(int i = 0; i < rawdata.Length; i++)
            {
                ArgumentData current = new ArgumentData(rawdata[i],' ');
                data.Add(new Variable(current.argument, current.commands[0], current.commands[1]));
            }
            Resources = data.ToArray();
        }
        public object GetValue(string name)
        {
            for(int i = 0; i < Resources.Length;i++)
            {
                if(Resources[i].name == name)
                {
                    return Resources[i].getdata();
                }
            }
            throw new Exception("NullNameReference");
        }
        public void WriteValue(string name,string value)
        {
            for (int i = 0; i < Resources.Length; i++)
            {
                if (Resources[i].name == name)
                {
                    Resources[i].value = value;
                    return;
                }
            }
            throw new Exception("NullNameReference");
        }
    }
}
