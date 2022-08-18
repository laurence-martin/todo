using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class UpdateTodoCommandTests
    {
        private readonly UpdateTodoCommand _invalidCommand = new UpdateTodoCommand(Guid.NewGuid(), "", "");
        private readonly UpdateTodoCommand _validCommand = new UpdateTodoCommand(Guid.NewGuid(), "Tarefa 01", "laurence");

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
