using System;
using System.Collections.Generic;
using System.Data;
using System.DJ.ImplementFactory.Commons;
using System.Text;
using WindowsFormsApp1.entities;

namespace WindowsFormsApp1
{
    public class EmployeeInfoResult
    {
        /// <summary>
        /// The return value must be the same as the return value of the interface method.
        /// </summary>
        /// <param name="result">Parameters is a data entity.</param>
        /// <returns></returns>
        public EmployeeInfo Reset(EmployeeInfo result)
        {
            if (null == result) return result;
            result.name += "_123";
            return result;
        }

        /// <summary>
        /// The return value must be the same as the return value of the interface method.
        /// </summary>
        /// <param name="result">Parameters can be dynamic data entities.</param>
        /// <returns></returns>
        public string Reset1(DataEntity<DataElement> result)
        {
            if (null == result) return "";
            if (0 == result.Count) return "";
            return result["name"].ToString();
        }

        /// <summary>
        /// The return value must be the same as the return value of the interface method.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public DataEntity<DataElement> Reset2(DataTable result)
        {
            DataEntity<DataElement> dataElements = null;
            if (null == result) return dataElements;
            if (0 == result.Rows.Count) return dataElements;
            result.Rows[0]["name"] += "_321";
            dataElements = result.Rows[0].GetDynamicEntityBy();
            return dataElements;
        }
    }
}
