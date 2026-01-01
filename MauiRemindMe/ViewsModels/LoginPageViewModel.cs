using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;

namespace MauiRemindMe.ViewsModels
{
    public partial class LoginPageViewModel: ObservableObject
    {
       private readonly FirebaseAuthClient _client; //חיבור לפיירבס

        [ObservableProperty]
        private string? _email;

        [ObservableProperty]
        private string? _password;

        public LoginPageViewModel(FirebaseAuthClient client)
        {
            _client= client;
        }

        [RelayCommand]
        private async Task Login()
        {
            Console.WriteLine(  Email.ToString());
            Console.WriteLine(  Password.ToString());
            await _client.SignInWithEmailAndPasswordAsync(Email, Password);
            _= Shell.Current.DisplayAlert("Login", $"Login succeed! yeepeee!", "ok");
        }
    }
}
