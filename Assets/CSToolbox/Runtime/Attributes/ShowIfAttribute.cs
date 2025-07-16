namespace CSToolbox.Runtime.Attributes
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public class ShowIfAttribute : ConditionalVisibilityAttribute
    {
        public ShowIfAttribute(string conditionFieldName) : base(conditionFieldName)
        {
        }

        public override bool ShouldShow(bool conditionValue) => conditionValue;
    }
}
