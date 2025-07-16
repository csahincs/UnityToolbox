using UnityEngine;

namespace CSToolbox.Runtime.Attributes
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public class ReadOnlyAttribute : PropertyAttribute
    {
    }
}
