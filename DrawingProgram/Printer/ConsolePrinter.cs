using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram.Printer
{
    public class ConsolePrinter : IPrinter
    {
        public void Write(char _char)
        {
            Console.Write(_char);
        }

        public void NextLine()
        {
            Console.WriteLine();
        }
    }
}
