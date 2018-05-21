using StructureMap.DynamicInterception;

namespace App.Host.DependencyResolution.Interceptors
{
    public class AuthorisationInterceptor : ISyncInterceptionBehavior
    {
        public IMethodInvocationResult Intercept(ISyncMethodInvocation methodInvocation)
        {
            var classType = methodInvocation.MethodInfo.DeclaringType;
            var classAttributes = classType.Attributes;

            string methodName  = methodInvocation.MethodInfo.Name;
            var methodAttributes = methodInvocation.MethodInfo.Attributes;

            //var argument = methodInvocation.GetArgument("value");

            return methodInvocation.InvokeNext();
        }
    }

    public class AuditingInterceptor : ISyncInterceptionBehavior
    {
        public IMethodInvocationResult Intercept(ISyncMethodInvocation methodInvocation)
        {
            return methodInvocation.InvokeNext();
        }
    }
}
