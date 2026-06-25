using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Database;
using Firebase.Database.Query;
using MauiRemindMe.Models;

namespace MauiRemindMe.ViewsModels
{

    public partial class RegisterListVM : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        private readonly FirebaseClient _client;//פרמטר חיבור ישיר לפיירביס
        private readonly RegisterPageVM _editVM;//פרמטר של רשימה לא ברור!!!!!
        Task loaddata;// לא ברור!!!!!

        public RegisterListVM(FirebaseClient client, RegisterPageVM editVM)// שורמ פרמטרים אוטומטית
        {
            _client = client;
            _editVM = editVM;
           loaddata= LoadData();
        }

        [ObservableProperty]// שומר אוטומטית את ערך השורה אחרי
        ObservableCollection<MyUser> userlist = new();//יוצר רשימה של משתמשים

        [ObservableProperty]// שומר אוטומטית את ערך השורה אחרי
        public static MyUser user = new();//יוצר פרמטר חדש של משתמש

        [RelayCommand]//יוצר כפתור של הפעולה הבאה
        public async Task LoadData()//מה יקרה בטעינת העמוד
        {
            try
            {
                if (userlist != null)// במקום שהוא יכפיל את הרשימה הוא מוחק וטוען אטתה מחדשת לא עובד
                {
                    userlist.Clear();
                }
                var result = _client.Child("AppUser").AsObservable<MyUser>().Subscribe((item) =>//מביא את כל המשתמשים ששמורים בפיירביס ומציג כל אחד בנפרד עם הפרטים שלו
                {
                    if (item.Object != null)
                    {
                        item.Object.Id = item.Key;//firebase key
                        userlist.Add(item.Object);
                        user = item.Object;
                    }
                });
            }
            catch (Exception)//במקרה והייתה תקלה
            {
                await Shell.Current.DisplayAlert("Error", $"loading faild", "ok");
            }
        }

        [RelayCommand]//יוצר כפתור של הפעולה הבאה
        public async Task DeleteAppUser(string Id)//מוחק משתמש
        {
            await _client.Child($"AppUser/{Id}").DeleteAsync();
        }

        [RelayCommand]//יוצר כפתור של הפעולה הבאה
        public async Task ShowUser(string Id)
        {
            //לא מושלם
            await _client.Child($"AppUser/{user.Id}").PutAsync(new MyUser //פעולת שמירה בדאטבייס
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Email = user.Email,
                Admin = false,
            });
            //isEdit = false;
            //failError = "update sucsses";
            //await Shell.Current.DisplayAlert("info", failError, "ok");
            await Shell.Current.GoToAsync("..");
        }
    } 
}

