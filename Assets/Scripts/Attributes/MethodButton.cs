using System;
using UnityEngine;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class MethodButton : PropertyAttribute
    {
        public string MethodName { get; }
        
        public MethodButton(string methodName = null)
        {
            MethodName = methodName;
        }
    }
}
