using DrawingProgram.Canvas;
using DrawingProgram.Command;
using DrawingProgram.Parser;
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
            var canvas = new SimpleCanvas();
            var commandParser = new CommandParser(canvas);

            while (true)
            {
                Console.Write("enter command: ");
                string line = Console.ReadLine();
                if (line == "Q") // Exit
                {
                    break;
                }

                try
                {
                    ICommand command = commandParser.ParseCommand(line);
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
