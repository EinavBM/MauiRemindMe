using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Database;
using Firebase.Database.Query;
using MauiRemindMe.Helpers;
using MauiRemindMe.Models;
using MauiRemindMe.Views;

namespace MauiRemindMe.ViewsModels
{
    public partial class AddNotificationVM : CommunityToolkit.Mvvm.ComponentModel.ObservableObject// 
    {
        private readonly FirebaseClient _client;// משתנה מתקשר לפיירביס

        private DateTime _selectedDate { get; set; } //אובייקט תאריך

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                if (_selectedDate != value)
                {
                    _selectedDate = value;
                    OnPropertyChanged(); // Notifies UI of changes
                                         // Act on the new date here
                }
            }
        }

        private TimeSpan timeNe { get; set; }// אובייקט זמן

        public TimeSpan TimeNe 
        {
            get => timeNe;
            set
            {
                if (timeNe != value)
                {
                    timeNe = value;
                    OnPropertyChanged(); // Notifies UI of changes
                                         // Act on the new date here
                }
            }
        }

        [ObservableProperty]
        private string? _description;

       
        private string? _status= string.Empty; 

        public string StatusV
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(); // Notifies UI of changes
                                         // Act on the new date here
                }
            }
        }
        
        public AddNotificationVM(FirebaseClient client)
        {
            _client = client; 
            SelectedDate = DateTime.Today;
        }


        [RelayCommand]
        private async Task SaveNote()
        {
            DateTime dt = DateTime.Now;
            string st1 = AddNotification.st;
            string id = Preferences.Default.Get("UserId", "");
            if (CheckingData.CheckingDate(_selectedDate) == false)
            {
                await Shell.Current.DisplayAlert("Error", $"invalid date", "ok");
                return;
            }
            if (CheckingData.CheckingInput(_description) == false)
            {
                await Shell.Current.DisplayAlert("Error", $"missing description", "ok");
                return;
            }
            if (CheckingData.CheckingInput(StatusV) == false)
            {
                await Shell.Current.DisplayAlert("Error", $"missing status", "ok");
                return;
            }
            await _client.Child("Notification").PostAsync(new NotificationM //פעולת שמירה בדאטבייס
            {
                UserId = id,
                Status = StatusV,
                Info = _description,
                DateN = SelectedDate,
                TimeN = TimeNe.ToString(@"hh\:mm\:ss"),
                Id = Guid.NewGuid().ToString()

            });

        }
    }
}
