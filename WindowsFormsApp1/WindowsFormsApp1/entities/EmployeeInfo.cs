using System.Collections.Generic;
using System.DJ.ImplementFactory.Commons.Attrs;
using System.DJ.ImplementFactory.DataAccess;
using System.DJ.ImplementFactory.NetCore.Commons.Attrs;

namespace WindowsFormsApp1.entities
{
    public class EmployeeInfo: AbsDataModel
    {
        [Condition("=", Condition.WhereIgrons.igroneZero)]
        public virtual int id { get; set; }
        
        [Condition("like", Condition.WhereIgrons.igroneEmptyNull)]
        public virtual string name { get; set; }

        [Condition("like", Condition.WhereIgrons.igroneEmptyNull)]
        public virtual string address { get; set; }

        [Condition("like", Condition.WhereIgrons.igroneEmptyNull)]
        [FieldMapping("telphone")]
        public virtual string telphoneNumber { get; set; }

        [Constraint(foreignKey: "id", refrenceKey: "EmployeeInfoId")]
        public virtual List<WorkInfo> WorkInfos { get; set; }
    }

}
