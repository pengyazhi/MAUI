namespace projMauiDemo.Resources.View;

public partial class PgBindingByCode : ContentPage
{
	public PgBindingByCode()
	{
		InitializeComponent();
		lblHello.BindingContext = slider;
		lblHello.SetBinding(Label.OpacityProperty, "Value");
	}
}