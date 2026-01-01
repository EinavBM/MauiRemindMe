using Firebase.Auth;
using MauiRemindMe.ViewsModels;

namespace MauiRemindMe.Views;

public partial class LoginPage : ContentPage
{
	
	public LoginPage(LoginPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}