using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {
        public CreateTodoHandlerTests()
        {

        }

        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Tarefa 01", "Laurence", DateTime.Now);
        private TodoHandler _todoHandler = new TodoHandler(new FakeTodoRepository());
        private GenericCommandResult _result = new GenericCommandResult();
        [TestMethod]
        public void Dado_um_comando_invalido_interromper_a_execucao()
        {
            _result = (GenericCommandResult)_todoHandler.Handle(_invalidCommand);
            Assert.IsFalse(_result.Success);
        }
        [TestMethod]
        public void Dado_um_comando_valido_deve_criar_a_tarefa()
        {
            _result = (GenericCommandResult)_todoHandler.Handle(_validCommand);
            Assert.IsTrue(_result.Success);
        }
    }
}
