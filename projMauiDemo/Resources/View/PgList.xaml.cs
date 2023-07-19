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
        //�qapp����pgEditor�񪺥����Ȥ���
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