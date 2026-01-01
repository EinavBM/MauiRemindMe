using MauiRemindMe.Views;

namespace MauiRemindMe
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddAndEditNotification), typeof(AddAndEditNotification));
        }
    }
}
