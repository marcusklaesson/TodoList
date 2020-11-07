using TodoList.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace TodoList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoListView : ContentPage
    {
        public TodoListView ()
        {
            InitializeComponent ();
            BindingContext = new TodoListViewModel(Navigation);
            ThemeInfo.Text = $"The current app theme is {AppInfo.RequestedTheme}";
            Vibration.Vibrate();
        }

        protected override async void OnAppearing()
        {
            
            base.OnAppearing();
            await (BindingContext as TodoListViewModel).RefreshTaskList();
            Vibration.Vibrate();
        }
    }
}