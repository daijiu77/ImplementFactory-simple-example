using System.Collections.Generic;
using System.DJ.ImplementFactory.Commons.Attrs;
using WindowsFormsApp1.entities;

namespace WindowsFormsApp1.dbInterfaces
{
    public interface IUserInfoMapper
    {
        [AutoSelect("select * from UserInfo order by id desc")]
        List<UserInfo> query();

        [AutoInsert("insert into UserInfo values {userInfo}",
            fields: new string[] { "id", "cdatetime" })]
        int insert(UserInfo userInfo);
    }
}
