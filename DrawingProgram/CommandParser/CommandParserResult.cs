using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram.CommandParser
{
    public class CommandParserResult
    {
        public bool Success { get; set; }
        public string ErrorMsg { get; set; }
        public Command.ICommand Command { get; set; }
    }
}
