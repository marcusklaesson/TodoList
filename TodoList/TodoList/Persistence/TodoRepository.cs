using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Models;
using Xamarin.Forms;

namespace TodoList.Persistence
{
    public class TodoRepository
    {
        private readonly SQLiteAsyncConnection _database;

        public TodoRepository()
        {
            _database = new SQLiteAsyncConnection(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
            _database.CreateTableAsync<TodoItem>().Wait();            
        }

        private List<TodoItem> _seedTodoList = new List<TodoItem>
        {
            new TodoItem { Title = "Handla mat", IsCompleted = true},
            new TodoItem { Title = "Träna"},
            new TodoItem { Title = "Koda"},
        };

        public async Task<List<TodoItem>> GetList()
        {
            if ((await _database.Table<TodoItem>().CountAsync() == 0))
            {
                await _database.InsertAllAsync(_seedTodoList);
            }

            return await _database.Table<TodoItem>().ToListAsync();
        }

        public Task DeleteItem(TodoItem itemToDelete)
        {
            return _database.DeleteAsync(itemToDelete);
        }

        public Task ChangeItemIsCompleted(TodoItem itemToChange)
        {
            itemToChange.IsCompleted = !itemToChange.IsCompleted;
            return _database.UpdateAsync(itemToChange);
        }

        public Task AddItem(TodoItem itemToAdd)
        {
            return _database.InsertAsync(itemToAdd);
        }
    }
}