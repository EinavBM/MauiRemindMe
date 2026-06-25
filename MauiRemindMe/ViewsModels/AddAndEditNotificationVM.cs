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
using MauiRemindMe.Services;



namespace MauiRemindMe.ViewsModels
{
    [QueryProperty(nameof(ItemReceived), "Notification")]
    public partial class AddAndEditNotificationVM:CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        private readonly FirebaseClient _client;//מקשר ישירות לפיירביס
        private NotificationM itemReceived;// התזכורת התקבלה מרשימת התזכורות שממנה הגענו לפה

        private readonly FirebaseService _firebaseService;//יוצר משתנה מקשר פיירביס מסוג מחלקת השירות

        public NotificationM ItemReceived
        {
            get => itemReceived;
            set
            {
                itemReceived = value;
                OnPropertyChanged();

                // כאן המקום לבצע פעולות מיד כשהאובייקט מגיע!
                //InitializeData();
            }
        }

        public AddAndEditNotificationVM(FirebaseClient fc)
        {
            _client = fc;
            _firebaseService = new FirebaseService();// יוצר משתנה חדש

        }

        [ObservableProperty]
        NotificationM notification= new();

        [ObservableProperty]
        bool isEdit;

        [ObservableProperty]
        string failError;

        [RelayCommand]

        public async Task SaveAndUpdate()// שומר את הנתונים החדשים בדתהבייס
        {
            try 
            { 
            await _firebaseService.DeleteNotification(itemReceived.Id);// קורא לפעולת מחיקה מתור מחלקת שירות של הפיירביס
            await _client.Child($"Notification/{itemReceived.Id}").PutAsync(itemReceived);
            isEdit = false;
            failError = "update sucsses";
            await Shell.Current.DisplayAlert("Notice", failError, "ok");
            await Shell.Current.GoToAsync("..");
            }
            catch (Exception)//במקרה והייתה תקלה
            {
                await Shell.Current.DisplayAlert("Error", $"fail to update notification", "ok");
            }
        }

    }
}
