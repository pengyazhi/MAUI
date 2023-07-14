namespace projMauiDemo;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
		
        btnClick.Clicked += BtnClick_Clicked;
    }

    private void BtnClick_Clicked(object sender, EventArgs e)
    {
		Rand();
    }

    void Rand()
	{
        List<string>lists = new List<string>() { "紅","黃","藍","綠"};
        Random rand = new Random();
        int index = rand.Next(0, lists.Count);
       lblBlue.Text = lists[index];
		lists.RemoveAt(index);
		index = rand.Next(0, lists.Count-1);
		lblGreen.Text = lists[index];
		lists.RemoveAt(index);
		index = rand.Next(0, lists.Count - 1);
		lblYellow.Text = lists[index];
		lists.RemoveAt(index);
		lblRed.Text = lists[0];
    }
}

