using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPCLinterpreter
{
    class Variable
    {
        public string name;
        public string value;
        public string arguments;
        public Variable(string arguments,string name, string value)
        {
            this.name = name;
            this.value = value;
            this.arguments = arguments;
        }
        public string getdata()
        {
            return value;
        }
    }
}
