using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests
{
    public class MasrkTodoAsUndoneCommandTests
    {
        private readonly MarkTodoAsUndoneCommand _invalidCommand = new MarkTodoAsUndoneCommand(Guid.NewGuid(), "");
        private readonly MarkTodoAsUndoneCommand _validCommand = new MarkTodoAsUndoneCommand(Guid.NewGuid(), "laurence");

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
