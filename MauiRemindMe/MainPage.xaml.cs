using MauiRemindMe.Views;

namespace MauiRemindMe
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }


        //private async void Button_Clicked(object sender, EventArgs e)
        //{
        //    Button btn = sender as Button;
        //    ContentPage p = null;
        //    switch (btn.Text)
        //    {
        //        case "Day":
        //            p = new MainPage();
        //            await App.Current.MainPage.Navigation.PushAsync(p);
        //            break;
        //        case "Week":
        //            p = new WeekMainPage();
        //            await App.Current.MainPage.Navigation.PushAsync(p);
        //            break;
        //        case "Admin":
        //            p = new AdminUserList();
        //            await App.Current.MainPage.Navigation.PushAsync(p);
        //            break;
        //        //case "AddNotificationPage Btn":
        //        //    p = new AddNotification();
        //        //    await App.Current.MainPage.Navigation.PushAsync(p);
        //        //    break;
        //        default:
        //            await DisplayAlert("The is nothing to do here", "Ther is nothing here", "Enter");
        //            break;
        //    }
        //    //        case "LoginPage Btn":
        //    //            p = new LoginPage();
        //    //            await App.Current.MainPage.Navigation.PushAsync(p);
        //    //            break;
        //    //        case "MyProfile Btn":
        //    //            p = new MyProfile();
        //    //            await App.Current.MainPage.Navigation.PushAsync(p);
        //    //            break;
        //    //        case "OpenPage Btn":
        //    //            p = new OpenPage();
        //    //            await App.Current.MainPage.Navigation.PushAsync(p);
        //    //            break;
        //    //        case "RegisterPage Btn":
        //    //            p = new RegisterPage();
        //    //            await App.Current.MainPage.Navigation.PushAsync(p);
        //    //            break;
        //    //        case "SearchDate Btn":
        //    //            p = new SearchDate();
        //    //            await App.Current.MainPage.Navigation.PushAsync(p);
        //    //            break;

        //    //}
        //}
    }
}
