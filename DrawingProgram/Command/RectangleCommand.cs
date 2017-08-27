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
        protected ICanvas _canvas;
        public int[] Args { get; set; }

        public RectangleCommand(ICanvas canvas)
        {
            _canvas = canvas;
        }

        public RectangleCommand(ICanvas canvas, int[] args)
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
