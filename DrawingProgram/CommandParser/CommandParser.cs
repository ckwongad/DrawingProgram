using DrawingProgram.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram.CommandParser
{
    public static class CommandParser
    {
        public static CommandParserResult ParseCommand(string cmdStr)
        {
            var res = new CommandParserResult();
            if (String.IsNullOrWhiteSpace(cmdStr))
            {
                res.Success = false;
                res.ErrorMsg = CommadParserErrorMsg.EmptyInput;
                return res;
            }

            var args = cmdStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var cmdType = args[0];
            switch (cmdType)
            {
                case "C":

                    break;
                case "L":

                    break;
                case "R":

                    break;
                case "B":

                    break;
                default:
                    res.Success = false;
                    res.ErrorMsg = CommadParserErrorMsg.InvalidCommandType;
                    break;
            }
            return res;
        }
    }
}
