using MauiRemindMe.ViewsModels;

namespace MauiRemindMe.Views;

public partial class AddNotification : ContentPage
{
	public static string st;
	public AddNotification(AddNotificationVM vm)
	{
		InitializeComponent();
		 st=status.Text;
		BindingContext = vm;
	}
}