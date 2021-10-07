using System;
using System.Collections.Generic;
using System.DJ.ImplementFactory.Commons.Attrs;
using System.DJ.ImplementFactory.Pipelines.Pojo;
using System.Text;

namespace WindowsFormsApp1.dbInterfaces
{
    /// <summary>
    /// 泛型接口时,以大写的 T 作为标识,多个 TT, TTT 等
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseDataSource<T>
    {
        [AutoSelect("select * from {T} order by cdatetime desc")]
        List<T> query();

        /// <summary>
        /// 分页获取数据, 注: $cal()函数为计算表达式函数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereStr">以 and\or 开头的条件字符串</param>
        /// <param name="pageSize">每页显示的记录数量</param>
        /// <param name="pageIndex">当前第几页(起始值为:1)</param>
        /// <returns></returns>
        [AutoSelect("select * from (select row_number() over(order by id) rowIndex,* from {T} where 1=1 {whereStr}) t " +
            "where t.rowIndex>=$cal({pageSize}*({pageIndex}-1)) and t.rowIndex<=$cal({pageSize}*{pageIndex})")]
        List<T> query(string whereStr, int pageSize, int pageIndex);

        [AutoSelect("select * from {T} where id='{id}'")]
        T query(string id);

        [AutoInsert("insert into {T} {data}",
            fields: new string[] { "cdatetime", "recordCount" },
            fieldsType: FieldsType.Exclude)]
        int insert(T data);

        [AutoUpdate("update {T} set {data} where id=?id",
            fields: new string[] { "id", "cdatetime", "recordCount" },
            fieldsType: FieldsType.Exclude)]
        int update(T data);

        [AutoUpdate("update {T} set {fieldName}='{fieldValue}' where id='{id}'")]
        int updateUnit(string id, string fieldName, string fieldValue);

        [AutoDelete("delete from {T} where id=?id")]
        int delete(string id);
    }
}
