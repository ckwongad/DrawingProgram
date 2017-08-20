using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingProgram.Canvas;
using MSTestExtensions;
using DrawingProgram.Printer;

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

            int outerWidth = width + 2;
            int outerHeight = height + 2;

            simpleCanvas.CreateCanvas(new int[] { width, height });
            var grid = simpleCanvas.Grid;

            Assert.AreEqual<int>(outerWidth, grid.GetLength(0));
            Assert.AreEqual<int>(outerHeight, grid.GetLength(1));
            for (int x = 0; x < outerWidth; x++)
            {
                Assert.AreEqual<char>('-', grid[x, 0]);
                Assert.AreEqual<char>('-', grid[x, outerHeight - 1]);
            }
            for (int y = 1; y < outerHeight - 1; y++)
            {
                Assert.AreEqual<char>('|', grid[0, y]);
                Assert.AreEqual<char>('|', grid[outerWidth - 1, y]);
            }
        }

        [TestMethod]
        public void CanvasPrintSuccess()
        {
            int width = 2;
            int height = 3;

            int outerWidth = width + 2;
            int outerHeight = height + 2;

            simpleCanvas.CreateCanvas(new int[] { width, height });
            simpleCanvas.Print();

            Assert.AreEqual<string>("----\r\n|\0\0|\r\n|\0\0|\r\n|\0\0|\r\n----\r\n", printer.ToString());


        }
    }
}
