using UnityEngine;

namespace Utility
{
    public static class GyrussUtility
    {
        public static Vector3 GetPositionInsideScreen(Camera camera, Vector3 pos)
        {
            Vector3 newViewportPosition = camera.WorldToViewportPoint(pos);
            
            newViewportPosition.x = Mathf.Clamp(newViewportPosition.x, 0.07f, 0.93f);
            newViewportPosition.y = Mathf.Clamp(newViewportPosition.y, 0.07f, 0.93f);

            return camera.ViewportToWorldPoint(newViewportPosition);
        }

        public static Vector3 RotateVector(Vector3 vector, float angle)
        {
            return Quaternion.AngleAxis(angle, Vector3.forward) * vector;
        }
    }
}
