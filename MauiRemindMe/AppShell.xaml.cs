using MauiRemindMe.Views;

namespace MauiRemindMe
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
           //Routing.RegisterRoute(nameof(AddAndEditNotification), typeof(AddAndEditNotification));
            Routing.RegisterRoute("/mainpage", typeof(MainPage));
            Routing.RegisterRoute("/registerpage", typeof(RegisterPage));
            Routing.RegisterRoute("/loginpage", typeof(LoginPage));
            Routing.RegisterRoute("/logout", typeof(LogOutPage));
            Routing.RegisterRoute("/update", typeof(AddAndEditNotification));
          //  Routing.RegisterRoute("/loginpage", typeof(LoginPage));

        }
    }
}
