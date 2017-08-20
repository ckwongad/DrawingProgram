using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram.Command.CommandArgs
{
    public class FillCommandArgs
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Color { get; set; }

        public FillCommandArgs(int x, int y, char color)
        {
            X = x;
            Y = y;
            Color = color;
        }
    }
}
