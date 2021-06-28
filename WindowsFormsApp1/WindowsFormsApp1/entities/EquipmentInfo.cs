using System;
using System.Collections.Generic;
using System.DJ.DJson.Commons;
using System.Text;

namespace WindowsFormsApp1.entities
{
    public class EquipmentInfo : BaseEntity
    {
        public Guid id { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public string equipmentName { get; set; }
        public string code { get; set; }
        public DateTime cdatetime { get; set; }
    }
}
