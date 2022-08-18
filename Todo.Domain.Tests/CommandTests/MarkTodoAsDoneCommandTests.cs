using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests
{
    public class MarkTodoAsDoneCommandTests
    {
        private readonly MarkTodoAsDoneCommand _invalidCommand = new MarkTodoAsDoneCommand(Guid.NewGuid(),"");
        private readonly MarkTodoAsDoneCommand _validCommand = new MarkTodoAsDoneCommand(Guid.NewGuid(), "laurence");

        [TestMethod]
        public void Dado_um_commando_invalido()
        {
            _invalidCommand.Validate();
            Assert.IsTrue(_invalidCommand.Invalid);
        }
        [TestMethod]
        public void Dado_um_commando_valido()
        {
            _validCommand.Validate();
            Assert.IsTrue(_validCommand.Valid);
        }
    }
}
