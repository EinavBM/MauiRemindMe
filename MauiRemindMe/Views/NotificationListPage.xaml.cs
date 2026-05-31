using MauiRemindMe.ViewsModels;
using MauiRemindMe.Services;
using System.Reactive;
using MauiRemindMe.Models;

namespace MauiRemindMe.Views;

public partial class NotificationListPage : ContentPage
{
	//public NotificationListPage(NotificationListVM vm)
	//{
	//	InitializeComponent();
	//	BindingContext = vm;
	//}
    private readonly FirebaseService _firebaseService;
    public NotificationListPage()
    {
        InitializeComponent();
      //  BindingContext = vm;
      _firebaseService=new FirebaseService();
    }

    private async void OnSearchButtonClicked(object sender, EventArgs e)
    {
        string searchName = "xxx";
        string id = Preferences.Default.Get("UserId", "");
        List<NotificationM> notifications= await _firebaseService.GetNotificationAsync(id);
        if (notifications != null)
        {
            notificationsCollectionView.ItemsSource=notifications;
        }
        else
        {
            await DisplayAlert("שגיאה", "טעינת נתונים נכשלה", "אישור");
        }
    }

}