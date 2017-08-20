using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram.Parser
{
    public static class CommadParserErrorMsg
    {
        public static readonly string EmptyInput = "input is empty";

        public static string InvalidCommandType(string cmdType) {
            return "command type is invalid: " + cmdType;
        }

        public static string InvalidIntCommandArg(string arg)
        {
            return String.Format("Command " +
                    "expects an integer. Instead \"{0}\" is provided.", arg);
        }

        public static string InvalidCharCommandArg(string arg)
        {
            return String.Format("Command " +
                    "expects a character. Instead \"{0}\" is provided.", arg);
        }

        public static string InvalidCommandArgLength(string commandType, int expectedLength, int actualLength)
        {
            return String.Format("{0} command " + 
                    "expects {1} arguments. Instead {2} argument(s) is/are provided.", commandType, expectedLength, actualLength);
        }
    }
}
