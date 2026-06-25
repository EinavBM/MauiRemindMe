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

namespace MauiRemindMe.ViewsModels// לא בשימוש
{
    public partial class NotificationListVM:CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        private readonly FirebaseClient _client; // חיבור לפיירביס
        private readonly AddAndEditNotificationVM _editVM;//פרמטר של עריכת תזכורת
        Task task;// משתנה מסוג משימה

        [ObservableProperty]// כל פעם שהערך של השורה שאחרי משתנה, הוא יעדכן אוטומטית את מסך האפליקציה
        ObservableCollection<NotificationM> notifilist = new();// פרמטר רשימה של תזכורות 
        public NotificationListVM(FirebaseClient client, AddAndEditNotificationVM editVM)// שומר את שני הפרמטרים אוטומטית 
        {
            _client = client;
            _editVM = editVM;
         
            notifilist.Add(new NotificationM { Info = "test/text", Id = "auwtdfitafwdt", Status = "Task" });// מידא חד פעמי
        }


 
        [ObservableProperty]// כל פעם שהערך של השורה שאחרי משתנה, הוא יעדכן אוטומטית את מסך האפליקציה
        public static NotificationM notification = new();// יוצר אובייקט תזכורת 

        [RelayCommand]// הופך את הפונקציה הבאה לכפתור שיעבוד בXAML
        public async Task LoadData()// מה קורה כשהמסך נטען
        {
            try// מנסה להעריץ ואם לא מצליח שומר את מה שיש
            {
                var result = MauiProgram.client.Child("Notification").AsObservable<NotificationM>().Subscribe((item) =>//?????
                {
                    if (item.Object != null)
                    {
                        item.Object.Id = item.Key;//firebase key
                        notifilist.Add(item.Object);
                        notification = item.Object;
                    }
                });
            }
            catch (Exception ex)// אם לא מצליח
            {
                await Shell.Current.DisplayAlert("שגיאה", $"התחברות נכשלה", "ok");//הודעה 

            }
           
        }

        [RelayCommand]// הופך את הפונקציה הבאה לכפתור שיעבוד בXAML
        public async Task DeleteNotification(string Id)//מוחק התרעה
        {
            //var result = await Shell.Current.DisplayAlert("Confirm", "are you sure want to delete?", "Ok", "Cancel");
            //if (result)
            //{
            await _client.Child($"Notification/{Id}").DeleteAsync();
           // await LoadData();
            //  }
        }

        [RelayCommand]//הופך את הפונקציה הבאה לכפתור שיעבוד ב XAML
        public async Task ShowNotification(NotificationM notification) 

        {
            _editVM.Notification = notification;
            _editVM.IsEdit = true;
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("Notification", notification);
            //נשלח את המידע עם הפניה למסך
            await Shell.Current.GoToAsync("/update", data);
        }
    }
}
