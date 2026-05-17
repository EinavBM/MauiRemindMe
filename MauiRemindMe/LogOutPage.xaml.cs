using MauiRemindMe.ViewsModels;

namespace MauiRemindMe;

public partial class LogOutPage : ContentPage
{
	public LogOutPage(LogOutVM vm)
	{
		InitializeComponent();
		BindingContext= vm;
	}
}