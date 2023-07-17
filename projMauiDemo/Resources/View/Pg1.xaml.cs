namespace projMauiDemo.Resources.View;

public partial class Pg1 : ContentPage
{
	public Pg1()
	{
		InitializeComponent();
	}

    private void btnGoToPg2_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new Pg2());
    }

    private void btnLogin_Clicked(object sender, EventArgs e)
    {
        App app = Application.Current as App;
        app.userLogin = "Amy";
        Navigation.PushAsync(new Pg2());
    }
}