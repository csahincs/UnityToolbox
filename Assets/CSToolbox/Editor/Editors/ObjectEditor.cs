using CSToolbox.Editor.PropertyDrawers.Attributes;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace CSToolbox.Editor.Editors
{
    [CustomEditor(typeof(Object), editorForChildClasses: true)]
    [CanEditMultipleObjects]
    public class ObjectEditor : UnityEditor.Editor
    {
        private VisualElement _rootElement;
        private MethodInspectorButtonDrawer _methodInspectorButtonDrawer;
        
        public override VisualElement CreateInspectorGUI()
        { 
            _rootElement = new VisualElement();
            
            InspectorElement.FillDefaultInspector(_rootElement, serializedObject, this);
            DrawMethodInspectorButtons();
            
            return _rootElement;
        }

        private void DrawMethodInspectorButtons()
        {
            _methodInspectorButtonDrawer = new MethodInspectorButtonDrawer(target, ref _rootElement);
            _methodInspectorButtonDrawer.Draw();
        }
    }
}
