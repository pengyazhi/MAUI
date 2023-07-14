namespace projMauiDemo.Resources.View;

public partial class PgLotto : ContentPage
{
	public PgLotto()
	{
		InitializeComponent();
        btnClick.Clicked += BtnClick_Clicked;
	}

    private void BtnClick_Clicked(object sender, EventArgs e)
    {
		lblLotto.Text = new Models.CLottoGen().getNumbers();
    }
}