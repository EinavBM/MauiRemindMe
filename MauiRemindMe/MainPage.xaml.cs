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
          //  await Navigation.PushAsync(new LoginPage());
        }

        private async void OnRegisterPageClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("/RegisterPage");
        }

        //private async void OnAddNotificationClicked (object sender, EventArgs e)
        //{
        //    await Shell.Current.GoToAsync("///AddNotification");
        //}

        //private async void OnNotificationListPageClicked(object sender, EventArgs e)
        //{
        //    await Shell.Current.GoToAsync("///NotificationListPage");
        //}

        //private async void OnRegisterListPageClicked(object sender, EventArgs e)
        //{
        //    await Shell.Current.GoToAsync("///RegisterListPage");
        //}



        //Button btn = sender as Button;
        //ContentPage p = null;
        //switch (btn.Text)
        //{
        //    case "Day":
        //        p = new MainPage();
        //        await App.Current.MainPage.Navigation.PushAsync(p);
        //        break;
        //    case "Week":
        //        p = new WeekMainPage();
        //        await App.Current.MainPage.Navigation.PushAsync(p);
        //        break;
        //    case "Admin":
        //        p = new AdminUserList();
        //        await App.Current.MainPage.Navigation.PushAsync(p);
        //        break;
        //case "AddNotificationPage Btn":
        //    p = new AddNotification();
        //    await App.Current.MainPage.Navigation.PushAsync(p);
        ////    break;
        //default:
        //        await DisplayAlert("The is nothing to do here", "Ther is nothing here", "Enter");
        ////        break;
        //}
        //        case "LoginPage Btn":
        //            p = new LoginPage();
        //            await App.Current.MainPage.Navigation.PushAsync(p);
        //            break;
        //        case "MyProfile Btn":
        //            p = new MyProfile();
        //            await App.Current.MainPage.Navigation.PushAsync(p);
        //            break;
        //        case "OpenPage Btn":
        //            p = new OpenPage();
        //            await App.Current.MainPage.Navigation.PushAsync(p);
        //            break;
        //        case "RegisterPage Btn":
        //            p = new RegisterPage();
        //            await App.Current.MainPage.Navigation.PushAsync(p);
        //            break;
        //        case "SearchDate Btn":
        //            p = new SearchDate();
        //            await App.Current.MainPage.Navigation.PushAsync(p);
        //            break;
        //}
    


    }
}
