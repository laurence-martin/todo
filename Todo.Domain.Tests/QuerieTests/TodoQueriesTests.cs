using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QuerieTests
{
    [TestClass]
    public class TodoQueriesTests
    {
        private List<TodoItem> _items;
        public TodoQueriesTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 01", DateTime.Now, "laurence"));
            _items.Add(new TodoItem("Tarefa 02", DateTime.Now, "marcos"));
            _items.Add(new TodoItem("Tarefa 03", DateTime.Now, "laurence"));
            _items.Add(new TodoItem("Tarefa 04", DateTime.Now, "marcos"));
            _items.Add(new TodoItem("Tarefa 01", DateTime.Now, "marcos"));
        }
        [TestMethod]
        public void Dada_a_consulta_deve_retornar_todas_as_tarefas_do_usuario_laurence()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("laurence"));
            Assert.AreEqual(result.Count(), 2);
        }
        [TestMethod]
        public void Dada_a_consulta_deve_retornar_todas_as_tarefas_do_usuario_laurence_marcaddas_como_done()
        {
            foreach (var item in _items)
            {
                item.MarkAsDone();
            }
            var result = _items.AsQueryable().Where(TodoQueries.GetAllDone("laurence"));
            Assert.AreEqual(result.Count(), 2);
        }
        [TestMethod]
        public void Dada_a_consulta_deve_retornar_todas_as_tarefas_do_usuario_laurence_marcaddas_como_undone()
        {
            foreach (var item in _items)
            {
                item.MarkAsUndone();
            }
            var result = _items.AsQueryable().Where(TodoQueries.GetAllUndone("laurence"));
            Assert.AreEqual(result.Count(), 2);
        }
        [TestMethod]
        public void Dada_a_consulta_deve_retornar_todas_as_tarefas_do_usuario_laurence_da_data_atual_marcaddas_como_done()
        {
            foreach (var item in _items)
            {
                item.MarkAsDone();
            }
            var result = _items.AsQueryable().Where(TodoQueries.GetByPeriod("laurence", DateTime.Now.Date, true));
            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_todas_as_tarefas_do_usuario_laurence_da_data_atual_marcaddas_como_undone()
        {
            foreach (var item in _items)
            {
                item.MarkAsUndone();
            }
            var result = _items.AsQueryable().Where(TodoQueries.GetByPeriod("laurence", DateTime.Now.Date, false));
            Assert.AreEqual(result.Count(), 2);
        }
        [TestMethod]
        public void Dada_a_consulta_deve_retornar_a_tarefa_do_usuario_laurence_com_o_id_especificado()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetById("laurence", Guid.NewGuid()));
            Assert.AreEqual(result.Count(), 0);
        }
    }
}
