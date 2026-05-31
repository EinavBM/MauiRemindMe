using MauiRemindMe.ViewsModels;

namespace MauiRemindMe.Views;

public partial class AddNotification : ContentPage
{
	public static string st;
	public AddNotification(AddNotificationVM vm)
	{
		InitializeComponent();
		 st=status.Text;
		//DateTime dt=(DateTime) myDatePicker.Date;
		BindingContext = vm;
	}

    private void myTimePicker_TimeSelected(object sender, TimeChangedEventArgs e)
    {

    }
}