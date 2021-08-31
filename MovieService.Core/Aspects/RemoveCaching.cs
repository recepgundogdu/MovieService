using AspectInjector.Broker;
using System;
using System.Runtime.Caching;

namespace MovieService.Core.Aspects
{
    [Aspect(Scope.Global)]
    [Injection(typeof(Caching))]
    public class RemoveCaching : Attribute
    {
        [Advice(Kind.Around, Targets = Target.Method)]
        public object HandleMethod([Argument(Source.Name)] string name, [Argument(Source.Arguments)] object[] arguments, [Argument(Source.Target)] Func<object[], object> method)
        {
            ObjectCache cache = MemoryCache.Default;

            foreach (var item in cache)
            {
                cache.Remove(item.Key);
            }
        
            return null;
        }
    }
}
