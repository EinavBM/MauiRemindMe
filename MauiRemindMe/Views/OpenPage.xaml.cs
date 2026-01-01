namespace MauiRemindMe.Views;

public partial class OpenPage : ContentPage
{

	public OpenPage()
	{

		InitializeComponent();
	}
    private  async void Button_Clicked(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        ContentPage p = null;
        switch (btn.Text)
        {
            //case "LoginPage Btn":
            //    p = new LoginPage();
            //    App.Current.MainPage.Navigation.PushAsync(p);
            //    break;
            //case "RegisterPage Btn":
            //    p = new RegisterPage();
            //    App.Current.MainPage.Navigation.PushAsync(p);
            //    break;
            default:
                await DisplayAlert("אין מה לעשות פה", "אין פה כלום", "אישור");
                break;
        }
       
       
    }
}