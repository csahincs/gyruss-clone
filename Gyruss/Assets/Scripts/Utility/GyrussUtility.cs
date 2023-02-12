using UnityEngine;

namespace Utility
{
    public static class GyrussUtility
    {
        /// <summary>
        /// Clamps given position accordingly to screen
        /// </summary>
        /// <param name="camera">Camera viewport</param>
        /// <param name="pos">Position to be clamped</param>
        /// <returns></returns>
        public static Vector3 GetPositionInsideScreen(Camera camera, Vector3 pos)
        {
            Vector3 newViewportPosition = camera.WorldToViewportPoint(pos);
            
            newViewportPosition.x = Mathf.Clamp(newViewportPosition.x, 0.07f, 0.93f);
            newViewportPosition.y = Mathf.Clamp(newViewportPosition.y, 0.07f, 0.93f);

            return camera.ViewportToWorldPoint(newViewportPosition);
        }

        /// <summary>
        /// Rotates given vector around z axis by the given angle
        /// </summary>
        /// <param name="vector">Vector to be rotated</param>
        /// <param name="angle">Angle to rotate</param>
        /// <returns></returns>
        public static Vector3 RotateVector(Vector3 vector, float angle)
        {
            return Quaternion.AngleAxis(angle, Vector3.forward) * vector;
        }
    }
}
