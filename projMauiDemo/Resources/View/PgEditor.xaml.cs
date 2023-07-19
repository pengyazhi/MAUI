using projMauiDemo.Resources.Models;
using projMauiDemo.Resources.ViewModels;

namespace projMauiDemo.Resources.View;

public partial class PgEditor : ContentPage
{
    CCustomerViewModel _vm = null;
    public PgEditor()
	{
        //�갵�L�N�|�ܦ��@���s���O����Ӥ��Obinding�����
       // _vm = new CCustomerViewModel();
		InitializeComponent();
        //�ҥH�n��_vm���ȵ���binding����
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

    //�\���CCustomerViewModel����public event PropertyChangedEventHandler PropertyChanged���N,�ѨC�Ӳ��ʪ���k�h����
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
        //���U�j�M���d�߭���
        Navigation.PushAsync(new PgKeyword());
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        App app = Application.Current as App;
        if (!string.IsNullOrEmpty(app.keyword)) //�qapp����qpgkeyword�����ȥBkeyword���O�ŭȤ~���j�M�ʧ@
        {
            //�ϥ�CCustomerHome��queryByKeyword��k�ӧP�_�O�_�]�t��
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
    //����^��(�Y�S�ϥηj�M���s)���ӱNapp�̪�keyword�M���קK���Ʒj�M
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
        //�������Ʃ��app��allCustomerForList
        app.allCustomerForList = _vm.all;
        Navigation.PushAsync(new PgList());
    }
}
