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

            int width = args[0];
            int height = args[1];
            Grid = new char[width, height];
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

            for (int x = 0; x < width + 2 ; x++)
            {
                printer.Write('-');
            }
            printer.NextLine();

            for (int y = 0; y < height; y++)
            {
                printer.Write('|');
                for (int x = 0; x < width; x++) {
                    printer.Write(Grid[x, y]);
                }
                printer.Write('|');
                printer.NextLine();
            }

            for (int x = 0; x < width + 2; x++)
            {
                printer.Write('-');
            }
            printer.NextLine();
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
