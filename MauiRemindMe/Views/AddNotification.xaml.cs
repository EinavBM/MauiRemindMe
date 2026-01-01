using MauiRemindMe.ViewsModels;

namespace MauiRemindMe.Views;

public partial class AddNotification : ContentPage
{
	public AddNotification(AddNotificationVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}