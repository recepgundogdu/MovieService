using AspectInjector.Broker;
using Newtonsoft.Json;
using System;
using System.Runtime.Caching;

namespace MovieService.Core.Aspects
{
    [Aspect(Scope.Global)]
    [Injection(typeof(Caching))]
    public class Caching : Attribute
    {
        [Advice(Kind.Around, Targets = Target.Method)]
        public object HandleMethod([Argument(Source.Name)] string name, [Argument(Source.Arguments)] object[] arguments, [Argument(Source.Target)] Func<object[], object> method)
        {
            object result = null;
            string key = $"{method?.Target?.ToString()}.{name}.{JsonConvert.SerializeObject(arguments)}";
            ObjectCache cache = MemoryCache.Default;
            var isCached = cache.Contains(key);
            if (isCached)
            {
                result = cache[key];
            }
            else
            {
                result = method(arguments);
                cache.Add(key, result, null);
            }
            return result;
        }
    }
}
