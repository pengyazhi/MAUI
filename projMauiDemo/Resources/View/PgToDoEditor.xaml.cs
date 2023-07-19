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
        //�ϥ�Preferences�~�i�H�Nkey��value�O�d(�Y�ϭ��s�Ұʵ{��)
        //�ϥ�Preferences.Default.Get����COUNT(key)����,���s�b�h���^�w�]��(0)
        int sn = Preferences.Default.Get("COUNT", 0);
        sn++;
        //�]�mCOUNT(key)���Ȭ�sn
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
                x.�y���� = i;
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
            //PgTodoList��lvTodo_SelectionChanged��k��app.selectedTodoSN = (e.CurrentSelection.FirstOrDefault() as CTodo).�y����;
            _current = app.allTodoForList.FirstOrDefault(t => t.�y���� == app.selectedTodoSN);
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
            Preferences.Default.Remove("T" + _current.�y����.ToString());
            Preferences.Default.Remove("D" + _current.�y����.ToString());
        }
        _current = null;
        txtDate.Text = "";
        txtTodo.Text = "";
    }
}