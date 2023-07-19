using projMauiDemo.Resources.Models;
using projMauiDemo.Resources.ViewModels;

namespace projMauiDemo.Resources.View;

public partial class PgEditor : ContentPage
{
    CCustomerViewModel _vm = null;
    public PgEditor()
	{
        //實做他就會變成一塊新的記憶體而不是binding的資料
       // _vm = new CCustomerViewModel();
		InitializeComponent();
        //所以要讓_vm的值等於binding的值
        _vm = this.BindingContext as CCustomerViewModel;
	}

    private void btnFisrt_Clicked(object sender, EventArgs e)
    {
        _vm.moveFirst();
        //dispalyCustomerInfo();
    }
   
    private void btnLast_Clicked(object sender, EventArgs e)
    {
        _vm.moveLast();
        //dispalyCustomerInfo();
    }

    private void btnPrevious_Clicked(object sender, EventArgs e)
    {
        _vm.movePrevious();
        //dispalyCustomerInfo();
    }

    private void btnNext_Clicked(object sender, EventArgs e)
    {
        _vm.moveNext();
        //dispalyCustomerInfo();

    }

    //功能由CCustomerViewModel中的public event PropertyChangedEventHandler PropertyChanged取代,由每個移動的方法去抓資料
    void dispalyCustomerInfo()
    {
       CCustomers x = _vm.current;
        txtID.Text = x.id.ToString();
        txtName.Text = x.name;
        txtPhone.Text = x.phone;
        txtEmail.Text = x.email;
        txtAddress.Text = x.address;
    }

    private void btnSearchClick(object sender, EventArgs e)
    {
        //按下搜尋扭到查詢頁面
        Navigation.PushAsync(new PgKeyword());
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        App app = Application.Current as App;
        if (!string.IsNullOrEmpty(app.keyword)) //從app拿到從pgkeyword給的值且keyword不是空值才做搜尋動作
        {
            //使用CCustomerHome的queryByKeyword方法來判斷是否包含值
            //if (_vm.queryByKeyword(app.keyword) != null)
            _vm.queryByKeyword(app.keyword);
                //dispalyCustomerInfo();
        }
        if(app.selectedIndexOfCustomers >= 0)
        {
            _vm.moveTo(app.selectedIndexOfCustomers);
            //dispalyCustomerInfo();
        }
    }
    //當做返回建(即沒使用搜尋按鈕)應該將app裡的keyword清空避免重複搜尋
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        App app = Application.Current as App;
        app.keyword = "";
        app.selectedIndexOfCustomers = -1;
        _vm.persistant();
    }

    private void btnList_Clicked(object sender, EventArgs e)
    {
        App app = Application.Current as App;
        //把全部資料放到app的allCustomerForList
        app.allCustomerForList = _vm.all;
        Navigation.PushAsync(new PgList());
    }
}
