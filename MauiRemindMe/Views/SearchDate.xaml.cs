using MauiRemindMe.ViewsModels;

namespace MauiRemindMe.Views;

public partial class SearchDate : ContentPage
{
	public SearchDate(SearchDate2 vm)
	{
		InitializeComponent();
        BindingContext = vm;

    }
}