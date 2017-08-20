using DrawingProgram.Command.CommandArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram.Canvas
{
    public class SimpleCanvas
    {
        private char[,] canvas;

        public void CreateCanvas(int[] args)
        {
            int outWidth = args[0] + 2;
            int outHeight = args[1] + 2;
            canvas = new char[outHeight, outWidth];
            for (int i = 0; i < outWidth; i++)
            {
                canvas[0, i] = '-';
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
    }
}
