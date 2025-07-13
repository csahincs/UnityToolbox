using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Attributes.Editor.CustomEditors
{
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class MethodButtonEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();
            InspectorElement.FillDefaultInspector(root, serializedObject, this);
            
            var methods = target.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        
            foreach (var method in methods)
            {
                var methodButton = method.GetCustomAttribute<MethodButton>();
        
                if(methodButton is null)
                    continue;
                
                var label = string.IsNullOrEmpty(methodButton.MethodName) ? method.Name : methodButton.MethodName;
        
                var button = new Button()
                {
                    text = label,
                };
        
                button.clicked += () =>
                {
                    method.Invoke(target, null);
                };
                root.Add(button);
            }
            
            return root;
        }
    }
}
