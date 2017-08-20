using DrawingProgram.Canvas;
using DrawingProgram.Command;
using DrawingProgram.Parser;
using DrawingProgram.Printer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            var consolePrinter = new ConsolePrinter();
            var canvas = new SimpleCanvas(consolePrinter);
            var commandParser = new CommandParser(canvas);
            var invoker = new Invoker();

            while (true)
            {
                Console.Write("enter command: ");
                string line = Console.ReadLine();
                if (line == "Q") // Exit
                {
                    break;
                }

                ICommand command;
                try
                {
                    command = commandParser.ParseCommand(line);
                    invoker.Command = command;
                    invoker.ExecuteCommand();
                    canvas.Print();
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
