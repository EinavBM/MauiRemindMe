using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Database;
using Firebase.Database.Query;
using MauiRemindMe.Models;
using MauiRemindMe.Views;

namespace MauiRemindMe.ViewsModels
{
    public partial class AddNotificationVM : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        private readonly FirebaseClient _client;

        //[ObservableProperty]
        //private string? _name;

        private DateOnly _selectedDate { get; set; }

        public DateOnly SelectedDate
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

        //[ObservableProperty]
        private TimeSpan timeNe { get; set; }

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
            SelectedDate = DateOnly.FromDateTime(DateTime.Today);
        }
       

        [RelayCommand]
        private async Task SaveNote()
        {
            DateTime dt = DateTime.Now;
            string st1 = AddNotification.st;
            string id = Preferences.Default.Get("UserId", "");
            await _client.Child("Notification").PostAsync(new NotificationM //פעולת שמירה בדאטבייס
            {
                UserId = id,
                Status = StatusV,
                Info = _description,
                DateN = SelectedDate.ToString("yyyy,MM,dd"),
               TimeN = TimeNe.ToString(@"hh\:mm\:ss"),

            });

        }
    }
}
