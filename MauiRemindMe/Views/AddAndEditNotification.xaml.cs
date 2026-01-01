using MauiRemindMe.ViewsModels;

namespace MauiRemindMe.Views;

public partial class AddAndEditNotification : ContentPage
{
	public AddAndEditNotification(AddAndEditNotificationVM vm)
	{
        InitializeComponent();
        BindingContext = vm;
    }
}