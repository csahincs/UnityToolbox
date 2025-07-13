using Attributes;
using UnityEngine;

namespace Playground
{
    public class AttributePlayground : MonoBehaviour
    {
        [SerializeField, ReadOnly] private int _intField;

        [MethodButton("Test")]
        public void Invoke(int param1)
        {
            Debug.LogError("Invoked!");
        }
    }
}
