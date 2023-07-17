using projMauiDemo.Resources.Models;

namespace projMauiDemo.Resources.View;

public partial class PgEditor : ContentPage
{
    private int _position = 0;
    private List<CCustomers> _list = new List<CCustomers>();
    public PgEditor()
	{
		InitializeComponent();
        loadData();
	}
    int[] ids = new int[3];
    string[] names = new string[3];
    string[] phones = new string[3];
    string[] emails = new string[3];
    string[] adderss = new string[3];
    
    private void loadData()
    {
        ids[0] = 1;
        names[0] = "Amy";
        phones[0] = "095532145";
        emails[0] = "sss@gmail.com";
        adderss[0] = "Keelung";
        ids[1] = 2;
        names[1] = "Ben";
        phones[1] = "0955447788";
        emails[1] = "ddd@gmail.com";
        adderss[1] = "TaiChung";
        ids[2] = 3;
        names[2] = "David";
        phones[2] = "0933665482";
        emails[2] = "eee@gmail.com";
        adderss[2] = "Taipei";
    }

    private void btnFisrt_Clicked(object sender, EventArgs e)
    {
        _position = 0;
        dispalyCustomerInfo();
    }
   
    private void btnLast_Clicked(object sender, EventArgs e)
    {
        _position = ids.Length - 1;
        dispalyCustomerInfo();
    }

    private void btnPrevious_Clicked(object sender, EventArgs e)
    {
        _position--;
        if(_position <0)
            _position = 0;
        dispalyCustomerInfo();
    }

    private void btnNext_Clicked(object sender, EventArgs e)
    {
        _position++;
        if (_position > ids.Length-1)
            _position = ids.Length-1;
        dispalyCustomerInfo();

    }
    void dispalyCustomerInfo()
    {
        txtID.Text = ids[_position].ToString();
        txtName.Text = names[_position];
        txtPhone.Text = phones[_position];
        txtEmail.Text = emails[_position];
        txtAddress.Text = adderss[_position];
    }
}