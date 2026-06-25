using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using MauiRemindMe.Helpers;
using Microsoft.Maui.Storage;

namespace MauiRemindMe.ViewsModels
{
    public partial class LoginPageViewModel: ObservableObject
    {
        public static bool IsLoggedIn { get; set; }// משתנה הודב אם חשבון מחובר

        private readonly FirebaseAuthClient _client; //חיבור לפיירבס

        [ObservableProperty]
        private string? _email;

        [ObservableProperty]
        private string? _password;

        public LoginPageViewModel(FirebaseAuthClient client) // מגדיר לקוח שמתחבר לפיירביס 
        {
            _client= client;
        }

        [RelayCommand]// מה קורה אחרי שלחץ על כפתור
        public async Task Login()
        {
            if (CheckingData.CheckingInput(_email, 10) == false)
            {
                await Shell.Current.DisplayAlert("Error", $"invalid email", "ok");
                return;
            }
                
            if (CheckingData.CheckingInput(_password, 6, 10) == false)
            {
                await Shell.Current.DisplayAlert("Error", $"invalid password", "ok");
                return;
            }
            try
            {

                // ניסיון התחברות
                var auth= await _client.SignInWithEmailAndPasswordAsync(Email, Password);
                await SecureStorage.Default.SetAsync("Token", _client.User.Uid);
                string id = _client.User.Uid;



                // הצגת הודעת הצלחה
                //
                await Shell.Current.DisplayAlert("Login", $"Login succeed! yeepeee!", "ok");
                Preferences.Default.Set("UserId", id);// שמירת ה ID של מי שעשה כניסה


                // כאן בדרך כלל תגיע ניווט לכל התפריט
                await Shell.Current.GoToAsync("//main/scheduler");
            }
            catch (Exception ex)
            {
                // הצגת הודעת שגיאה במקרה של כישלון (למשל סיסמה שגויה)
                await Shell.Current.DisplayAlert("שגיאה", $"התחברות נכשלה", "ok");
            }
        }
        
        [RelayCommand]
        private async Task Register()// אם לא מחובר
        {
            IsLoggedIn = false;
            await Shell.Current.GoToAsync("//registerpage");
            
        }
    }
}
