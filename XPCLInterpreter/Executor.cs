using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XPCLinterpreter;

namespace XPCLinterpreter
{
    class Executor
    {
        public Executor()
        {

        }
        public void ExecuteCommand(string command,VariableManager manager)
        {
            ArgumentData data = new ArgumentData(command, '-');
            if (data.argument == "printstr"||data.argument=="print")
            {
                for(int i = 0; i < data.commands.Length; i++)
                {
                    Console.WriteLine(data.commands[i]);
                }
            } 
            if(data.argument == "printvar")
            {
                for(int i = 0; i < data.commands.Length; i++)
                {
                    Console.WriteLine(manager.GetValue(data.commands[i]));
                }
            }
            if(data.argument == "multiply")
            {
                double a = double.Parse((string)manager.GetValue(data.commands[0]));
                double b = double.Parse((string)manager.GetValue(data.commands[1]));
                double c = double.Parse((string)manager.GetValue(data.commands[2]));
                c = a * b;
                manager.WriteValue(data.commands[2],c.ToString());
            }
            if(data.argument == "add")
            {
                double a = double.Parse((string)manager.GetValue(data.commands[0]));
                double b = double.Parse((string)manager.GetValue(data.commands[1]));
                double c = double.Parse((string)manager.GetValue(data.commands[2]));
                c = a + b;
                manager.WriteValue(data.commands[2], c.ToString());
            }
            if(data.argument == "divide")
            {
                double a = double.Parse((string)manager.GetValue(data.commands[0]));
                double b = double.Parse((string)manager.GetValue(data.commands[1]));
                double c = double.Parse((string)manager.GetValue(data.commands[2]));
                c = a / b;
                manager.WriteValue(data.commands[2], c.ToString());
            }
            if(data.argument == "subtract")
            {
                double a = double.Parse((string)manager.GetValue(data.commands[0]));
                double b = double.Parse((string)manager.GetValue(data.commands[1]));
                double c = double.Parse((string)manager.GetValue(data.commands[2]));
                c = a - b;
                manager.WriteValue(data.commands[2], c.ToString());
            }
            if(data.argument == "readkey")
            {
                Console.ReadKey();
            }
            if(data.argument == "settitle")
            {
                Console.Title = data.commands[0];
            }
            if(data.argument == "stop")
            {
                Console.WriteLine("Stopping");
                Process.GetCurrentProcess().Kill();
            }
            if(data.argument == "clr"||data.argument == "cls"||data.argument=="clear")
            {
                Console.Clear();
            }
            if(data.argument == "writevar")
            {
                if (IsNumber(data.commands[1]))
                {
                    manager.WriteValue(data.commands[0], data.commands[1]);
                }
                else
                {
                    manager.WriteValue(data.commands[0], (string)manager.GetValue(data.commands[1]));
                }
            }
            if(data.argument == "wait")
            {
                Thread.Sleep(int.Parse((string)data.commands[0]));
            }
            if(data.argument == "random")
            {
                Random rand = new Random();
                for(int i = 0; i<data.commands.Length;i++)
                {
                    manager.WriteValue(data.commands[i],rand.Next().ToString());
                }
            }
            if(data.argument == "start")
            {
                for(int i = 0; i <data.commands.Length;i++)
                {
                    Process.Start(Environment.CurrentDirectory+"\\"+data.commands[i]);
                }
            }
            if(data.argument == "read")
            {
                string temp = File.ReadAllText(data.commands[0]);
                manager.WriteValue(data.commands[1], temp);
            }
        }
        public bool IsNumber(string i)
        {
            if(i.Contains("1")&& i.Contains("2")&& i.Contains("3") && i.Contains("4") && i.Contains("5") && i.Contains("6")
                && i.Contains("7") && i.Contains("8") && i.Contains("9") && i.Contains("0") && i.Contains(".") && i.Contains("-"))
            {
                return true;
            }
            return false;
        }
    }
}
