using System.Reflection;
using Runtime.Attributes;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor.CustomPropertyDrawers
{
    public class MethodInspectorButtonDrawer
    {
        private readonly Object _targetObject;
        private readonly MethodInfo[] _methods;
        private readonly VisualElement _container;
        
        public MethodInspectorButtonDrawer(Object targetObject, ref VisualElement container)
        {
            _targetObject = targetObject;
            _methods = targetObject.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Static | 
                                                         BindingFlags.Public | BindingFlags.NonPublic); 
            _container = container;
        }
        
        public void Draw()
        {
            foreach (var method in _methods)
            {
                var attribute = method.GetCustomAttribute<MethodInspectorButtonAttribute>();
                if(attribute is null)
                    continue;

                var name = attribute.MethodName ?? method.Name;
                var button = new Button(() => method.Invoke(_targetObject, null))
                {
                    text = name,
                };
                _container.Add(button);
            }
        } 
    }
}
