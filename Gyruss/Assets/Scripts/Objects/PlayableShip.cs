using Managers;

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
        }

        public void Shoot()
        {
            Bullet bullet = PoolManager.Instance.BulletPool.Get();
            bullet.transform.position = transform.position;
            bullet.Initialize(1, -transform.position);
        }

        public override void Despawn()
        {
            PoolManager.Instance.PlayableShipPool.Release(this);
        }
    }
}
