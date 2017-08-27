using DrawingProgram.Canvas;
using DrawingProgram.Command.CommandArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram.Command
{
    public class FillCommand : ICommand
    {
        protected ICanvas _canvas;
        public FillCommandArgs FillCommandArgs { get; set; }

        public FillCommand(ICanvas canvas)
        {
            _canvas = canvas;
        }

        public FillCommand(ICanvas canvas, FillCommandArgs args)
        {
            _canvas = canvas;
            FillCommandArgs = args;
        }

        public void Execute()
        {
            _canvas.Fill(FillCommandArgs);
        }
    }
}
