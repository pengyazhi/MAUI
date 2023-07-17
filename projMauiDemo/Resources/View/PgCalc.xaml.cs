namespace projMauiDemo.Resources.View;

public partial class PgCalc : ContentPage
{
	public PgCalc()
	{
		InitializeComponent();
	}

    double n1 = 0;
    string op = "";
    private void onCommon_Clicked(object sender, EventArgs e)
    {
		Button btn = sender as Button;
        double t = Convert.ToDouble(lblNumber.Text);
		if (btn != null )
		{
			if(t == 0)
			{
                lblNumber.Text = btn.Text;
            }
            else
            {
                lblNumber.Text += btn.Text;
            }
        }
    }
  
  
    private void btnOperator_Clicked(object sender, EventArgs e)
    {
        n1 = Convert.ToDouble(lblNumber.Text);
        lblNumber.Text = "0";
        Button btn = sender as Button;
        if (btn != null)
        {
            op = btn.Text;
        }
      
    }
    
    private void btnAns_Clicked(object sender, EventArgs e)
    {
        double n2 = Convert.ToDouble(lblNumber.Text);
        if(op == "+")
            lblNumber.Text = (n1+ n2).ToString("0.0#");
        else if(op == "-")
            lblNumber.Text = (n1- n2).ToString("0.0#");
        else if (op == "X")
            lblNumber.Text = (n1 * n2).ToString("0.0#");
        else if (op == "/")
            lblNumber.Text = (n1 / n2).ToString("0.0#");
    }
}