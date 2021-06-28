using System;
using System.Collections.Generic;
using System.DJ.ImplementFactory.Pipelines;
using System.Text;

namespace WindowsFormsApp1.dbInterfaces
{
    public interface ITest: ISingleInstance
    {
        void say();
    }
}
