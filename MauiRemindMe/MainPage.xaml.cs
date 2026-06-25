using MauiRemindMe.Views;
using MauiRemindMe.ViewsModels;

namespace MauiRemindMe
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }


        private async void OnLoginPageClicked(object sender, EventArgs e)
        { 
            await Shell.Current.GoToAsync("/LoginPage");
        }

        private async void OnRegisterPageClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("/RegisterPage");
        }
    }
}
