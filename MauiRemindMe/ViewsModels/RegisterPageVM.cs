using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using MauiRemindMe.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MauiRemindMe.ViewsModels
{
    public partial class RegisterPageVM: CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        private readonly FirebaseClient _client;
        private readonly FirebaseAuthClient _auth;

        [ObservableProperty]
        private string? _name;

        [ObservableProperty]
        private string? _email;

        [ObservableProperty]
        private string? _password;

        public RegisterPageVM(FirebaseClient client, FirebaseAuthClient auth)
        {
            _client = client;
            _auth = auth;
        }

        [RelayCommand]
        private async Task Register()
        {
            await _auth.CreateUserWithEmailAndPasswordAsync (_email, _password);
            await _client.Child("AppUser").PostAsync(new MyUser //פעולת שמירה בדאטבייס
            {
                Id = _auth.User.Uid,
                Name = _name,
                Password= _password, 
                Email = _email,
                Admin= false,
            }); 


        }
    }
}
