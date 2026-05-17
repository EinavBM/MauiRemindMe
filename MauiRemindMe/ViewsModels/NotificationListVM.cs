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
        Task task;

        [ObservableProperty]
        ObservableCollection<NotificationM> notifilist = new();
        public NotificationListVM(FirebaseClient client, AddAndEditNotificationVM editVM)
        {
            _client = client;
            _editVM = editVM;
          task=  LoadData();
            notifilist.Add(new NotificationM { Info = "test/text", Id = "auwtdfitafwdt", Status = "Task" });
        }


        [ObservableProperty]
        public static NotificationM notification = new();

        [RelayCommand]
        public async Task LoadData()
        {
            try
            {
                var result = MauiProgram.client.Child("No").AsObservable<NotificationM>().Subscribe((item) =>
                {
                    if (item.Object != null)
                    {
                        item.Object.Id = item.Key;//firebase key
                        notifilist.Add(item.Object);
                        notification = item.Object;
                      //  OnPropertyChanged(nameof(notifilist));
                    }
                });
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("שגיאה", $"התחברות נכשלה", "ok");

            }
           
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
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("Notification", notification);
            //נשלח את המידע עם הפניה למסך
        //   await Shell.Current.GoToAsync("/Details", data);
            await Shell.Current.GoToAsync("/update", data);
        }
    }
}
