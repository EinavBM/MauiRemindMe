using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Firebase.Database;
using MauiRemindMe.Models;
using Firebase.Database.Query;
using CommunityToolkit.Mvvm.Input;



namespace MauiRemindMe.ViewsModels
{
    [QueryProperty(nameof(NotificationM), "Notification")]
    public partial class AddAndEditNotificationVM:CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        private readonly FirebaseClient _client;

        public AddAndEditNotificationVM(FirebaseClient fc)
        {
            _client = fc;
        }

        [ObservableProperty]
        NotificationM notification= new();

        [ObservableProperty]
        bool isEdit;

        [ObservableProperty]
        string failError;

        [RelayCommand]

        public async Task SaveAndUpdate()
        {
            await _client.Child($"Notification/{notification.Id}").PutAsync(notification);
            isEdit = false;
            failError = "update sucsses";
            await Shell.Current.DisplayAlert("info", failError, "ok");
            await Shell.Current.GoToAsync("..");
        }

    }
}
