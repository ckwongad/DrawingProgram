using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram.Parser.CommandParserException
{
    public class InvalidCommandTypeException : CommandParserException
    {
        public InvalidCommandTypeException()
        {
        }

        public InvalidCommandTypeException(string message)
            : base(message)
        {
        }

        public InvalidCommandTypeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
