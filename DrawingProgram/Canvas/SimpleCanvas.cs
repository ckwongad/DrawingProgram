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
        private char defaultCharToDraw = 'x';
        private readonly int[,] shifts = new int[,] { { -1, -1 }, { 0, -1 }, { 1, -1 },
                                                      { -1, 0 },            { 1, 0 },
                                                      { -1, 1 }, { 0, 1 }, { 1, 1 } };

        public char[,] Grid { get; set; }

        public SimpleCanvas(IPrinter _printer)
        {
            printer = _printer;
        }

        public void CreateCanvas(int[] args)
        {
            if (args.Length != 2) throw new ArgumentException();
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
            if (args.Length != 4) throw new ArgumentException();
            if (!isCanvasCreated()) throw new InvalidOperationException(SimpleCanvasErrorMsg.CanvasNotCreated);

            int x1 = args[0], y1 = args[1], x2 = args[2], y2 = args[3];
            assertXCoordinate(x1);
            assertYCoordinate(y1);
            assertXCoordinate(x2);
            assertYCoordinate(y2);
            if (x1 != x2 && y1 != y2) throw new ArgumentException(SimpleCanvasErrorMsg.NotVerticalOrHorizontal);

            var gridX1 = convertToGridCoordinate(x1);
            var gridY1 = convertToGridCoordinate(y1);
            var gridX2 = convertToGridCoordinate(x2);
            var gridY2 = convertToGridCoordinate(y2);

            if (gridX1 == gridX2)
            {
                // draw horizontal line
                var top = Math.Min(gridY1, gridY2);
                top = Math.Max(0, top);
                var bottom = Math.Max(gridY1, gridY2);
                bottom = Math.Min(getHeight() - 1, bottom);
                for (int y = top; y <= bottom; y++)
                {
                    Grid[gridX1, y] = defaultCharToDraw;
                }
            } else if (gridY1 == gridY2)
            {
                // draw vertical line
                var left = Math.Min(gridX1, gridX2);
                left = Math.Max(0, left);
                var right = Math.Max(gridX1, gridX2);
                right = Math.Min(getWidth() - 1, right);
                for (int x = left; x <= right; x++)
                {
                    Grid[x, gridY1] = defaultCharToDraw;
                }
            }
        }

        /*
         * it can also draw horizontal line or vertical line
        */
        public void DrawRectangle(int[] args)
        {
            if (args.Length != 4) throw new ArgumentException();
            if (!isCanvasCreated()) throw new InvalidOperationException(SimpleCanvasErrorMsg.CanvasNotCreated);

            int x1 = args[0], y1 = args[1], x2 = args[2], y2 = args[3];
            assertXCoordinate(x1);
            assertYCoordinate(y1);
            assertXCoordinate(x2);
            assertYCoordinate(y2);

            var gridX1 = convertToGridCoordinate(x1);
            var gridY1 = convertToGridCoordinate(y1);
            var gridX2 = convertToGridCoordinate(x2);
            var gridY2 = convertToGridCoordinate(y2);

            var leftX = Math.Min(gridX1, gridX2);
            var rightX = Math.Max(gridX1, gridX2);
            var leftY = Math.Min(gridY1, gridY2);
            var rightY = Math.Max(gridY1, gridY2);

            for (var x = leftX; x <= rightX; x++)
            {
                Grid[x, gridY1] = defaultCharToDraw;
                Grid[x, gridY2] = defaultCharToDraw;
            }
            for (var y = leftY + 1; y < rightY; y++)
            {
                Grid[gridX1, y] = defaultCharToDraw;
                Grid[gridX2, y] = defaultCharToDraw;
            }
        }

        public void Fill(FillCommandArgs fillCommandArgs)
        {
            if (!isCanvasCreated()) throw new InvalidOperationException(SimpleCanvasErrorMsg.CanvasNotCreated);
            assertXCoordinate(fillCommandArgs.X);
            assertYCoordinate(fillCommandArgs.Y);

            var gridX = convertToGridCoordinate(fillCommandArgs.X);
            var gridY = convertToGridCoordinate(fillCommandArgs.Y);
            var colorBeforeFill = Grid[gridX, gridY];
            if (colorBeforeFill == fillCommandArgs.Color) return;

            var cellsToFill = new List<Coordinate> { new Coordinate(gridX, gridY) };
            while (cellsToFill.Count > 0)
            {
                var newCellsToFill = new List<Coordinate>();
                foreach (var coordinate in cellsToFill)
                {
                    Grid[coordinate.x, coordinate.y] = fillCommandArgs.Color;
                    for (int i = 0; i < shifts.GetLength(0); i++)
                    {
                        var newX = coordinate.x + shifts[i, 0];
                        var newY = coordinate.y + shifts[i, 1];

                        if (isGridXCoordinateValid(newX)
                            && isGridYCoordinateValid(newY)
                            && Grid[newX, newY] == colorBeforeFill
                        )
                            newCellsToFill.Add(new Coordinate(newX, newY));
                    }
                }
                cellsToFill = newCellsToFill;
            }

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


        private bool isCanvasCreated()
        {
            return Grid != null;
        }

        private int getWidth()
        {
            return Grid.GetLength(0);
        }

        private int getHeight()
        {
            return Grid.GetLength(1);
        }

        private bool isXCoordinateValid(int x )
        {
            return x >= 1 && x <= getWidth();
        }

        private bool isGridXCoordinateValid(int x)
        {
            return x >= 0 && x < getWidth();
        }

        private void assertXCoordinate(int x)
        {
            if (!isXCoordinateValid(x))
                throw new ArgumentException(SimpleCanvasErrorMsg.XCoordinateOutOfCanvas(getWidth(), x));
        }

        private bool isYCoordinateValid(int y)
        {
            return y >= 1 && y <= getHeight();
        }

        private bool isGridYCoordinateValid(int y)
        {
            return y >= 0 && y < getHeight();
        }

        private void assertYCoordinate(int y)
        {
            if (!isYCoordinateValid(y))
                throw new ArgumentException(SimpleCanvasErrorMsg.YCoordinateOutOfCanvas(getHeight(), y));
        }

        private int convertToGridCoordinate(int p)
        {
            return p - 1;
        }


        protected struct Coordinate
        {
            public int x;
            public int y;

            public Coordinate(int p1, int p2)
            {
                x = p1;
                y = p2;
            }
        }
    }
}
