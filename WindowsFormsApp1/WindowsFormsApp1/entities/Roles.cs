using System;
using System.Collections.Generic;
using System.DJ.DJson.Commons;
using System.Text;

namespace WindowsFormsApp1.entities
{
    public class Roles : BaseEntity
    {
        public Guid ID { get; set; }
        public string Role_name { get; set; }
        public string Role_code { get; set; }
        public Guid DataRight_GroupID { get; set; }
        public Guid ModuleRight_GroupID { get; set; }
        public long date_time { get; set; }
    }
}
