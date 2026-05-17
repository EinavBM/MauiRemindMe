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
        private readonly FirebaseClient _client;
        private readonly RegisterPageVM _editVM;
        Task loaddata;

        public RegisterListVM(FirebaseClient client, RegisterPageVM editVM)
        {
            _client = client;
          //  LoadData();
            _editVM = editVM;
           loaddata= LoadData();
        }

        [ObservableProperty]
        ObservableCollection<MyUser> userlist = new();

        [ObservableProperty]
        public static MyUser user = new();

        [RelayCommand]
        public async Task LoadData()
        {
            var result = _client.Child("AppUser").AsObservable<MyUser>().Subscribe((item) =>
            {
                if (item.Object != null)
                {
                    item.Object.Id = item.Key;//firebase key
                    userlist.Add(item.Object);
                    user= item.Object;
                }
            });
        }

        [RelayCommand]
        public async Task DeleteAppUser(string Id)//מוחק משתמש
        {
            //var result = await Shell.Current.DisplayAlert("Confirm", "are you sure want to delete?", "Ok", "Cancel");
            //if (result)
            //{
            await _client.Child($"AppUser/{Id}").DeleteAsync();
           // await LoadData();
            //  }
        }

       // [RelayCommand]
        //public async Task ShowUser(MyUser user)
        //{
        //    _editVM. = notification;
        //    _editVM.IsEdit = true;
        //    await Shell.Current.GoToAsync(nameof(AddAndEditNotification));
        //}

        [RelayCommand]

        public async Task SaveAndUpdate()
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

