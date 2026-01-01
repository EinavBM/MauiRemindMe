using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Database;
using MauiRemindMe.Models;
using MauiRemindMe.Views;

namespace MauiRemindMe.ViewsModels
{
    public partial class NotificationListVM:CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        private readonly FirebaseClient _client;
        private readonly AddAndEditNotificationVM _editVM;
        public NotificationListVM(FirebaseClient client, AddAndEditNotificationVM editVM)
        {
            _client = client;
            _editVM = editVM;
          //  LoadData();
        }

        [ObservableProperty]
        ObservableCollection<NotificationM> notifilist = new();


        [RelayCommand]
        public async Task LoadData()
        {
            var result = _client.Child("Notification").AsObservable<NotificationM>().Subscribe((item) =>
            {
                if (item.Object != null)
                {
                    item.Object.Id = item.Key;//firebase key
                    notifilist.Add(item.Object);
                }
            });
        }

        [RelayCommand]
        public async Task DeleteNotification(string Id)//מוחק התרעה
        {
            //var result = await Shell.Current.DisplayAlert("Confirm", "are you sure want to delete?", "Ok", "Cancel");
            //if (result)
            //{
            await _client.Child($"Notification/{Id}").DeleteAsync();
           // await LoadData();
            //  }
        }

        [RelayCommand]
        public async Task ShowNotification(NotificationM notification) 
        {
            _editVM.Notification = notification;
            _editVM.IsEdit = true;
            await Shell.Current.GoToAsync(nameof(AddAndEditNotification));
        }
    }
}
