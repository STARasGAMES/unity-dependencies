using UnityEngine;

namespace SaG.Dependencies.Singletons
{
    internal sealed class FindObjectOfTypeSingletonResolver : ISingletonResolver
    {
        public T Resolve<T>() where T : Object
        {
            return Object.FindObjectOfType<T>();
        }
    }
}