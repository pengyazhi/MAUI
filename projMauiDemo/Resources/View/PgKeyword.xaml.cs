namespace projMauiDemo.Resources.View;

public partial class PgKeyword : ContentPage
{
	public PgKeyword()
	{
		InitializeComponent();
	}

    private void btnConfirm_Clicked(object sender, EventArgs e)
    {
        //�bApp��@�@�ӰO����Bset���ݩ�keyword ����
        (Application.Current as App).keyword = txtKeyword.Text;
		Navigation.PopAsync();
    }
}