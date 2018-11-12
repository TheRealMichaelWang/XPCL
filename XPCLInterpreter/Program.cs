using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPCLinterpreter
{
    class Program
    {
        static string[] lines;
        static VariableManager resx;
        static Executor executor;
        static void Main(string[] args)
        {
            Console.WriteLine("Cross-Pointer-Calculation-Language   (C)Michael Wang");
            Console.WriteLine("XPCL Interpreter 1");
            lines = File.ReadAllLines(Environment.CurrentDirectory + "\\main.xpcl");
            resx = new VariableManager("resx.txt");
            executor = new Executor();
            for(int i = 0; i < lines.Length;i++)
            {
                ArgumentData data = new ArgumentData(lines[i]);
                if (data.argument == "exec")
                {
                    for (int x = 0; x < data.commands.Length; x++)
                    {
                        executor.ExecuteCommand(data.commands[x], resx);
                    }
                }
                if(data.argument == "point")
                {
                    i = int.Parse(data.commands[0]);
                }
                if(data.argument == "equalsvar")
                {
                    string a = (string)resx.GetValue(data.commands[0]);
                    string b = (string)resx.GetValue(data.commands[1]);
                    if(a == b)
                    {
                        i = int.Parse(data.commands[2]);
                    }
                }
                if (data.argument == "equalsinput")
                {
                    string a = (string)resx.GetValue(data.commands[0]);
                    Console.WriteLine("");
                    Console.Write(">:");
                    string b = Console.ReadLine();
                    if (a == b)
                    {
                        i = int.Parse(data.commands[1]);
                    }
                }
                if(data.argument == "frominp")
                {
                    Console.WriteLine("");
                    Console.Write(">:");
                    string a = Console.ReadLine();
                    resx.WriteValue(data.commands[0], a);
                }
                if(data.argument == "help")
                {
                    Console.WriteLine("Command Help for XPCL version 1");
                    Console.WriteLine("Name of nodes (first argument):\n" +
                        "exec/      Executor-executes all commands\n"+
                        "point/     Pointer -points to a line of code to execute\n"
                       +"frominp/   Writes a input to a variable\n"
                       +"equalsvar/ checks whether 2 variables equal\n"
                       +"equalsinmput/ checks whether 2 inputs equal"+"\n\nExecutor Commands:\n"
                       +"start      starts a new process");
                }
            }
        }
    }
}
