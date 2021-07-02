using System;
using System.Collections.Generic;
using System.DJ.ImplementFactory.Commons.Attrs;
using System.DJ.ImplementFactory.Pipelines.Pojo;
using System.Text;

namespace WindowsFormsApp1
{
    public class MyAutoCall : AutoCall
    {
        public override bool ExecuteBeforeFilter(Type interfaceType, object implement, string methodName, PList<Para> paras)
        {
            return base.ExecuteBeforeFilter(interfaceType, implement, methodName, paras);
        }

        public override bool ExecuteAfterFilter(Type interfaceType, object implement, string methodName, PList<Para> paras, object result)
        {
            return base.ExecuteAfterFilter(interfaceType, implement, methodName, paras, result);
        }

        public override void ExecuteException(Type interfaceType, object implement, string methodName, PList<Para> paras, Exception ex)
        {
            base.ExecuteException(interfaceType, implement, methodName, paras, ex);
        }
    }
}
