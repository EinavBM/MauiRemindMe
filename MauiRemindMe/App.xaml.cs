using MauiRemindMe.Models;
using MauiRemindMe.Views;

namespace MauiRemindMe
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
         //   return new Window (new ThingsToSaveContantPage());   
            //כדי להחליף שלא המיינפייג' יהיה הדף פתיחה אלה דף שאני רוצה
        }
    }
}