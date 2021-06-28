using System;
using System.Collections.Generic;
using System.Data.Common;
using System.DJ.ImplementFactory.Pipelines;
using System.DJ.ImplementFactory.Pipelines.Pojo;
using System.Text;

namespace WindowsFormsApp1
{
    public class EmployeeInfoByCompanyNameEn2 : ISqlExpressionProvider
    {
        string ISqlExpressionProvider.provideSql(DbList<DbParameter> dbParameters, DataOptType dataOptType, PList<Para> paraList, object[] methodParameters)
        {
            string ComNameEn = paraList["ComNameEn", true].ToString();
            string sql = "select a.* from EmployeeInfo a, WorkInfo b where a.id=b.EmployeeInfoID and b.CompanyNameEn=@CompanyNameEn";
            dbParameters.Add("CompanyNameEn", ComNameEn);
            return sql;
            throw new NotImplementedException();
        }
    }
}
