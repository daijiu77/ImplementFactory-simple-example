using System;
using System.Collections.Generic;
using System.DJ.ImplementFactory.Commons.Attrs;
using System.Text;

namespace WindowsFormsApp1.entities
{
    public class EmployeeInfo
    {
        public int id { get; set; }
        
        public string name { get; set; }
        public string address { get; set; }

        [FieldMapping("telphone")]
        public string telphoneNumber { get; set; }

    }

}
