using MauiRemindMe.ViewsModels;
using Firebase.Auth;


namespace MauiRemindMe.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterPageVM vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}