namespace TodoList
{
    public class TodoItem : BaseFodyObservable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool isCompleted { get; set; }
    }
}