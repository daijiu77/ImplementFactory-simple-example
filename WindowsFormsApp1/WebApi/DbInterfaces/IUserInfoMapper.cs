using System.Collections.Generic;
using System.DJ.ImplementFactory.Commons;
using System.DJ.ImplementFactory.Commons.Attrs;
using System.DJ.ImplementFactory.Pipelines.Pojo;
using WebApi.Models;

namespace WebApi.DbInterfaces
{
    public interface IUserInfoMapper
    {
        [AutoSelect("select * from UserInfo order by id desc")]
        List<UserInfo> query();

        /// <summary>
        /// The return value is a dynamic data collection type
        /// </summary>
        /// <returns></returns>
        [AutoSelect("select * from UserInfo order by id desc")]
        DataEntity<DataElement> query1();

        [AutoInsert("insert into UserInfo values {userInfo}",
            fields: new string[] { "id", "cdatetime" }, fieldsType: FieldsType.Exclude, EnabledBuffer: true)]
        int insert0(UserInfo userInfo);

        [UserInfoInsert("insert into UserInfo values {userInfo}")]
        int insert(UserInfo userInfo);

        /// <summary>
        /// Parameter is dynamic data collection type.
        /// </summary>
        /// <param name="dataElements"></param>
        /// <returns></returns>
        [UserInfoInsert("insert into UserInfo values {userInfo}")]
        int insert(DataEntity<DataElement> dataElements);

        [AutoInsert("insert into UserInfo values {userInfo}",
            fields: new string[] { "name", "age", "address" },
            fieldsType: FieldsType.Contain, EnabledBuffer: true)]
        int insert2(UserInfo userInfo);

        [AutoUpdate(updateExpression: "update UserInfo set {userInfo} where id=@id",
            fields: new string[] { "id", "cdatetime" }, fieldsType: FieldsType.Exclude, EnabledBuffer: true)]
        int update(UserInfo userInfo);
    }

    class UserInfoInsert: AutoInsert
    {
        public UserInfoInsert(string sqlExpression) : base(sqlExpression, new string[] { "id", "cdatetime" },
            fieldsType: FieldsType.Exclude, EnabledBuffer: true) { }
    }
}
