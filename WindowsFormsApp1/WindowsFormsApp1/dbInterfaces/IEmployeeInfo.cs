using System;
using System.Collections.Generic;
using System.DJ.ImplementFactory.Commons;
using System.DJ.ImplementFactory.Commons.Attrs;
using System.DJ.ImplementFactory.Pipelines.Pojo;
using WindowsFormsApp1.entities;

namespace WindowsFormsApp1.dbInterfaces
{
    public interface IEmployeeInfo
    {
        /// <summary>
        /// Reset the returned result.
        /// </summary>
        /// <param name="ComNameEn"></param>
        /// <returns></returns>
        [AutoSelect("select a.* from [dbo].[EmployeeInfo] a, dbo.WorkInfo b where a.id=b.EmployeeInfoID and b.CompanyNameEn='{ComNameEn}'",
            new string[] { "WindowsFormsApp1", "EmployeeInfoResult", "Reset" })] // new string[] { Namespace, ClassName, MethodName }
        EmployeeInfo getEmployeeInfoByCompanyNameEn(string ComNameEn);

        [AutoSelect("select a.* from EmployeeInfo a, WorkInfo b where a.id=b.EmployeeInfoID and b.CompanyNameEn=@ComNameEn",
            new string[] { "WindowsFormsApp1", "EmployeeInfoResult", "Reset1" })] // new string[] { Namespace, ClassName, MethodName }
        string getEmployeeInfoByCompanyNameEn1(string ComNameEn);

        /// <summary>
        /// Dynamic make a sql expression, and reset the returned result.
        /// </summary>
        /// <param name="ComNameEn"></param>
        /// <returns></returns>
        [AutoSelect(dataProviderNamespace: "WindowsFormsApp1", dataProviderClassName: "EmployeeInfoByCompanyNameEn2",
            new string[] { "WindowsFormsApp1", "EmployeeInfoResult", "Reset1" })] // new string[] { Namespace, ClassName, MethodName }
        string getEmployeeInfoByCompanyNameEn2(string ComNameEn);

        /// <summary>
        /// the parameter is a dynamic data entity.
        /// </summary>
        /// <param name="dataElements"></param>
        /// <returns></returns>
        [AutoSelect(dataProviderNamespace: "WindowsFormsApp1", dataProviderClassName: "EmployeeInfoByCompanyNameEn3",
            new string[] { "WindowsFormsApp1", "EmployeeInfoResult", "Reset1" })] // new string[] { Namespace, ClassName, MethodName }
        string getEmployeeInfoByCompanyNameEn3(DataEntity<DataElement> dataElements);

        [AutoSelect("select a.* from EmployeeInfo a, WorkInfo b where a.id=b.EmployeeInfoID and b.CompanyNameEn=@CompanyNameEn",
            new string[] { "WindowsFormsApp1", "EmployeeInfoResult", "Reset1" })] // new string[] { Namespace, ClassName, MethodName }
        string getEmployeeInfoByCompanyNameEn4(DataEntity<DataElement> dataElements);

        /// <summary>
        /// The return value is a dynamic data entity.
        /// </summary>
        /// <param name="ComNameEn"></param>
        /// <returns></returns>
        [AutoSelect("select a.* from EmployeeInfo a, WorkInfo b where a.id=b.EmployeeInfoID and b.CompanyNameEn=@ComNameEn",
            new string[] { "WindowsFormsApp1", "EmployeeInfoResult", "Reset2" })] // new string[] { Namespace, ClassName, MethodName }
        DataEntity<DataElement> getEmployeeInfoByCompanyNameEn5(string ComNameEn);

        /// <summary>
        /// The 'Action' parameter will receive the returned result.
        /// </summary>
        /// <param name="employeeInfo"></param>
        /// <param name="action"></param>
        [AutoInsert("if not exists(select * from EmployeeInfo where name=@name) begin " +
            "insert into dbo.[EmployeeInfo] {employeeInfo} end",
            new string[] { "id" }, FieldsType.Exclude, EnabledBuffer: false)]
        void insert(EmployeeInfo employeeInfo, Action<int> action);

        [AutoInsert("insert into EmployeeInfo {employeeInfo}",
            fields = new string[] { "id" },
            fieldsType = FieldsType.Exclude, EnabledBuffer = true)]
        int insert(EmployeeInfo employeeInfo);

        [AutoInsert("insert into EmployeeInfo {employeeInfo}", fields: new string[] { "id" }, fieldsType: FieldsType.Exclude)]
        bool insert1(EmployeeInfo employeeInfo);

        [AutoUpdate("update EmployeeInfo set name=@name where id=@id and id in (select a.EmployeeInfoID from WorkInfo a where a.id=@workInfoID)",
            EnabledBuffer: true)]
        bool update(EmployeeInfo employeeInfo, int workInfoID, Action<int> action);

        [AutoDelete("delete from EmployeeInfo where id=@id")]
        bool delete(EmployeeInfo employeeInfo);

        [AutoCount("select count(*) from EmployeeInfo")]
        int count();

        [AutoCount("select count(*) from EmployeeInfo")]
        bool isExsit();

        [AutoProcedure("exec getEmployeeInfo {employeeInfo}",
            fields: new string[] { "name" }, fieldsType: FieldsType.Contain)]
        List<EmployeeInfo> employeeInfoList(EmployeeInfo employeeInfo);

        [AutoProcedure("exec getEmployeeInfo {employeeInfo}",
            fields: new string[] { "name" }, fieldsType: FieldsType.Contain, isAsync: true)]
        void employeeInfoList(EmployeeInfo employeeInfo, Action<List<EmployeeInfo>> action);
                
    }
}
