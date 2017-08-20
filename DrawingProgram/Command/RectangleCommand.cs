using DrawingProgram.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram.Command
{
    public class RectangleCommand : ICommand
    {
        protected SimpleCanvas _canvas;
        public int[] Args { get; set; }

        public RectangleCommand(SimpleCanvas canvas)
        {
            _canvas = canvas;
        }

        public RectangleCommand(SimpleCanvas canvas, int[] args)
        {
            _canvas = canvas;
            Args = args;
        }

        public void Execute()
        {
            _canvas.DrawRectangle(Args);
        }
    }
}
