using System.Collections.Generic;
using System.DJ.ImplementFactory.Commons;
using System.DJ.ImplementFactory.Commons.Attrs;
using System.DJ.ImplementFactory.Pipelines.Pojo;
using WebApi.Models;

namespace WebApi.DbInterfaces
{
    public interface IEquipmentInfoMapper
    {
        [AutoSelect("select * from EquipmentInfo order by cdatetime desc")]
        List<EquipmentInfo> query();

        /// <summary>
        /// The return value is a dynamic data collection type
        /// </summary>
        /// <returns></returns>
        [AutoSelect("select * from EquipmentInfo order by cdatetime desc")]
        DataEntity<DataElement> query1();

        [EquipInsert("insert into EquipmentInfo values {equipmentInfo}")]
        int insert(EquipmentInfo equipmentInfo);

        /// <summary>
        /// Parameter is dynamic data collection type.
        /// </summary>
        /// <param name="dataElements"></param>
        /// <returns></returns>
        [EquipInsert("insert into EquipmentInfo values {equipmentInfo}")]
        int insert(DataEntity<DataElement> dataElements);

        [AutoUpdate(updateExpression: "update EquipmentInfo set {equipmentInfo} where id=@id",
            fields: new string[] { "id", "cdatetime" }, fieldsType:FieldsType.Exclude, EnabledBuffer: true)]
        int update(EquipmentInfo equipmentInfo);
    }

    class EquipInsert: AutoInsert
    {
        public EquipInsert(string sqlExpression): base(sqlExpression, new string[] { "id", "cdatetime" },
            fieldsType: FieldsType.Exclude, EnabledBuffer: true) { }
    }
}
