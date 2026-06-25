using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Firebase.Database;
using MauiRemindMe.Views;
using MauiRemindMe.ViewsModels;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;
//using static System.Net.WebRequestMethods;


namespace MauiRemindMe//מנהל א כל הפרוייטק
{
    public static class MauiProgram
    {
        public static FirebaseClient client;
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.ConfigureSyncfusionCore();
            builder.UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()// מגדיר חיבור לפיירביס 
            {
                ApiKey = "AIzaSyDDcMQoNMeZUGC3KTmaIbAJfG0sLqyzFlc",
                AuthDomain = "remindme-c2389.firebaseapp.com",//מגדיר את האוטותיקיישן
                //שני נתונים אלה באים מהפיירבייס 

                Providers = new FirebaseAuthProvider[]
                {
                       new EmailProvider()
                },
                UserRepository = new FileUserRepository("appuser")//מגדיר את הדטבייס
            }));

            client = new FirebaseClient("https://remindme-c2389-default-rtdb.europe-west1.firebasedatabase.app/");// מגדיר את הכתובת הפיזית שבה שמור הפיירביס
            builder.Services.AddSingleton(client);

            //מגדיר את כל הדפים הקיימים כדי שלא אצטרך לבצע איתחול לכל האובייקטים 
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<AddNotification>(); 
            builder.Services.AddSingleton<AddNotificationVM>();
            builder.Services.AddSingleton<RegisterPage>();
            builder.Services.AddSingleton<RegisterPageVM>();
            builder.Services.AddSingleton<NotificationListPage>();
            builder.Services.AddSingleton<NotificationListVM>();
            builder.Services.AddSingleton<RegisterListPage>();
            builder.Services.AddSingleton<RegisterListVM>();
            builder.Services.AddSingleton<AddAndEditNotification>();
            builder.Services.AddSingleton<AddAndEditNotificationVM>();
            builder.Services.AddSingleton<LogoutPage2>();
            builder.Services.AddSingleton<LogOutVM>();
            builder.Services.AddSingleton<MyProfile>();
            builder.Services.AddSingleton<SearchDate>();
            builder.Services.AddSingleton<SearchDate2>();
            builder.Services.AddSingleton<SchedulerPage2>();
            builder.Services.AddSingleton<SchedulerVM>();




            return builder.Build();
        }
    }
}
