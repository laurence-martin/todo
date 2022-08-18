using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests
{
    public class MarkTodoAsUndoneHandlerTests
    {
        private readonly MarkTodoAsUndoneCommand _invalidCommand = new MarkTodoAsUndoneCommand(Guid.NewGuid(), "");
        private readonly MarkTodoAsUndoneCommand _validCommand = new MarkTodoAsUndoneCommand(Guid.NewGuid(), "laurence");
        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());

        [TestMethod]
        public void Dado_um_comando_invalido_deve_interromper_a_execucao()
        {
            var result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.IsFalse(result.Success);
        }
        [TestMethod]
        public void Dado_um_comando_valido_deve_atualizar_o_titulo_da_tarefa()
        {
            var result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.IsTrue(result.Success);
        }
    }
}
