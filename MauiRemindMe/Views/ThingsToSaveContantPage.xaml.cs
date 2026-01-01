using MauiRemindMe.Models;
//using WinRT.Interop;
using static System.Net.WebRequestMethods;

namespace MauiRemindMe.Views;

public partial class ThingsToSaveContantPage : ContentPage
{
    ThingsToSave save1;
	public ThingsToSaveContantPage()
	{
		DateTime date = DateTime.Now;
		save1 = new ThingsToSave()
		{
			Id = 1,
			Tdate =date,
			Thour =date.Hour,
			StatusMs = true
		};

		BindingContext = save1;
		InitializeComponent();

	}
}