﻿using System;
using System.Collections.Generic;
using System.DJ.ImplementFactory.Commons.Attrs;
using System.Text;

namespace WindowsFormsApp1
{
    public interface ICalculate
    {
        int Sum(int a, int b);

        /// <summary>
        /// 当参数类型为 AutoCall，并且该参数值为 null 时，组件自动注入 AutoCall 实例对象
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="autoCall"></param>
        /// <returns></returns>
        int Division(int a, int b, AutoCall autoCall = null);
    }
}
