using System;
using System.Collections.Generic;
using System.DJ.ImplementFactory.Commons.Attrs;
using System.Text;
using WindowsFormsApp1.entities;

namespace WindowsFormsApp1.dbInterfaces
{
    public interface IRoles: IBaseDataSource<Roles>
    {
        [AutoSelect("select * from Roles order by date_time desc")]
        List<Roles> query();

        [AutoDelete("delete from Roles where id=@id")]
        int del(List<Roles> roles);
    }
}
