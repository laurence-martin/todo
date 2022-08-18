using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests
{
    [TestClass]
    public class TodoItemTests
    {
        public TodoItem _todo = new TodoItem("Tarefa 1", DateTime.Now.AddDays(5), "laurence");
        [TestMethod]
        public void WhenCreateATodoItemDoneMustBeFalse()
        {
            Assert.IsFalse(_todo.Done);
        }
        [TestMethod]
        public void WhenMarkTodoItemAsDoneTheResultMustBeDone()
        {
            _todo.MarkAsDone();
            Assert.IsTrue(_todo.Done);
        }
        [TestMethod]
        public void WhenMarkTodoItemAsUndoneTheResultMustBeUndon()
        {
            _todo.MarkAsUndone();
            Assert.IsFalse(_todo.Done);
        }
    }
}
