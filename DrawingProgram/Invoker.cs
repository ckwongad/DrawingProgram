using DrawingProgram.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram
{
    public class Invoker
    {
        public ICommand Command { get; set; }

        public void ExecuteCommand()
        {
            if (Command == null) throw new NullReferenceException("Command shouldn't be null");

            Command.Execute();
        }
    }
}
