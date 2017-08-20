using System;

namespace DrawingProgram.Parser.CommandParserException
{
    public class CommandParserException : Exception
    {
        public CommandParserException()
        {
        }

        public CommandParserException(string message)
            : base(message)
        {
        }

        public CommandParserException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
