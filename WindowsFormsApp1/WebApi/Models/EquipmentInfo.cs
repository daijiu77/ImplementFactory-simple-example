using System;
using System.DJ.DJson.Commons;

namespace WebApi.Models
{
    public class EquipmentInfo: BaseEntity
    {
        public Guid id { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public string equipmentName { get; set; }
        public string code { get; set; }
        public DateTime cdatetime { get; set; }
    }
}
