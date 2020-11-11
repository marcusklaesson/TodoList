using TodoList.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoListView : ContentPage
    {
        public TodoListView ()
        {
            InitializeComponent ();
            BindingContext = new TodoListViewModel(Navigation);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await (BindingContext as TodoListViewModel).RefreshTaskList();
        }
    }
}