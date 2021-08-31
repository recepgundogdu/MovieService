using AspectInjector.Broker;
using Newtonsoft.Json;
using Serilog;
using System;

namespace MovieService.Core.Aspects
{
    [Aspect(Scope.Global)]
    [Injection(typeof(Logging))]
    public class Logging : Attribute
    {
        [Advice(Kind.Around, Targets = Target.Method)]
        public object HandleMethod([Argument(Source.Name)] string name, [Argument(Source.Arguments)] object[] arguments, [Argument(Source.Target)] Func<object[], object> method)
        {
            //BeforeExecuting
            Log.Information($"Method: {method.Target}.{name} | Parameters: {JsonConvert.SerializeObject(arguments)}");
            object result = null;
            try
            {
                result = method(arguments);
            }
            catch (Exception ex)
            {
                //OnException
                Log.Error($"Method: {method.Target}.{name} | Parameters: {JsonConvert.SerializeObject(arguments)} | {ex.Message}");
            }
            finally
            {
                //AfterExecuted
            }

            return result;
        }
    }
}
