using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateTodoCommandTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Tarefa 01", "Laurence", DateTime.Now);

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