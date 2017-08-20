using DrawingProgram.Command;
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
            while (true)
            {
                Console.Write("enter command: ");
                string line = Console.ReadLine();
                if (line == "Q") // Exit
                {
                    break;
                }

                Console.Write("You typed "); // Report output
                Console.Write(line.Length);
                Console.WriteLine(" character(s)");
            }
        }
    }
}
