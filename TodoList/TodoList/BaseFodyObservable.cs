using System.ComponentModel;

namespace TodoList
{
    public abstract class BaseFodyObservable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}