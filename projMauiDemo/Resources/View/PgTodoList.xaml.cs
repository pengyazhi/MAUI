using projMauiDemo.Resources.Models;

namespace projMauiDemo.Resources.View;

public partial class PgTodoList : ContentPage
{
	public PgTodoList()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        App app = Application.Current as App;
        if(app.allTodoForList != null)
        {
            lvTodo.ItemsSource = app.allTodoForList;
        }
    }
    private void lvTodo_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        App app = Application.Current as App;

        app.selectedTodoSN = e.SelectedItemIndex;
        Navigation.PopAsync();
    }

    private void lvTodo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        App app = Application.Current as App;
        app.selectedTodoSN = (e.CurrentSelection.FirstOrDefault() as CTodo).¬y¤ô¸¹;
        Navigation.PopAsync();
    }
}