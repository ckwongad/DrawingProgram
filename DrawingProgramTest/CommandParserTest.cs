using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingProgram.Parser;
using MSTestExtensions;
using DrawingProgram.Parser.CommandParserException;
using DrawingProgram.Command;
using DrawingProgram.Printer;

namespace DrawingProgramTest
{
    [TestClass]
    public class CommandParserTest : BaseTest
    {
        private CommandParser commandParser = new CommandParser(new DrawingProgram.Canvas.SimpleCanvas(new StringPrinter()));

        [TestInitialize]
        public void SetupCommandParser()
        {

        }

        #region Master Parser
        [TestMethod]
        public void NullArgThrowsException()
        {
            string cmd = null;
            Assert.Throws<ArgumentException>(
                () => { commandParser.ParseCommand(cmd); },
                CommadParserErrorMsg.EmptyInput
            );
        }

        [TestMethod]
        public void EmptyArgThrowsException()
        {
            string cmd;

            cmd = "";
            Assert.Throws<ArgumentException>(
                () => { commandParser.ParseCommand(cmd); },
                CommadParserErrorMsg.EmptyInput
            );

            cmd = "   ";
            Assert.Throws<ArgumentException>(
                () => { commandParser.ParseCommand(cmd); },
                CommadParserErrorMsg.EmptyInput
            );
        }

        [TestMethod]
        public void InvalidCommandTypeThrowsException()
        {
            string cmdType = "Y", cmd;

            cmd = cmdType;
            Assert.Throws<InvalidCommandTypeException>(
                () => { commandParser.ParseCommand(cmd); },
                CommadParserErrorMsg.InvalidCommandType(cmdType)
            );

            cmd = cmdType + " 2 3";
            Assert.Throws<InvalidCommandTypeException>(
                () => { commandParser.ParseCommand(cmd); },
                CommadParserErrorMsg.InvalidCommandType(cmdType)
            );
        }
        #endregion Master Parser

        #region Canvas Command Parser
        [TestMethod]
        public void ValidCanvasCommand()
        {
            string cmd = "C 5 5";
            var command = commandParser.ParseCommand(cmd) as CanvasCommand;
            Assert.IsNotNull(command);
            Assert.AreEqual<int>(command.Args[0], 5);
            Assert.AreEqual<int>(command.Args[1], 5);
        }

        [TestMethod]
        public void InvalidCanvasCommandArgLengthThrowsException()
        {
            string cmd = "C 1";
            Assert.Throws<ArgumentException>(
                () => { commandParser.ParseCommand(cmd); },
                CommadParserErrorMsg.InvalidCommandArgLength("Canvas", 2, 1)
            );

            cmd = "C 1 2 3";
            Assert.Throws<ArgumentException>(
                () => { commandParser.ParseCommand(cmd); },
                CommadParserErrorMsg.InvalidCommandArgLength("Canvas", 2, 3)
            );
        }

        [TestMethod]
        public void InvalidCanvasCommandWidthArgThrowsException()
        {
            string cmd = "C w h";
            Assert.Throws<ArgumentException>(
                () => { commandParser.ParseCommand(cmd); },
                CommadParserErrorMsg.InvalidPosIntCommandArg("w")
            );
        }

        [TestMethod]
        public void InvalidCanvasCommandHeightArgThrowsException()
        {
            string cmd = "C 12 h";
            Assert.Throws<ArgumentException>(
                () => { commandParser.ParseCommand(cmd); },
                CommadParserErrorMsg.InvalidPosIntCommandArg("h")
            );
        }
        #endregion Cancas Command

        #region Line Command Parser
        [TestMethod]
        public void ValidLineCommand()
        {
            string cmd = "L 5 5 3 4";
            LineCommand command = commandParser.ParseCommand(cmd) as LineCommand;
            Assert.IsNotNull(command);
            Assert.AreEqual<int>(command.Args[0], 5);
            Assert.AreEqual<int>(command.Args[1], 5);
            Assert.AreEqual<int>(command.Args[2], 3);
            Assert.AreEqual<int>(command.Args[3], 4);
        }

        [TestMethod]
        public void InvalidLineCommandArgLengthThrowsException()
        {
            string cmd = "L 1";
            Assert.Throws<ArgumentException>(
                () => { commandParser.ParseCommand(cmd); },
                CommadParserErrorMsg.InvalidCommandArgLength("Line", 4, 1)
            );

            cmd = "L 1 2 3 4 5";
            Assert.Throws<ArgumentException>(
                () => { commandParser.ParseCommand(cmd); },
                CommadParserErrorMsg.InvalidCommandArgLength("Line", 4, 5)
            );
        }

        [TestMethod]
        public void InvalidLineCommandX1ArgThrowsException()
        {
            string cmd = "L x1 y1 x2 y2";
            Assert.Throws<ArgumentException>(
                () => { commandParser.ParseCommand(cmd); },
                CommadParserErrorMsg.InvalidNonNegativeIntCommandArg("x1")
            );
        }

        [TestMethod]
        public void InvalidLineCommandY1ArgThrowsException()
        {
            string cmd = "L 3 y1 x2 y2";
            Assert.Throws<ArgumentException>(
                () => { commandParser.ParseCommand(cmd); },
                CommadParserErrorMsg.InvalidNonNegativeIntCommandArg("y1")
            );
        }

        [TestMethod]
        public void InvalidLineCommandX2ArgThrowsException()
        {
            string cmd = "L 3 3 x2 y2";
            Assert.Throws<ArgumentException>(
                () => { commandParser.ParseCommand(cmd); },
                CommadParserErrorMsg.InvalidNonNegativeIntCommandArg("x2")
            );
        }

        [TestMethod]
        public void InvalidLineCommandY2ArgThrowsException()
        {
            string cmd = "L 3 3 5 y2";
            Assert.Throws<ArgumentException>(
                () => { commandParser.ParseCommand(cmd); },
                CommadParserErrorMsg.InvalidNonNegativeIntCommandArg("y2")
            );
        }
        #endregion Line Command Parser

        #region Rectangle Command Parser
        [TestMethod]
        public void ValidRectangleCommand()
        {
            string cmd = "R 5 5 3 4";
            RectangleCommand command = commandParser.ParseCommand(cmd) as RectangleCommand;
            Assert.IsNotNull(command);
            Assert.AreEqual<int>(command.Args[0], 5);
            Assert.AreEqual<int>(command.Args[1], 5);
            Assert.AreEqual<int>(command.Args[2], 3);
            Assert.AreEqual<int>(command.Args[3], 4);
        }

        [TestMethod]
        public void InvalidRectangleCommandArgLengthThrowsException()
        {
            string cmd = "R 1";
            Assert.Throws<ArgumentException>(
                () => { commandParser.ParseCommand(cmd); },
                CommadParserErrorMsg.InvalidCommandArgLength("Rectangle", 4, 1)
            );

            cmd = "R 1 2 3 4 5";
            Assert.Throws<ArgumentException>(
                () => { commandParser.ParseCommand(cmd); },
                CommadParserErrorMsg.InvalidCommandArgLength("Rectangle", 4, 5)
            );
        }

        [TestMethod]
        public void InvalidRectangleCommandX1ArgThrowsException()
        {
            string cmd = "R x1 y1 x2 y2";
            Assert.Throws<ArgumentException>(
                () => { commandParser.ParseCommand(cmd); },
                CommadParserErrorMsg.InvalidNonNegativeIntCommandArg("x1")
            );
        }

        [TestMethod]
        public void InvalidRectangleCommandY1ArgThrowsException()
        {
            string cmd = "R 3 y1 x2 y2";
            Assert.Throws<ArgumentException>(
                () => { commandParser.ParseCommand(cmd); },
                CommadParserErrorMsg.InvalidNonNegativeIntCommandArg("y1")
            );
        }

        [TestMethod]
        public void InvalidRectangleCommandX2ArgThrowsException()
        {
            string cmd = "R 3 3 x2 y2";
            Assert.Throws<ArgumentException>(
                () => { commandParser.ParseCommand(cmd); },
                CommadParserErrorMsg.InvalidNonNegativeIntCommandArg("x2")
            );
        }

        [TestMethod]
        public void InvalidRectangleCommandY2ArgThrowsException()
        {
            string cmd = "R 3 3 5 y2";
            Assert.Throws<ArgumentException>(
                () => { commandParser.ParseCommand(cmd); },
                CommadParserErrorMsg.InvalidNonNegativeIntCommandArg("y2")
            );
        }
        #endregion Rectangle Command Parser

        #region Fill Command Parser
        [TestMethod]
        public void ValidFillCommand()
        {
            string cmd = "B 5 5 c";
            FillCommand command = commandParser.ParseCommand(cmd) as FillCommand;
            Assert.IsNotNull(command);
            Assert.AreEqual<int>(command.FillCommandArgs.X, 5);
            Assert.AreEqual<int>(command.FillCommandArgs.Y, 5);
            Assert.AreEqual<char>(command.FillCommandArgs.Color, 'c');
        }

        [TestMethod]
        public void InvalidFillCommandArgLengthThrowsException()
        {
            string cmd = "B 1";
            Assert.Throws<ArgumentException>(
                () => { commandParser.ParseCommand(cmd); },
                CommadParserErrorMsg.InvalidCommandArgLength("Fill", 3, 1)
            );

            cmd = "B 1 2 3 4";
            Assert.Throws<ArgumentException>(
                () => { commandParser.ParseCommand(cmd); },
                CommadParserErrorMsg.InvalidCommandArgLength("Fill", 3, 4)
            );
        }

        [TestMethod]
        public void InvalidFillCommandXArgThrowsException()
        {
            string cmd = "B x y c";
            Assert.Throws<ArgumentException>(
                () => { commandParser.ParseCommand(cmd); },
                CommadParserErrorMsg.InvalidNonNegativeIntCommandArg("x")
            );
        }

        [TestMethod]
        public void InvalidFillCommandYArgThrowsException()
        {
            string cmd = "B 5 y c";
            Assert.Throws<ArgumentException>(
                () => { commandParser.ParseCommand(cmd); },
                CommadParserErrorMsg.InvalidNonNegativeIntCommandArg("y")
            );
        }

        [TestMethod]
        public void InvalidFillCommandColorArgThrowsException()
        {
            string cmd = "B 5 5 cc";
            Assert.Throws<ArgumentException>(
                () => { commandParser.ParseCommand(cmd); },
                CommadParserErrorMsg.InvalidCharCommandArg("cc")
            );
        }
        #endregion Fill Command Parser
    }
}
