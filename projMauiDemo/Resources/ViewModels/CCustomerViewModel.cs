using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using projMauiDemo.Resources.Models;

namespace projMauiDemo.Resources.ViewModels
{
    //原本下面的loadData,moveFirst等方法寫在page,但其他程式碼也會需要loadData,moveFirst等功能,且分類會不明確,因此拉到另一個類別去寫
    internal class CCustomerViewModel : INotifyPropertyChanged
    {
        
        public CCustomerViewModel()
        {
            loadData();
        }
        private int _position = 0;
        private List<CCustomers> _list = new List<CCustomers>();
        //用來取代原先在PgEditor的display()
        public event PropertyChangedEventHandler PropertyChanged;

        //loadData從"customer.txt"抓資料
        private void loadData()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string path = Path.Combine(folder, "customer.txt");
            string data = File.ReadAllText(path, Encoding.UTF8);
            //先將每一筆客戶資料依\n分開
            var lines = data.Split('\n');
            foreach (var line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    //再將每一筆客戶資料的每個項目用\t分開
                    var cell = line.Split('\t');
                    CCustomers x = new CCustomers();
                    x.id = Convert.ToInt32(cell[0]);
                    x.name = cell[1];
                    x.phone = cell[2];
                    x.email = cell[3];
                    x.address = cell[4];
                    //最後加回_list裡
                    _list.Add(x);
                }
            }
            //CCustomers x = new CCustomers();
            //x.id = 1;
            //x.name = "Amy";
            //x.phone = "095532145";
            //x.email = "sss@gmail.com";
            //x.address = "Keelung";
            //_list.Add(x);
            //x = new CCustomers();
            //x.id = 2;
            //x.name = "Ben";
            //x.phone = "0955447788";
            //x.email = "ddd@gmail.com";
            //x.address = "TaiChung";
            //_list.Add(x);
            //x = new CCustomers();
            //x.id = 3;
            //x.name = "David";
            //x.phone = "0933665482";
            //x.email = "eee@gmail.com";
            //x.address = "Taipei";
            //_list.Add(x);
        }

        //先不註解原本上面的資料,在PgEditor的OnDisappearing使用persistant方法將資料存到file中"customer.txt"
        public void persistant()
        {
            string s = "";
            foreach (var c in _list)
            {
                //這裡的長相會是id1 \t name1 \t phone1 ... \n  id2 \t name2 \t phone2 ...
                s += c.id.ToString() + "\t";
                s += c.name.ToString() + "\t";
                s += c.phone.ToString() + "\t";
                s += c.email.ToString() + "\t";
                s += c.address.ToString() + "\n";
            }
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string path = Path.Combine(folder, "customer.txt");
            File.WriteAllText(path, s, Encoding.UTF8);
        }
        public void moveFirst()
        {
            _position = 0;
            //去繫結現在的位置
            //current是CCustomerViewModel的 public CCustomers current {get { return _list[_position]; } set { _list[_position] = value; }}
            PropertyChanged(this, new PropertyChangedEventArgs("current"));
        }
        public void moveNext()
        {
            _position++;
            if (_position > _list.Count - 1)
                _position = _list.Count - 1;
            PropertyChanged(this, new PropertyChangedEventArgs("current"));
        }
        public void movePrevious()
        {
            _position--;
            if (_position < 0)
                _position = 0;
            PropertyChanged(this, new PropertyChangedEventArgs("current"));
        }
        public void moveLast()
        {
            _position = _list.Count - 1;
            PropertyChanged(this, new PropertyChangedEventArgs("current"));
        }
        //移動到指定位置
        public void moveTo(int to)
        {
            _position = to;
            PropertyChanged(this, new PropertyChangedEventArgs("current"));
        }

        internal object queryByKeyword(string keyword)
        {
            for (int i = 0; i < _list.Count; i++)
            {
                //可以搜尋name/phone/email/address,且不分大小寫
                if (_list[i].name.ToUpper().Contains(keyword.ToUpper())
                    || _list[i].phone.ToUpper().Contains(keyword.ToUpper())
                    || _list[i].email.ToUpper().Contains(keyword.ToUpper())
                    || _list[i].address.ToUpper().Contains(keyword.ToUpper()))
                {
                    moveTo(i);
                    return _list[i];
                }
            }
            return null;
        }

        //拿到目前資料
        public CCustomers current
        {
            get { return _list[_position]; }
            set { _list[_position] = value; }
        }
        //拿到全部資料
        public List<CCustomers> all
        {
            get { return _list; }
            set { _list = value; }
        }
    }
}
