using DrawingProgram.Canvas;
using DrawingProgram.Command;
using DrawingProgram.Command.CommandArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram.Parser
{
    public class CommandParser
    {
        protected ICanvas _canvas;

        public CommandParser(ICanvas canvas)
        {
            _canvas = canvas;
        }

        public ICommand ParseCommand(string cmdStr)
        {
            if (String.IsNullOrWhiteSpace(cmdStr))
                throw new ArgumentException(CommadParserErrorMsg.EmptyInput);

            var args = cmdStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var cmdType = args[0];
            switch (cmdType)
            {
                case "C":
                    return ParseCanvasCommand(args.Skip(1).ToArray());
                case "L":
                    return ParseLineCommand(args.Skip(1).ToArray());
                case "R":
                    return ParseRectangleCommand(args.Skip(1).ToArray());
                case "B":
                    return ParseFillCommand(args.Skip(1).ToArray());
                default:
                    throw new CommandParserException.InvalidCommandTypeException(CommadParserErrorMsg.InvalidCommandType(cmdType));
            }
        }

        /*
         * extra args are simple ignored
        */
        private ICommand ParseCanvasCommand(string[] args)
        {
            if (args.Length != 2)
            {
                throw new ArgumentException(CommadParserErrorMsg.InvalidCommandArgLength("Canvas", 2, args.Length));
            }

            int width = ParsePosIntArg(args[0]);
            int height = ParsePosIntArg(args[1]);

            return new CanvasCommand(_canvas, new int[2] { width, height });
        }

        /*
         * extra args are simple ignored
        */
        private ICommand ParseLineCommand(string[] args)
        {
            if (args.Length != 4)
            {
                throw new ArgumentException(CommadParserErrorMsg.InvalidCommandArgLength("Line", 4, args.Length));
            }

            int x1 = ParsePosIntArg(args[0]);
            int y1 = ParsePosIntArg(args[1]);
            int x2 = ParsePosIntArg(args[2]);
            int y2 = ParsePosIntArg(args[3]);

            return new LineCommand(_canvas, new int[4] { x1, y1, x2, y2 });
        }

        /*
         * extra args are simple ignored
        */
        private ICommand ParseRectangleCommand(string[] args)
        {
            if (args.Length != 4)
            {
                throw new ArgumentException(CommadParserErrorMsg.InvalidCommandArgLength("Rectangle", 4, args.Length));
            }

            int x1 = ParsePosIntArg(args[0]);
            int y1 = ParsePosIntArg(args[1]);
            int x2 = ParsePosIntArg(args[2]);
            int y2 = ParsePosIntArg(args[3]);

            return new RectangleCommand(_canvas, new int[4] { x1, y1, x2, y2 });
        }

        /*
         * extra args are simple ignored
        */
        private ICommand ParseFillCommand(string[] args)
        {
            if (args.Length != 3)
            {
                throw new ArgumentException(CommadParserErrorMsg.InvalidCommandArgLength("Fill", 3, args.Length));
            }

            int x = ParsePosIntArg(args[0]);
            int y = ParsePosIntArg(args[1]);
            char fillColor = ParseCharArg(args[2]);

            return new FillCommand(_canvas, new FillCommandArgs(x, y, fillColor));
        }

        private int ParseNonNegativeIntArg(string arg)
        {
            int res;
            if (!int.TryParse(arg, out res) || res < 0)
                throw new ArgumentException(CommadParserErrorMsg.InvalidNonNegativeIntCommandArg(arg));

            return res;
        }

        private int ParsePosIntArg(string arg)
        {
            int res;
            if (!int.TryParse(arg, out res) || res < 1)
                throw new ArgumentException(CommadParserErrorMsg.InvalidPosIntCommandArg(arg));

            return res;
        }

        private char ParseCharArg(string arg)
        {
            char res;
            if (!Char.TryParse(arg, out res))
                throw new ArgumentException(CommadParserErrorMsg.InvalidCharCommandArg(arg));

            return res;
        }
    }
}
