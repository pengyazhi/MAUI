namespace projMauiDemo.Resources.View;

public partial class PgKeyword : ContentPage
{
	public PgKeyword()
	{
		InitializeComponent();
	}

    private void btnConfirm_Clicked(object sender, EventArgs e)
    {
        //在App實作一個記憶體且set其屬性keyword 的值
        (Application.Current as App).keyword = txtKeyword.Text;
		Navigation.PopAsync();
    }
}