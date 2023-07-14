using System;

namespace projMauiDemo.Resources.View;

public partial class PgClickDemo : ContentPage
{
	public PgClickDemo()
	{
		InitializeComponent();
	}

    private void btnCalculate_Clicked(object sender, EventArgs e)
    {
		double a = Convert.ToDouble(entryA.Text);
		double b = Convert.ToDouble(entryB.Text);
		double c = Convert.ToDouble(entryC.Text);
		double d_num = System.Math.Sqrt(b*b-4*a*c);
        double result1 = (-b+d_num)/2/a;
        double result2 = (-b-d_num)/2/a;
		answer.Text = $"解答 : {result1:0.00}或{result2:0.00}";
    }
}