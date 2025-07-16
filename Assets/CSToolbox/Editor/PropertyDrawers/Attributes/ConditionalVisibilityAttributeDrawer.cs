using System.Reflection;
using CSToolbox.Runtime.Attributes;
using UnityEditor;
using UnityEngine;

namespace CSToolbox.Editor.PropertyDrawers.Attributes
{
    [CustomPropertyDrawer(typeof(ConditionalVisibilityAttribute), useForChildren: true)]
    public class ConditionalVisibilityAttributeDrawer : PropertyDrawer
    {
        private bool _show;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (!_show)
                return 0;
            
            return EditorGUI.GetPropertyHeight(property, label);
        }
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var conditionalVisibilityAttribute = attribute as ConditionalVisibilityAttribute;
            if (conditionalVisibilityAttribute is null)
            {
                return;
            }
            
            var evaluatedCondition = EvaluateCondition(property.serializedObject.targetObject, 
                conditionalVisibilityAttribute.ConditionFieldName);
            _show = conditionalVisibilityAttribute.ShouldShow(evaluatedCondition);

            if (!_show)
            {
                return;
            }

            EditorGUILayout.PropertyField(property, label);
        }

        private bool EvaluateCondition(object targetObject, string conditionField)
        {
            var type = targetObject.GetType();
            var field = type.GetField(conditionField, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (field != null && field.FieldType == typeof(bool))
            {
                return (bool)field.GetValue(targetObject);
            }

            var prop = type.GetProperty(conditionField, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (prop != null && prop.PropertyType == typeof(bool))
            {
                return (bool)prop.GetValue(targetObject);
            }

            Debug.LogWarning($"Could not evaluate condition: {conditionField}");
            return false;
        }
    }
}
