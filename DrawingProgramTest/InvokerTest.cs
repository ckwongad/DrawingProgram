using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingProgram.Command;
using Moq;
using DrawingProgram;
using MSTestExtensions;

namespace DrawingProgramTest
{
    [TestClass]
    public class InvokerTest : BaseTest
    {
        [TestMethod]
        public void ExecuteNullCommandThrowsException()
        {
            var invoker = new Invoker();
            Assert.Throws<NullReferenceException>(() => { invoker.ExecuteCommand(); });
        }

        [TestMethod]
        public void CommandShouldExecuted()
        {
            var mock = new Mock<ICommand>();

            //mock.Setup(_command => _command.Execute());

            var command = mock.Object;
            var invoker = new Invoker();
            invoker.Command = command;
            invoker.ExecuteCommand();

            mock.Verify(_command => _command.Execute(), Times.Once);
        }
    }
}
