using MauiRemindMe.Models;
using MauiRemindMe.Views;

namespace MauiRemindMe
{
    public partial class App : Application// הקובץ הראשי של התכנית שמחליט מי יעבוד ראשון
    {
        public static bool IsLoggedIn { get; set; }
        public App()
        {
            InitializeComponent();
        }



        protected override Window CreateWindow(IActivationState? activationState)
        {
           
                return new Window(new AppShell());
            
            //כדי להחליף שלא המיינפייג' יהיה הדף פתיחה אלה דף שאני רוצה
        }
    }
}