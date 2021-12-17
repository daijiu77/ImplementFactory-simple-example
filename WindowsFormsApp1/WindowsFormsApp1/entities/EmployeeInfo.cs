using System.DJ.ImplementFactory.Commons.Attrs;
using System.DJ.ImplementFactory.NetCore.Commons.Attrs;

namespace WindowsFormsApp1.entities
{
    public class EmployeeInfo
    {
        [Condition("=", Condition.WhereIgrons.igroneZero)]
        public int id { get; set; }
        
        [Condition("like", Condition.WhereIgrons.igroneEmptyNull)]
        public string name { get; set; }

        [Condition("like", Condition.WhereIgrons.igroneEmptyNull)]
        public string address { get; set; }

        [Condition("like", Condition.WhereIgrons.igroneEmptyNull)]
        [FieldMapping("telphone")]
        public string telphoneNumber { get; set; }

    }

}
