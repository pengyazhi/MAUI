using projMauiDemo.Resources.Models;
namespace projMauiDemo.Resources.View;

public partial class PgPreferencesDemo : ContentPage
{
	public PgPreferencesDemo()
	{
		InitializeComponent();
	}

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        Preferences.Default.Set("KK", txtSet.Text);
    }

    private void btnRead_Clicked(object sender, EventArgs e)
    {
        //材把计狦KEYぃ,玥肚箇砞(材把计)安砞"KK"ぃ,硂柑穦肚---
        lblGet.Text = Preferences.Default.Get("KK", "---");
    }
}