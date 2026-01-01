using MauiRemindMe.ViewsModels;

namespace MauiRemindMe.Views;

public partial class RegisterListPage : ContentPage
{
	public RegisterListPage(RegisterListVM vm)
	{
		InitializeComponent();
        BindingContext = vm;

    }
}