#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;

namespace SaG.Dependencies
{
    public static class DependencyInvalidator
    {
        public static uint version { get; private set; }

        static DependencyInvalidator()
        {
            EditorApplication.hierarchyChanged += InvalidateAllDependencies;
        }

        public static void InvalidateAllDependencies()
        {
            version++;
        }
    }
}
#endif