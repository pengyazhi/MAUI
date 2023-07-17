using projMauiDemo.Resources.View;

namespace projMauiDemo;

public partial class App : Application
{
    public string  userLogin { get;set;} 
	public App()
	{
		InitializeComponent();
        //MainPage = new PgCalc();
        MainPage = new NavigationPage(new PgEditor());
    }
}
