using projMauiDemo.Resources.Models;
using projMauiDemo.Resources.View;

namespace projMauiDemo;

public partial class App : Application
{
    public string  userLogin { get;set;} 
    public string keyword { get;set;}
    public List<CCustomers> allCustomerForList { get;set;}
    public List<CTodo> allTodoForList { get; set; }
    public int selectedIndexOfCustomers { get;set;}
    public int selectedTodoSN { get;set;}
    
    public App()
	{
		InitializeComponent();
        
        MainPage = new NavigationPage(new PgHttp());
        selectedIndexOfCustomers = -1;
        selectedTodoSN = -1;
    }
}
