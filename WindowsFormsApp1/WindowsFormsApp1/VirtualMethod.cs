using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace WindowsFormsApp1
{
    public class VirtualMethod
    {
        public virtual void Test()
        {
            //
        }

        public virtual void say()
        {
            Trace.WriteLine("Hello world!");
        }
    }
}
