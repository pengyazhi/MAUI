namespace projMauiDemo.Resources.View;

public partial class PgList : ContentPage
{
	public PgList()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        App app = Application.Current as App;
        //從app拿到pgEditor放的全部客戶資料
        if (app.allCustomerForList != null)
            lvCustomer.ItemsSource = app.allCustomerForList;
    }
    
    private void lvCustomer_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        App app = Application.Current as App;
        app.selectedIndexOfCustomers=e.SelectedItemIndex;
        Navigation.PopAsync();
    }
}