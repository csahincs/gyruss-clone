using Managers;
using UnityEngine;

namespace Objects
{
    public class PlayableShip : BaseShip
    {
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

        public void Shoot()
        {
            Bullet bullet = PoolManager.Instance.BulletPool.Get();
            bullet.transform.position = transform.position;
            Vector3 bulletDirection = -transform.position;
            bulletDirection.z = 0;
            bullet.Initialize(1, bulletDirection);
        }

        public override void Despawn()
        {
            PoolManager.Instance.PlayableShipPool.Release(this);
        }
    }
}
