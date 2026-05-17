using MauiRemindMe.Models;
using MauiRemindMe.Views;

namespace MauiRemindMe
{
    public partial class App : Application
    {
        public static bool IsLoggedIn { get; set; }
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            //if (IsLoggedIn)
            //{
                return new Window(new AppShell());
            //}
            //else
            //{
                //////return new Window(new MainPage());
            //}
            //כדי להחליף שלא המיינפייג' יהיה הדף פתיחה אלה דף שאני רוצה
        }
    }
}