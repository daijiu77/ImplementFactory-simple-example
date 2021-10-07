using System.DJ.ImplementFactory.Commons.Attrs;

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
