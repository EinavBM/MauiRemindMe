using MauiRemindMe.ViewsModels;

namespace MauiRemindMe.Views;

public partial class NotificationListPage : ContentPage
{
	public NotificationListPage(NotificationListVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}