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
        //�ĤG�ӰѼƬ��p�GKEY���s�b,�h�^�ǹw�]��(�ĤG�ӰѼ�)�C���]"KK"���s�b,�o�̷|�^��---
        lblGet.Text = Preferences.Default.Get("KK", "---");
    }
}