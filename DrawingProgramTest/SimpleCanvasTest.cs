using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingProgram.Canvas;
using MSTestExtensions;
using DrawingProgram.Printer;
using DrawingProgram.Command.CommandArgs;

namespace DrawingProgramTest
{
    [TestClass]
    public class SimpleCanvasTest : BaseTest
    {
        private SimpleCanvas simpleCanvas;
        private IPrinter printer;

        [TestInitialize]
        public void SetupSimpleCanvas()
        {
            printer = new StringPrinter();
            simpleCanvas = new SimpleCanvas(printer);
        }

        [TestMethod]
        public void CreateCanvasZeroWidthThrowsException()
        {
            int width = 0;
            int height = 1;

            Assert.Throws<ArgumentException>(
                () => { simpleCanvas.CreateCanvas(new int[] { width, height }); },
                SimpleCanvasErrorMsg.InvalidCreateCanvasArg(width)
            );
        }

        [TestMethod]
        public void CreateCanvasZeroHeightThrowsException()
        {
            int width = 1;
            int height = 0;

            Assert.Throws<ArgumentException>(
                () => { simpleCanvas.CreateCanvas(new int[] { width, height }); },
                SimpleCanvasErrorMsg.InvalidCreateCanvasArg(height)
            );
        }

        [TestMethod]
        public void CreateCanvasSuccess()
        {
            int width = 2;
            int height = 3;

            simpleCanvas.CreateCanvas(new int[] { width, height });
            var grid = simpleCanvas.Grid;

            Assert.IsNotNull(grid);
            Assert.AreEqual<int>(width, grid.GetLength(0));
            Assert.AreEqual<int>(height, grid.GetLength(1));
        }

        [TestMethod]
        public void CanvasPrintSuccess()
        {
            int width = 2;
            int height = 3;

            simpleCanvas.CreateCanvas(new int[] { width, height });
            simpleCanvas.Print();

            Assert.AreEqual<string>("----\r\n|\0\0|\r\n|\0\0|\r\n|\0\0|\r\n----\r\n", printer.ToString());
        }

        #region Draw Line
        [TestMethod]
        public void DrawLineBeforeCanvasCreatedThrowException()
        {
            Assert.Throws<InvalidOperationException>(
                () => { simpleCanvas.DrawLine(new int[] { 1, 2, 1, 2 }); },
                SimpleCanvasErrorMsg.CanvasNotCreated
            );
        }

        [TestMethod]
        public void DrawLineXCoordinateOutOfBoundThrowException()
        {
            int width = 2, height = 2;
            simpleCanvas.CreateCanvas(new int[] { width, height });

            Assert.Throws<ArgumentException>(
                () => { simpleCanvas.DrawLine(new int[] { 1, 2, 3, 2 }); },
                SimpleCanvasErrorMsg.XCoordinateOutOfCanvas(width, 3)
            );
            Assert.Throws<ArgumentException>(
                () => { simpleCanvas.DrawLine(new int[] { 5, 2, 1, 2 }); },
                SimpleCanvasErrorMsg.XCoordinateOutOfCanvas(width, 5)
            );
        }

        [TestMethod]
        public void DrawLineYCoordinateOutOfBoundThrowException()
        {
            int width = 3, height = 4;
            simpleCanvas.CreateCanvas(new int[] { width, height });

            Assert.Throws<ArgumentException>(
                () => { simpleCanvas.DrawLine(new int[] { 1, 2, 1, 5 }); },
                SimpleCanvasErrorMsg.YCoordinateOutOfCanvas(height, 5)
            );
            Assert.Throws<ArgumentException>(
                () => { simpleCanvas.DrawLine(new int[] { 3, 8, 3, 4 }); },
                SimpleCanvasErrorMsg.YCoordinateOutOfCanvas(height, 8)
            );
        }

        [TestMethod]
        public void DrawDiagonalLineThrowException()
        {
            int width = 3, height = 4;
            simpleCanvas.CreateCanvas(new int[] { width, height });

            Assert.Throws<ArgumentException>(
                () => { simpleCanvas.DrawLine(new int[] { 1, 2, 3, 4 }); },
                SimpleCanvasErrorMsg.NotVerticalOrHorizontal
            );
        }

        [TestMethod]
        public void DrawVertivalLineLeftToRightSuccess()
        {
            int width = 4, height = 4;
            simpleCanvas.CreateCanvas(new int[] { width, height });

            simpleCanvas.DrawLine(new int[] { 2, 1, 2, 3 });
            simpleCanvas.Print();

            Assert.AreEqual<string>("------\r\n|\0x\0\0|\r\n|\0x\0\0|\r\n|\0x\0\0|\r\n|\0\0\0\0|\r\n------\r\n", printer.ToString());
        }

        [TestMethod]
        public void DrawVerticalLineRightToLeftSuccess()
        {
            int width = 4, height = 4;
            simpleCanvas.CreateCanvas(new int[] { width, height });

            simpleCanvas.DrawLine(new int[] { 2, 3, 2, 1 });
            simpleCanvas.Print();

            Assert.AreEqual<string>("------\r\n|\0x\0\0|\r\n|\0x\0\0|\r\n|\0x\0\0|\r\n|\0\0\0\0|\r\n------\r\n", printer.ToString());
        }

        [TestMethod]
        public void DrawHorizontalLineTopToBottomSuccess()
        {
            int width = 4, height = 4;
            simpleCanvas.CreateCanvas(new int[] { width, height });

            simpleCanvas.DrawLine(new int[] { 2, 3, 4, 3 });
            simpleCanvas.Print();

            Assert.AreEqual<string>("------\r\n|\0\0\0\0|\r\n|\0\0\0\0|\r\n|\0xxx|\r\n|\0\0\0\0|\r\n------\r\n", printer.ToString());
        }

        [TestMethod]
        public void DrawHorizontalLineBottomToTopSuccess()
        {
            int width = 4, height = 4;
            simpleCanvas.CreateCanvas(new int[] { width, height });

            simpleCanvas.DrawLine(new int[] { 4, 3, 2, 3 });
            simpleCanvas.Print();

            Assert.AreEqual<string>("------\r\n|\0\0\0\0|\r\n|\0\0\0\0|\r\n|\0xxx|\r\n|\0\0\0\0|\r\n------\r\n", printer.ToString());
        }
        #endregion Draw Line

        #region Draw Rectangle
        [TestMethod]
        public void DrawRectangleBeforeCanvasCreatedThrowException()
        {
            Assert.Throws<InvalidOperationException>(
                () => { simpleCanvas.DrawRectangle(new int[] { 2, 3, 2, 3 }); },
                SimpleCanvasErrorMsg.CanvasNotCreated
            );
        }

        [TestMethod]
        public void DrawRectangleXCoordinateOutOfBoundThrowException()
        {
            int width = 2, height = 2;
            simpleCanvas.CreateCanvas(new int[] { width, height });

            Assert.Throws<ArgumentException>(
                () => { simpleCanvas.DrawRectangle(new int[] { 1, 2, 3, 2 }); },
                SimpleCanvasErrorMsg.XCoordinateOutOfCanvas(width, 3)
            );
            Assert.Throws<ArgumentException>(
                () => { simpleCanvas.DrawRectangle(new int[] { 5, 2, 1, 2 }); },
                SimpleCanvasErrorMsg.XCoordinateOutOfCanvas(width, 5)
            );
        }

        [TestMethod]
        public void DrawRectangleYCoordinateOutOfBoundThrowException()
        {
            int width = 2, height = 2;
            simpleCanvas.CreateCanvas(new int[] { width, height });

            Assert.Throws<ArgumentException>(
                () => { simpleCanvas.DrawRectangle(new int[] { 1, 2, 2, 3 }); },
                SimpleCanvasErrorMsg.YCoordinateOutOfCanvas(height, 3)
            );
            Assert.Throws<ArgumentException>(
                () => { simpleCanvas.DrawRectangle(new int[] { 2, 5, 1, 2 }); },
                SimpleCanvasErrorMsg.YCoordinateOutOfCanvas(height, 5)
            );
        }

        [TestMethod]
        public void UseDrawRetangleToDrawVerticalLineTopToBottomSuccess()
        {
            int width = 4, height = 4;
            simpleCanvas.CreateCanvas(new int[] { width, height });

            simpleCanvas.DrawRectangle(new int[] { 2, 1, 2, 3 });
            simpleCanvas.Print();

            Assert.AreEqual<string>("------\r\n|\0x\0\0|\r\n|\0x\0\0|\r\n|\0x\0\0|\r\n|\0\0\0\0|\r\n------\r\n", printer.ToString());
        }

        public void UseDrawRetangleToDrawVerticalLineBottomToTopSuccess()
        {
            int width = 4, height = 4;
            simpleCanvas.CreateCanvas(new int[] { width, height });

            simpleCanvas.DrawRectangle(new int[] { 2, 3, 2, 1 });
            simpleCanvas.Print();

            Assert.AreEqual<string>("------\r\n|\0x\0\0|\r\n|\0x\0\0|\r\n|\0x\0\0|\r\n|\0\0\0\0|\r\n------\r\n", printer.ToString());
        }

        [TestMethod]
        public void UseDrawRetangleToDrawHorizontalLineLeftToRightSuccess()
        {
            int width = 4, height = 4;
            simpleCanvas.CreateCanvas(new int[] { width, height });

            simpleCanvas.DrawRectangle(new int[] { 2, 3, 4, 3 });
            simpleCanvas.Print();

            Assert.AreEqual<string>("------\r\n|\0\0\0\0|\r\n|\0\0\0\0|\r\n|\0xxx|\r\n|\0\0\0\0|\r\n------\r\n", printer.ToString());
        }

        [TestMethod]
        public void UseDrawRetangleToDrawHorizontalLineRightToLeftSuccess()
        {
            int width = 4, height = 4;
            simpleCanvas.CreateCanvas(new int[] { width, height });

            simpleCanvas.DrawRectangle(new int[] { 4, 3, 2, 3});
            simpleCanvas.Print();

            Assert.AreEqual<string>("------\r\n|\0\0\0\0|\r\n|\0\0\0\0|\r\n|\0xxx|\r\n|\0\0\0\0|\r\n------\r\n", printer.ToString());
        }

        [TestMethod]
        public void DrawRetangleToTopLeftSuccess()
        {
            int width = 4, height = 4;
            simpleCanvas.CreateCanvas(new int[] { width, height });

            simpleCanvas.DrawRectangle(new int[] { 4, 4, 2, 2 });
            simpleCanvas.Print();

            Assert.AreEqual<string>("------\r\n|\0\0\0\0|\r\n|\0xxx|\r\n|\0x\0x|\r\n|\0xxx|\r\n------\r\n", printer.ToString());
        }

        [TestMethod]
        public void DrawRetangleToTopRightSuccess()
        {
            int width = 4, height = 4;
            simpleCanvas.CreateCanvas(new int[] { width, height });

            simpleCanvas.DrawRectangle(new int[] { 2, 4, 4, 2 });
            simpleCanvas.Print();

            Assert.AreEqual<string>("------\r\n|\0\0\0\0|\r\n|\0xxx|\r\n|\0x\0x|\r\n|\0xxx|\r\n------\r\n", printer.ToString());
        }

        [TestMethod]
        public void DrawRetangleToBottomRightSuccess()
        {
            int width = 4, height = 4;
            simpleCanvas.CreateCanvas(new int[] { width, height });

            simpleCanvas.DrawRectangle(new int[] { 2, 2, 4, 4 });
            simpleCanvas.Print();

            Assert.AreEqual<string>("------\r\n|\0\0\0\0|\r\n|\0xxx|\r\n|\0x\0x|\r\n|\0xxx|\r\n------\r\n", printer.ToString());
        }

        [TestMethod]
        public void DrawRetangleToBottomLeftSuccess()
        {
            int width = 4, height = 4;
            simpleCanvas.CreateCanvas(new int[] { width, height });

            simpleCanvas.DrawRectangle(new int[] { 4, 2, 2, 4 });
            simpleCanvas.Print();

            Assert.AreEqual<string>("------\r\n|\0\0\0\0|\r\n|\0xxx|\r\n|\0x\0x|\r\n|\0xxx|\r\n------\r\n", printer.ToString());
        }
        #endregion Draw Rectangle

        #region Fill
        [TestMethod]
        public void FillBeforeCanvasCreatedThrowException()
        {
            var fillCommandArgs = new FillCommandArgs(1, 1, 'c');
            Assert.Throws<InvalidOperationException>(
                () => { simpleCanvas.Fill(fillCommandArgs); },
                SimpleCanvasErrorMsg.CanvasNotCreated
            );
        }

        [TestMethod]
        public void FillXCoordinateOutOfBoundThrowException()
        {
            int width = 2, height = 2;
            simpleCanvas.CreateCanvas(new int[] { width, height });
            var fillCommandArgs = new FillCommandArgs(3, 1, 'c');

            Assert.Throws<ArgumentException>(
                () => { simpleCanvas.Fill(fillCommandArgs); },
                SimpleCanvasErrorMsg.XCoordinateOutOfCanvas(width, 3)
            );
        }

        [TestMethod]
        public void FillYCoordinateOutOfBoundThrowException()
        {
            int width = 2, height = 2;
            simpleCanvas.CreateCanvas(new int[] { width, height });
            var fillCommandArgs = new FillCommandArgs(1, 4, 'c');

            Assert.Throws<ArgumentException>(
                () => { simpleCanvas.Fill(fillCommandArgs); },
                SimpleCanvasErrorMsg.YCoordinateOutOfCanvas(width, 4)
            );
        }

        [TestMethod]
        public void FillWholeCanvasSuccess()
        {
            int width = 2, height = 2;
            simpleCanvas.CreateCanvas(new int[] { width, height });
            var fillCommandArgs = new FillCommandArgs(1, 1, 'c');
            simpleCanvas.Fill(fillCommandArgs);
            simpleCanvas.Print();

            Assert.AreEqual<string>("----\r\n|cc|\r\n|cc|\r\n----\r\n", printer.ToString());
        }

        [TestMethod]
        public void FillInsideRectangleSuccess()
        {
            int width = 4, height = 4;
            simpleCanvas.CreateCanvas(new int[] { width, height });
            simpleCanvas.DrawRectangle(new int[] { 1, 1, 4, 4 });
            var fillCommandArgs = new FillCommandArgs(3, 3, 'a');
            simpleCanvas.Fill(fillCommandArgs);
            simpleCanvas.Print();

            Assert.AreEqual<string>("------\r\n|xxxx|\r\n|xaax|\r\n|xaax|\r\n|xxxx|\r\n------\r\n", printer.ToString());
        }

        [TestMethod]
        public void FillOutsideRectangleSuccess()
        {
            int width = 6, height = 6;
            simpleCanvas.CreateCanvas(new int[] { width, height });
            simpleCanvas.DrawRectangle(new int[] { 3, 2, 5, 4 });
            var fillCommandArgs = new FillCommandArgs(2, 2, 'f');
            simpleCanvas.Fill(fillCommandArgs);
            simpleCanvas.Print();

            Assert.AreEqual<string>("--------\r\n|ffffff|\r\n|ffxxxf|\r\n|ffx\0xf|\r\n|ffxxxf|\r\n|ffffff|\r\n|ffffff|\r\n--------\r\n", printer.ToString());
        }
        #endregion Fill
    }
}
