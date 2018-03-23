//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace App.Core.Infrastructure.Interceptors
//{


//    public class AsyncCachingInterceptor : IAsyncInterceptionBehavior
//    {
//        private static readonly IDictionary<int, int> PrecalculatedValues = new Dictionary<int, int>
//        {
//            {16, 4444},
//            {10, 5555},
//        };

//        public async Task<IMethodInvocationResult> InterceptAsync(IAsyncMethodInvocation methodInvocation)
//        {
//            var argument = methodInvocation.GetArgument("value");
//            var argumentValue = (int) argument.Value;

//            int result;
//            return PrecalculatedValues.TryGetValue(argumentValue, out result)
//                ? methodInvocation.CreateResult(result)
//                : await methodInvocation.InvokeNextAsync().ConfigureAwait(false);
//        }
//    }
//}

