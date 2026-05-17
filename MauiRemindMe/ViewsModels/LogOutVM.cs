using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;

namespace MauiRemindMe.ViewsModels
{
    public partial class LogOutVM : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {

        public static bool IsLoggedIn { get; set; }

        private readonly FirebaseAuthClient _client; //חיבור לפיירבס

        

        public LogOutVM(FirebaseAuthClient client)
        {
            _client = client;
        }

        [RelayCommand]
        private async Task Logout()
        {
            IsLoggedIn = false;
            await Shell.Current.GoToAsync("//loginpage");
        }

    }
}
