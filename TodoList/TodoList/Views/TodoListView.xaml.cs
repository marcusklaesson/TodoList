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
           
            if (Device.RuntimePlatform == Device.Android)
            {
                PlatformX.Text = "You are using an android mobile";
                var image = new Image { Source = "@Images/tododroid.png" };
                //image.Source = Device.RuntimePlatform;
                // ImageSource.FromFile("@Images/tododroid");
                
                 
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                PlatformX.Text = "You are using an ios mobile";
                var image = new Image { Source = "@Images/todoios.png" };
                //image.Source = Device.RuntimePlatform;
                // ImageSource.FromFile("@Images/todoios.png");

            }
        }
        public string SomeImage
        {
            get { return string.Format("@Images/tododroid.png"); }
        }

        protected override async void OnAppearing()
        {
            
            base.OnAppearing();
            await (BindingContext as TodoListViewModel).RefreshTaskList();
            Vibration.Vibrate();
        }
    }
}