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
using MauiRemindMe.Helpers;
using MauiRemindMe.Models;

namespace MauiRemindMe.ViewsModels
{
    [QueryProperty(nameof(MyUser), "User")]// מעביר פרטים מעמוד MYUSER לפה
    public partial class RegisterPageVM: CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        public static bool IsLoggedIn { get; set; }// יוצר פרמטר שבודק אם משתמש מחובר
        private readonly FirebaseClient _client;//מגדיר אובייקט פיירביס ששמור נתונים בריללטייםדטבייס
        private readonly FirebaseAuthClient _auth;// מגדיר אובייקט פיירביס שאחראי על הזדהור

        private readonly IConnectivity _connectivity;//פעולה הבודקת עם משתמש מחובר לאינטרנט

        public bool IsConnected =>
            _connectivity.NetworkAccess == NetworkAccess.Internet;//אם כן מחובר לאינטרנט



        //שומר אוטומטית שם אימייל וסיסמה
        [ObservableProperty]
        private string? _name;

        [ObservableProperty]
        private string? _email;

        [ObservableProperty]
        private string? _password;

        [ObservableProperty]//שומר אוטומטית פרמטר מסוג משתמש
        MyUser user = new();


        public RegisterPageVM(FirebaseClient client, FirebaseAuthClient auth)
        {
            //עושה איתחול לאובייקטים של פיירביס בדף זה
            _client = client;
            _auth = auth;
        }

        [RelayCommand]//הופך פעולה לכפתור
        private async Task Register()// הפעולה שרצה אחרי שהכניס את כל הפרטים שלו ולחץ על התחברות
        {
            IsLoggedIn = false;// משתמש לא מחובר
            try
            {
                if (Connectivity.NetworkAccess != NetworkAccess.Internet)//אם יש בעיה בחיבור לאינטרנט
                {
                    await Shell.Current.DisplayAlert("Error", $"Internet not connected", "ok");//הודעה
                }
                else//אם כן
                {

                    //בודק אם כל הפרטים אם הם תקינים
                    //ואם לא שולח הודעה
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
                    if (CheckingData.CheckingInput(_name) == false)
                    {
                        await Shell.Current.DisplayAlert("Error", $"invalid name", "ok");
                        return;
                    }
                    await _auth.CreateUserWithEmailAndPasswordAsync(_email, _password);// יוצר את תהליך הרשמה 

                    await _client.Child("AppUser").PostAsync(new MyUser //פעולת שמירה בדאטבייס
                    {
                        Id = _auth.User.Uid,
                        Name = _name,
                        Password = _password,
                        Email = _email,
                        Admin = false,
                    });

                    IsLoggedIn = true;//כן מחובר
                    if (IsLoggedIn)// אם כן מעביר אותו לעמוד של הוספת התראה ונותן גישה לכל התפריט
                    {
                        await Shell.Current.GoToAsync("//main/scheduler");
                    }
                }

            }
            catch (Exception)//במקרה והייתה תקלה
            {
                await Shell.Current.DisplayAlert("Error", $"Register failed", "ok");
            }
        }
    }
}
