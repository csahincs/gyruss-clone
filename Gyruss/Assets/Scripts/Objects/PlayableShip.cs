using Managers;
using UnityEngine;

namespace Objects
{
    public class PlayableShip : BaseShip
    {
        /// <summary>
        /// Sets initial speed, direction and diameter properties
        /// </summary>
        /// <param name="hp">Initial health point</param>
        public override void Initialize(int hp)
        {
            base.Initialize(hp);

            AngularSpeed = 50f;
            AngularDirection = 0f;
            
            LinearSpeed = 0f;
            LinearDirection = 0f;

            MaxDiameter = GameManager.Instance.PlayableShipDiameter;
            CurrentDiameter = GameManager.Instance.PlayableShipDiameter;
        }

        /// <summary>
        /// Shots a bullet towards the center of the screen
        /// </summary>
        public void Shoot()
        {
            Bullet bullet = PoolManager.Instance.BulletPool.Get();
            bullet.transform.position = transform.position;
            Vector3 bulletDirection = -transform.position;
            bulletDirection.z = 0;
            bullet.Initialize(1, bulletDirection);
        }

        /// <summary>
        /// Despawns the ship
        /// </summary>
        public override void Despawn()
        {
            PoolManager.Instance.PlayableShipPool.Release(this);
        }
    }
}
