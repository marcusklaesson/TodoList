
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace TodoList
{
    public class ToDoListViewModel: BaseFodyObservable
    {

        public ToDoListViewModel()
        {
            GroupedTodoList = GetGroupedTodoList();
            Delete = new Command<TodoItem>(HandleDelete);
            ChangeIsCompleted = new Command<TodoItem>(HandleChangeIsCompleted);
        }
        public ILookup<string, TodoItem> GroupedTodoList { get; set; }
        public string Title => "My Todo List";
        
        public Command<TodoItem> Delete { get; set; }

        public void HandleDelete(TodoItem itemToDelete)
        {
            _todoList.Remove(itemToDelete);
            GroupedTodoList = GetGroupedTodoList();
        }
        public Command<TodoItem> ChangeIsCompleted { get; set; }

        public void HandleChangeIsCompleted(TodoItem itemToUpdate)
        {
            itemToUpdate.isCompleted = !itemToUpdate.isCompleted;
            GroupedTodoList = GetGroupedTodoList();
        }

        private List<TodoItem> _todoList = new List<TodoItem>
        {
            new TodoItem {Id = 0, Title = "Tjena", isCompleted = true},
            new TodoItem {Id = 1, Title = "test1"},
            new TodoItem {Id = 2, Title = "test2"}
        };

        private ILookup<string, TodoItem> GetGroupedTodoList()
        {
            return _todoList.OrderBy(t => t.isCompleted)
                .ToLookup(t => t.isCompleted? "Completed" : "Active");
        }
    }
}