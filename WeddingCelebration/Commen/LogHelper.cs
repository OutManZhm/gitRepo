﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;

namespace Commen
{

    public class LogHelper : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("你正在调用方法 \"{0}\"  参数是 {1}... ",
                invocation.Method.Name,
                string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray()));

            invocation.Proceed();

            Console.WriteLine("方法执行完毕，返回结果：{0}", invocation.ReturnValue);
        }
    }
}
