using CSToolbox.Runtime.Gizmos;
using UnityEngine;

namespace Playground
{
    public class GizmosPlayground : MonoBehaviour
    {
        public Vector3 _localPoint1 = new Vector3(0, -1, 0);
        public Vector3 _localPoint2 = new Vector3(0, 1, 0);
        public float _radius = 0.5f;
        public Vector3 _direction = Vector3.forward;
        public float _distance = 3f;

        private void OnDrawGizmos()
        {
            GizmosUtility.DrawCapsuleCast(_localPoint1, _localPoint2, _radius, _direction, _distance, Color.red);
        }
    }
}
