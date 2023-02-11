using UnityEngine;

namespace Utility
{
    public static class GyrussUtility
    {
        public static Vector3 GetPositionInsideScreen(Camera camera, Vector3 oldPosition, Vector3 newPosition)
        {
            Vector3 newViewportPosition = camera.WorldToViewportPoint(newPosition);
            
            newViewportPosition.x = Mathf.Clamp(newViewportPosition.x, 0.07f, 0.93f);
            newViewportPosition.y = Mathf.Clamp(newViewportPosition.y, 0.07f, 0.93f);

            return camera.ViewportToWorldPoint(newViewportPosition);
        }
    }
}