using UnityEditor;
using UnityEngine;

namespace CSToolbox.Runtime.Gizmos
{
    public static class GizmosUtility
    {
        public static void DrawCapsule(Vector3 point1, Vector3 point2, float radius, Color color)
        {
            Handles.color = color;
            
            var up = (point2 - point1).normalized;
            var forward = Vector3.Slerp(up, -up, 0.5f);
            var right = Vector3.Cross(up, forward).normalized;
            forward = Vector3.Cross(right, up).normalized;
            
            Handles.DrawWireDisc(point1, up, radius);
            Handles.DrawWireDisc(point2, up, radius);
            
            Handles.DrawLine(point1 + right * radius, point2 + right * radius);
            Handles.DrawLine(point1 - right * radius, point2 - right * radius);
            Handles.DrawLine(point1 + forward * radius, point2 + forward * radius);
            Handles.DrawLine(point1 - forward * radius, point2 - forward * radius);
            
            Handles.DrawWireArc(point1, right, forward * radius, 180, radius);
            Handles.DrawWireArc(point1, forward, -right * radius, 180, radius);
            Handles.DrawWireArc(point2, right, -forward * radius, 180, radius);
            Handles.DrawWireArc(point2, forward, right * radius, 180, radius);
        }

        public static void DrawCapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, 
            float distance, Color color = default)
        {
            DrawCapsule(point1, point2, radius, color);

            var offset = direction.normalized * distance;
            DrawCapsule(point1 + offset, point2 + offset, radius, color);

            Handles.DrawDottedLine(point1, point1 + offset, 3f);
            Handles.DrawDottedLine(point2, point2 + offset, 3f);
        }
    }
}
