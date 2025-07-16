using UnityEngine;

namespace CSToolbox.Runtime.Attributes
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public abstract class ConditionalVisibilityAttribute : PropertyAttribute
    {
        public readonly string ConditionFieldName;

        protected ConditionalVisibilityAttribute(string conditionFieldName)
        {
            ConditionFieldName = conditionFieldName;
        }
        
        public abstract bool ShouldShow(bool conditionValue);
    }
}
