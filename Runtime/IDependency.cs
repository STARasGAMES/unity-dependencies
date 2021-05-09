using System;
using UnityEngine;


namespace SaG.Dependencies
{
    public interface IDependency
    {
        Type type { get; }

        DependencySource source { get; }

        Component explicitReference { get; }

#if UNITY_GUID_BASED_REFERENCES
    GuidReference globalReference { get; }
#endif

        bool CanResolve(Component self);

        Component Resolve(Component self);

        bool TryResolve(Component self, out Component component);
    }
}