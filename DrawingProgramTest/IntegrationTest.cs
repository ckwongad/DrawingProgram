using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingProgram.Printer;
using DrawingProgram.Canvas;
using DrawingProgram.Parser;
using DrawingProgram;
using DrawingProgram.Command;

namespace DrawingProgramTest
{
    [TestClass]
    public class IntegrationTest
    {
        private StringPrinter printer;
        private ICanvas canvas;
        private CommandParser commandParser;
        private Invoker invoker;

        [TestInitialize]
        public void SetupSimpleCanvas()
        {
            printer = new StringPrinter();
            canvas = new SimpleCanvas(printer);
            commandParser = new CommandParser(canvas);
            invoker = new Invoker();
        }

        [TestMethod]
        public void IntegrationTest1()
        {
            var commandResultPairs = new Tuple<string, string>[]
            {
                new Tuple<string, string>("L 1 2 6 2", SimpleCanvasErrorMsg.CanvasNotCreated + Environment.NewLine),
                new Tuple<string, string>("C 20 4", "----------------------\r\n|\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0|\r\n|\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0|\r\n|\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0|\r\n|\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0|\r\n----------------------\r\n"),
                new Tuple<string, string>("L 1 2 6 2", "----------------------\r\n|\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0|\r\n|xxxxxx\0\0\0\0\0\0\0\0\0\0\0\0\0\0|\r\n|\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0|\r\n|\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0|\r\n----------------------\r\n"),
                new Tuple<string, string>("L 6 3 6 4", "----------------------\r\n|\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0|\r\n|xxxxxx\0\0\0\0\0\0\0\0\0\0\0\0\0\0|\r\n|\0\0\0\0\0x\0\0\0\0\0\0\0\0\0\0\0\0\0\0|\r\n|\0\0\0\0\0x\0\0\0\0\0\0\0\0\0\0\0\0\0\0|\r\n----------------------\r\n"),
                new Tuple<string, string>("R 14 1 18 3", "----------------------\r\n|\0\0\0\0\0\0\0\0\0\0\0\0\0xxxxx\0\0|\r\n|xxxxxx\0\0\0\0\0\0\0x\0\0\0x\0\0|\r\n|\0\0\0\0\0x\0\0\0\0\0\0\0xxxxx\0\0|\r\n|\0\0\0\0\0x\0\0\0\0\0\0\0\0\0\0\0\0\0\0|\r\n----------------------\r\n"),
                new Tuple<string, string>("B 10 3 o", "----------------------\r\n|oooooooooooooxxxxxoo|\r\n|xxxxxxooooooox\0\0\0xoo|\r\n|\0\0\0\0\0xoooooooxxxxxoo|\r\n|\0\0\0\0\0xoooooooooooooo|\r\n----------------------\r\n")
            };
            ICommand command;

            foreach (var commandResultPair in commandResultPairs)
            {
                try
                {
                    command = commandParser.ParseCommand(commandResultPair.Item1);
                    invoker.Command = command;
                    invoker.ExecuteCommand();
                    canvas.Print();
                }
                catch (Exception ex)
                {
                    printer.Write(ex.Message);
                    printer.NextLine();
                }

                Assert.AreEqual<String>(commandResultPair.Item2, printer.ToString());
                printer.Clear();
            }
        }
    }
}
