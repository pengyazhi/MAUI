namespace projMauiDemo.Resources.View;

public partial class PgHttp : ContentPage
{
	public PgHttp()
	{
		InitializeComponent();
	}

    private async void btn_Clicked(object sender, EventArgs e)
    {
		HttpClient client = new HttpClient();
		Uri uri = new Uri("https://udn.com/invoice");
        HttpResponseMessage response = await client.GetAsync(uri);
		if(response.IsSuccessStatusCode) 
		{
			string html = await response.Content.ReadAsStringAsync();
			string key = "last-three";
			int start = html.IndexOf(key) + key.Length + 2;
			lblHttp.Text ="¯S§O¼ú : " + html.Substring(start,8);
		}
    }
}