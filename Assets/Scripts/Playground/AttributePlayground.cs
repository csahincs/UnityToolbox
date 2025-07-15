using Runtime.Attributes;
using UnityEngine;

namespace Playground
{
    public class AttributePlayground : MonoBehaviour
    {
        [Header("Read Only Attribute")]
        [SerializeField, ReadOnly] private int _intField;
        
        [Space, Header("Conditional Visibility Attribute")]
        [SerializeField] private bool _conditionalVisibilityBoolField;
        [SerializeField, ShowIf(nameof(_conditionalVisibilityBoolField))] private int _showIfField;
        [SerializeField, HideIf(nameof(_conditionalVisibilityBoolField))] private int _hideIfField;
        
        
        [MethodInspectorButton()]
        public void Invoke()
        {
            Debug.LogError("Invoked!");
        }
        
        [MethodInspectorButton()]
        public void Invoke1()
        {
            Debug.LogError("Invoked!");
        }
    }
}
