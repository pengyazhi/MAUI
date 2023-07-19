using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projMauiDemo.Resources.Models
{
    public class CTodo
    {
        public string todo { get; set; }
        public string date { get; set; }
        public int 流水號 { get; set; }
        public override string ToString()
        {
            return todo;
        }
    }
}
