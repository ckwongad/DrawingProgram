using DrawingProgram.Command.CommandArgs;
using DrawingProgram.Printer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram.Canvas
{
    public class SimpleCanvas
    {
        private IPrinter printer;
        public char[,] Grid { get; set; }

        public SimpleCanvas(IPrinter _printer)
        {
            printer = _printer;
        }

        public void CreateCanvas(int[] args)
        {
            if (args[0] < 1)
                throw new ArgumentException(SimpleCanvasErrorMsg.InvalidCreateCanvasArg(args[0]));
            if (args[1] < 1)
                throw new ArgumentException(SimpleCanvasErrorMsg.InvalidCreateCanvasArg(args[1]));

            int outerWidth = args[0] + 2;
            int outerHeight = args[1] + 2;
            Grid = new char[outerWidth, outerHeight];
            for (int x = 0; x < outerWidth; x++)
            {
                Grid[x, 0] = '-';
                Grid[x, outerHeight - 1] = '-';
            }
            for (int y = 1; y < outerHeight -1 ; y++)
            {
                Grid[0, y] = '|';
                Grid[outerWidth - 1, y] = '|';
            }
        }

        public void DrawLine(int[] args)
        {

        }

        public void DrawRectangle(int[] args)
        {

        }

        public void Fill(FillCommandArgs args)
        {

        }

        public void Print()
        {
            var width = getWidth();
            var height = getHeight();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++) {
                    printer.Write(Grid[x, y]);
                }
                printer.NextLine();
            }
        }

        private int getWidth()
        {
            return Grid.GetLength(0);
        }

        private int getHeight()
        {
            return Grid.GetLength(1);
        }
    }
}
