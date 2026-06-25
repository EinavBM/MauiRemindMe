using MauiRemindMe.ViewsModels;
using MauiRemindMe.Services;
using System.Reactive;
using MauiRemindMe.Models;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace MauiRemindMe.Views;

public partial class NotificationListPage : ContentPage
{
	
    private readonly FirebaseService _firebaseService;//מגדיר משתנה מקשר למחלקת שירות פיירביס
    public ICommand DeleteCommand { get; set; }

    public NotificationListPage()
    {
        InitializeComponent();
      _firebaseService=new FirebaseService();// יוצר משתנה חדש
        BindingContext=this;// בדף זהז אני לא רוצה שהוא ילך לVM אלה ישאר בדף זה
        
    }

    private async void OnSearchButtonClicked(object sender, EventArgs e)
    {
        string id = Preferences.Default.Get("UserId", ""); //ששולף תז של משתמש
        List<NotificationM> notifications= await _firebaseService.GetNotificationAsync(id);//מביא נוטיפיקציות של משתמש
       // ShowNotificationId(notifications);
        if (notifications != null)
        {
           

            notificationsCollectionView.ItemsSource=notifications;
        }
        else
        {
            await DisplayAlert("Error", "loading data faild", "ok");// הודעת שגיעה
        }
    }

    //private void ShowNotificationId(List<NotificationM> notifications)
    //{
    //    foreach (NotificationM notification in notifications)
    //    {
    //        NotificationM notificationM = notification as NotificationM;
    //        string id = notificationM.Id;
    //    }
    //}

    [RelayCommand]
    public async Task DeleteNotification(string Id)//מוחק התרעה
    {
        await _firebaseService.DeleteNotification(Id);// קורא לפעולת מחיקה מתור מחלקת שירות של הפיירביס
       
    }

    [RelayCommand]
    public async Task ShowNotification(string Id)
    {
        NotificationM not = await _firebaseService.ShowNotification(Id);
        Dictionary<string, object> data = new Dictionary<string, object>
        {
           { "Notification", not}
        };
        //נשלח את המידע עם הפניה למסך
        await Shell.Current.GoToAsync("/update", data);
    }




}