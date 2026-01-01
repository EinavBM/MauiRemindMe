using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Database;
using Firebase.Database.Query;
using MauiRemindMe.Models;

namespace MauiRemindMe.ViewsModels
{
    public partial class AddNotificationVM : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        private readonly FirebaseClient _client;

        [ObservableProperty]
        private string? _name;

        [ObservableProperty]
        private DateTime? _daten;

        [ObservableProperty]
        private string? _description;

        public AddNotificationVM(FirebaseClient client)
        {
            _client = client;
        }

        [RelayCommand]
        private async Task SaveNote()
        {
            await _client.Child("Notification").PostAsync(new NotificationM //פעולת שמירה בדאטבייס
            {
                Status = _name,
                Info= _description,
                DateN= _daten,

            });

        }
    }
}
