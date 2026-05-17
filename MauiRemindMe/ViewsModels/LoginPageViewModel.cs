using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;

namespace MauiRemindMe.ViewsModels
{
    public partial class LoginPageViewModel: ObservableObject
    {
        public static bool IsLoggedIn { get; set; }

        private readonly FirebaseAuthClient _client; //חיבור לפיירבס

        [ObservableProperty]
        private string? _email;

        [ObservableProperty]
        private string? _password;

        public LoginPageViewModel(FirebaseAuthClient client)
        {
            _client= client;
        }

      
        //private async Task Login1()
        //{
        //    IsLoggedIn = false;
        //    //Console.WriteLine(  Email.ToString());
        //    //Console.WriteLine(  Password.ToString());
        //    await _client.SignInWithEmailAndPasswordAsync(Email, Password);
        //    _= Shell.Current.DisplayAlert("Login", $"Login succeed! yeepeee!", "ok");
        //    IsLoggedIn = true;
        //    if (IsLoggedIn)
        //    {
        //        await Shell.Current.GoToAsync("//main/addnotification");
        //    }
        //}

        [RelayCommand]
        public async Task Login()
        {
            try
            {
                // ניסיון התחברות
                await _client.SignInWithEmailAndPasswordAsync(Email, Password);

                // הצגת הודעת הצלחה
                await Shell.Current.DisplayAlert("Login", $"Login succeed! yeepeee!", "ok");

                // כאן בדרך כלל תגיע ניווט לדף הבית
                await Shell.Current.GoToAsync("//main/addnotification");
            }
            catch (Exception ex)
            {
                // הצגת הודעת שגיאה במקרה של כישלון (למשל סיסמה שגויה)
                await Shell.Current.DisplayAlert("שגיאה", $"התחברות נכשלה", "ok");
            }
        }
        
        [RelayCommand]
        private async Task Register()
        {
            IsLoggedIn = false;
            await Shell.Current.GoToAsync("//registerpage");
            
        }
    }
}
