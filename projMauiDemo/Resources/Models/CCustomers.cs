using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projMauiDemo.Resources.Models
{
    public class CCustomers
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        
        public override string ToString()
        {
            //為了讓顯示資料不是CCustomer集合資料而是其中的name及phone,去override ToString()
            return name + "/" + phone;
        }
    }
}
