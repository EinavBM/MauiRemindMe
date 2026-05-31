using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Firebase.Database;
using MauiRemindMe.Views;
using MauiRemindMe.ViewsModels;
using Microsoft.Extensions.Logging;
using static System.Net.WebRequestMethods;

namespace MauiRemindMe
{
    public static class MauiProgram
    {
        public static FirebaseClient client;
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyDDcMQoNMeZUGC3KTmaIbAJfG0sLqyzFlc",
                AuthDomain = "remindme-c2389.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                   {
                       new EmailProvider()
                   },
                UserRepository = new FileUserRepository("appuser")//persist data into %AppData%\appuser
            }));


            client = new FirebaseClient("https://remindme-c2389-default-rtdb.europe-west1.firebasedatabase.app/");
            builder.Services.AddSingleton(client);

        //    builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<AddNotification>(); //לשנות**** 
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
            //  builder.Services.AddSingleton<MyProfileVM>();
            builder.Services.AddSingleton<SearchDate>();
           // builder.Services.AddSingleton<SearchDateVM>();





            return builder.Build();
        }
    }
}
