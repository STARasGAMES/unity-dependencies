using UnityEngine;

namespace SaG.Dependencies.Singletons
{
    public interface ISingletonResolver
    {
        T Resolve<T>() where T : Object;
    }
}