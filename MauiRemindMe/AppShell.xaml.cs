using MauiRemindMe.Views;

namespace MauiRemindMe
{
    public partial class AppShell : Shell
    {
        public AppShell()//מגדיר את כל הדפים שלא נמצאים בתפריט
        {// הקובץ זה כמו סוג של תוכן עניינים שמות קיצור לכל הדפים שיש אלהם גלישה ישירה ולא דווקה דרך האפשל, כמו מעבר דרך כפתור 
            InitializeComponent();
            Routing.RegisterRoute("/mainpage", typeof(MainPage));
            Routing.RegisterRoute("/registerpage", typeof(RegisterPage));
            Routing.RegisterRoute("/loginpage", typeof(LoginPage));
            Routing.RegisterRoute("/logout", typeof(LogoutPage2));
            Routing.RegisterRoute("/update", typeof(AddAndEditNotification));
            Routing.RegisterRoute("/add", typeof(AddNotification));
            Routing.RegisterRoute("/searchDate", typeof(SearchDate));
            Routing.RegisterRoute("/notiList", typeof(NotificationListPage));
            Routing.RegisterRoute("/scheduler", typeof(SchedulerPage2));


        }
    }
}
