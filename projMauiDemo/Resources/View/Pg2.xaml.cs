namespace projMauiDemo.Resources.View;

public partial class Pg2 : ContentPage
{
	public Pg2()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        App app = Application.Current as App;
        if (!string.IsNullOrEmpty(app.userLogin))
        {
            lblTitle.Text = "�w�� " + app.userLogin + "�n�J�t��";
        }
    }
    private void btnGoBack_Clicked(object sender, EventArgs e)
    {
		Navigation.PopAsync();
    }

    
}