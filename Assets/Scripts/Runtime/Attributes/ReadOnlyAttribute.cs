using UnityEngine;

namespace Runtime.Attributes
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public class ReadOnlyAttribute : PropertyAttribute
    {
    }
}
