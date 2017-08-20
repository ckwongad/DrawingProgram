using DrawingProgram.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram.Command
{
    public class CanvasCommand : ICommand
    {
        protected SimpleCanvas _canvas;
        public int[] Args { get; set; }

        public CanvasCommand(SimpleCanvas canvas)
        {
            _canvas = canvas;
        }

        public CanvasCommand(SimpleCanvas canvas, int[] args)
        {
            _canvas = canvas;
            Args = args;
        }

        public void Execute()
        {
            _canvas.CreateCanvas(Args);
        }
    }
}
