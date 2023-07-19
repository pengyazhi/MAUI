using System.Text;

namespace projMauiDemo.Resources.View;

public partial class PgFile : ContentPage
{
	public PgFile()
	{
		InitializeComponent();
	}

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string path = Path.Combine(folder, "hello.txt");
        File.WriteAllText(path, txtSet.Text, Encoding.UTF8);
        txtSet.Text = "";
    }

    private void btnRead_Clicked(object sender, EventArgs e)
    {
        string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string path = Path.Combine(folder, "hello.txt");
        lblGet.Text=File.ReadAllText(path,Encoding.UTF8);
    }
}