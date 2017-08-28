using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DrawingProgram.Canvas;
using DrawingProgram.Command;
using DrawingProgram.Command.CommandArgs;

namespace DrawingProgramTest
{
    [TestClass]
    public class CommandTest
    {
        [TestMethod]
        public void CanvasCommand_ExcuteShouldCallCreateCanvas()
        {
            var mock = new Mock<ICanvas>();

            var createCanvasArgs = new int[] { 5, 5 };
            //mock.Setup(_canvas => _canvas.CreateCanvas(createCanvasArgs));

            var canvas = mock.Object;
            var canvasCommand = new CanvasCommand(canvas, createCanvasArgs);
            canvasCommand.Execute();

            mock.Verify(_canvas => _canvas.CreateCanvas(createCanvasArgs), Times.Once);
        }

        [TestMethod]
        public void LineCommand_ExcuteShouldCallDrawLine()
        {
            var mock = new Mock<ICanvas>();

            var drawLineArgs = new int[] { 5, 5, 5, 7 };
            //mock.Setup(_canvas => _canvas.DrawLine(drawLineArgs));

            var canvas = mock.Object;
            var canvasCommand = new LineCommand(canvas, drawLineArgs);
            canvasCommand.Execute();

            mock.Verify(_canvas => _canvas.DrawLine(drawLineArgs), Times.Once);
        }

        [TestMethod]
        public void RectangleCommand_ExcuteShouldCallDrawRectrangle()
        {
            var mock = new Mock<ICanvas>();

            var drawRectangleArgs = new int[] { 5, 5, 8, 9 };
            //mock.Setup(_canvas => _canvas.DrawRectangle(drawRectangleArgs));

            var canvas = mock.Object;
            var canvasCommand = new RectangleCommand(canvas, drawRectangleArgs);
            canvasCommand.Execute();

            mock.Verify(_canvas => _canvas.DrawRectangle(drawRectangleArgs), Times.Once);
        }

        [TestMethod]
        public void FillCommand_ExcuteShouldCallFill()
        {
            var mock = new Mock<ICanvas>();

            var fillArgs = new FillCommandArgs(5, 5, 'c');
            //mock.Setup(_canvas => _canvas.Fill(fillArgs));

            var canvas = mock.Object;
            var canvasCommand = new FillCommand(canvas, fillArgs);
            canvasCommand.Execute();

            mock.Verify(_canvas => _canvas.Fill(fillArgs), Times.Once);
        }
    }
}
