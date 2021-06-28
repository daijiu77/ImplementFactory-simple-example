using System;
using System.Collections.Generic;
using System.DJ.DJson.Commons;
using System.Text;

namespace WindowsFormsApp1.entities
{
    public class UserInfo: BaseEntity
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public DateTime cdatetime { get; set; }
    }
}
