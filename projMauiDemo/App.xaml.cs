using projMauiDemo.Resources.View;

namespace projMauiDemo;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		//MainPage = new PgLotto();
        //   MainPage = new MainPage();
        MainPage = new PgClickDemo();
    }
}
