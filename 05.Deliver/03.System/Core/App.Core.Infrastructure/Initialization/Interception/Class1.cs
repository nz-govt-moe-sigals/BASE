//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace App.Core.Infrastructure.Initialization.Interception
//{
//    private class NegatingInterceptor : ISyncInterceptionBehavior
//    {
//        public IMethodInvocationResult Intercept(ISyncMethodInvocation methodInvocation)
//        {
//            var argument = methodInvocation.GetArgument("value");
//            var argumentValue = (int)argument.Value;
//            if (argumentValue < 0)
//            {
//                argument.Value = -argumentValue;
//            }
//            return methodInvocation.InvokeNext();
//        }
//    }
//}
