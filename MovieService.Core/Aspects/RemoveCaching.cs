using AspectInjector.Broker;
using System;
using System.Runtime.Caching;

namespace MovieService.Core.Aspects
{
    [Aspect(Scope.Global)]
    [Injection(typeof(RemoveCaching))]
    public class RemoveCaching : Attribute
    {
        [Advice(Kind.Around, Targets = Target.Method)]
        public object HandleMethod([Argument(Source.Name)] string name, [Argument(Source.Arguments)] object[] arguments, [Argument(Source.Target)] Func<object[], object> method)
        {
            object result = null;
            ObjectCache cache = MemoryCache.Default;

            foreach (var item in cache)
            {
                if (item.Key.Contains(method?.Target?.ToString()))
                    cache.Remove(item.Key);
            }
            result = method(arguments);
            return result;
        }
    }
}
