using System;
using System.DJ.DJson.Commons;

namespace WebApi.Models
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
