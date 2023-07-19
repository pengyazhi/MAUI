using projMauiDemo.Resources.Models;
namespace projMauiDemo.Resources.View;

public partial class PgToDoEditor : ContentPage
{
    CTodo _current = null;
	public PgToDoEditor()
	{
		InitializeComponent();
	}
    
    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        //使用Preferences才可以將key及value保留(即使重新啟動程式)
        //使用Preferences.Default.Get取到COUNT(key)的值,不存在則取回預設值(0)
        int sn = Preferences.Default.Get("COUNT", 0);
        sn++;
        //設置COUNT(key)的值為sn
        Preferences.Default.Set("COUNT", sn);
        Preferences.Default.Set("T"+sn.ToString(), txtTodo.Text);
        Preferences.Default.Set("D"+sn.ToString(), txtDate.Text);
        txtTodo.Text = "";
        txtDate.Text = "";
    }

    private void btnList_Clicked(object sender, EventArgs e)
    {
        int sn = Preferences.Default.Get("COUNT", 0);
        if (sn == 0)
            return;
        List<CTodo> todos = new List<CTodo>();
        for(int i = 1; i <= sn; i++)
        {
            string KeyT = "T" + i.ToString();
            if (Preferences.Default.ContainsKey(KeyT))
            {
                CTodo x = new CTodo();
                x.todo = Preferences.Default.Get(KeyT, "");
                x.date = Preferences.Default.Get("D"+i, "");
                x.流水號 = i;
                todos.Add(x);
            }
        }
        if (todos.Count == 0)
            return;
        (Application.Current as App).allTodoForList = todos;
        Navigation.PushAsync(new PgTodoList());
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        App app =Application.Current as App;
        if(app.selectedTodoSN > 0)
        {
            //PgTodoList中lvTodo_SelectionChanged方法裡app.selectedTodoSN = (e.CurrentSelection.FirstOrDefault() as CTodo).流水號;
            _current = app.allTodoForList.FirstOrDefault(t => t.流水號 == app.selectedTodoSN);
            if(_current != null)
            {
                txtDate.Text = _current.date;
                txtTodo.Text = _current.todo;
            }
        }
        //if (app!=null && app.selectedIndexOfTodos >= 0) 
        //{
        //    _current = app.allTodoForList[app.selectedIndexOfTodos];
        //    txtDate.Text = _current.date;
        //    txtTodo.Text = _current.todo;
        //}
    }
    protected override void OnDisappearing()
    {
       App app =Application.Current as App;
        app.selectedTodoSN = -1;
    }
    private void btnFinish_Clicked(object sender, EventArgs e)
    {
        if (_current != null)
        {
            Preferences.Default.Remove("T" + _current.流水號.ToString());
            Preferences.Default.Remove("D" + _current.流水號.ToString());
        }
        _current = null;
        txtDate.Text = "";
        txtTodo.Text = "";
    }
}