using System;
using System.Collections.Generic;
using System.DJ.ImplementFactory.DataAccess;
using System.DJ.ImplementFactory.DataAccess.FromUnit;
using System.DJ.ImplementFactory.DataAccess.Pipelines;
using System.Text;
using WindowsFormsApp1.entities;

namespace WindowsFormsApp1
{
    public class TestORM
    {
        public void Query()
        {
            DbVisitor db = new DbVisitor();
            IDbSqlScheme scheme = db.CreateSqlFrom(SqlFromUnit.New.From<WorkInfo>(dm => dm.CompanyName.Equals("HG")));
            scheme.dbSqlBody.Where(ConditionItem.Me.And("CompanyName", ConditionRelation.Contain, "G"));

            IList<WorkInfo> list = scheme.ToList<WorkInfo>();

            //实现懒加载
            EmployeeInfo employeeInfo1 = list[0].employeeInfo;
            IList<WorkInfo> workInfos1 = employeeInfo1.WorkInfos;
            EmployeeInfo employeeInfo2 = workInfos1[0].employeeInfo;
        }

        public void InsertData(WorkInfo workInfo)
        {
            DbVisitor db = new DbVisitor();
            IDbSqlScheme scheme = db.CreateSqlFrom(SqlFromUnit.Me.From(workInfo));
            scheme.dbSqlBody.DataOperateExcludes("id", "employeeInfo");
            scheme.Insert();
        }

        public void UpdateData(WorkInfo workInfo)
        {
            DbVisitor db = new DbVisitor();
            IDbSqlScheme scheme = db.CreateSqlFrom(SqlFromUnit.Me.From(workInfo));
            scheme.dbSqlBody.DataOperateContains("CompanyName", "CompanyNameEn");
            scheme.Update();
        }

        public void DeleteData(WorkInfo workInfo)
        {
            DbVisitor db = new DbVisitor();
            IDbSqlScheme scheme = db.CreateSqlFrom(SqlFromUnit.Me.From(workInfo));
            scheme.dbSqlBody.Where(ConditionItem.Me.And("id", ConditionRelation.Equals, workInfo.id));
            scheme.Delete();
        }
    }
}
