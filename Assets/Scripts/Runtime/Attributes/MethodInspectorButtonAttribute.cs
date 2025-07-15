using System;
using UnityEngine;

namespace Runtime.Attributes
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class MethodInspectorButtonAttribute : PropertyAttribute
    {
        public string MethodName { get; }
        
        public MethodInspectorButtonAttribute(string methodName = null)
        {
            MethodName = methodName;
        }
    }
}
