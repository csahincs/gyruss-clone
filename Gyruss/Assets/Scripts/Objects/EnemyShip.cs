using Managers;

namespace Objects
{
    public class EnemyShip : BaseShip
    {
        public override void Initialize(int hp)
        {
            base.Initialize(hp);

            AngularDirection = 100f;
            LinearDirection = 0.1f;
        }

        public override void Despawn()
        {
            PoolManager.Instance.EnemyShipPool.Release(this);
        }
    }
}
