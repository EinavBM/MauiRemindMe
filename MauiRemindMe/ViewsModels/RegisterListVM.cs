using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Database;
using MauiRemindMe.Models;

namespace MauiRemindMe.ViewsModels
{

    public partial class RegisterListVM : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        private readonly FirebaseClient _client;

        public RegisterListVM(FirebaseClient client)
        {
            _client = client;
            LoadData();
        }

        [ObservableProperty]
        ObservableCollection<MyUser> userlist = new();


        [RelayCommand]
        public async Task LoadData()
        {
            var result = _client.Child("AppUser").AsObservable<MyUser>().Subscribe((item) =>
            {
                if (item.Object != null)
                {
                    item.Object.Id = item.Key;//firebase key
                    userlist.Add(item.Object);
                }
            });
        }

        [RelayCommand]
        public async Task DeleteAppUser(string Id)//מוחק התרעה
        {
            //var result = await Shell.Current.DisplayAlert("Confirm", "are you sure want to delete?", "Ok", "Cancel");
            //if (result)
            //{
            await _client.Child($"AppUser/{Id}").DeleteAsync();
           // await LoadData();
            //  }
        }
    } 
}

