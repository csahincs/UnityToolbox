namespace CSToolbox.Runtime.Attributes
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public class HideIfAttribute : ConditionalVisibilityAttribute
    {
        public HideIfAttribute(string conditionFieldName) : base(conditionFieldName)
        {
        }

        public override bool ShouldShow(bool conditionValue) => !conditionValue;
    }
}
