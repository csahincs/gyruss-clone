using Managers;

namespace Objects
{
    public class PlayableShip : BaseShip
    {
        public override void Initialize(int hp)
        {
            base.Initialize(hp);

            AngularDirection = 0f;
            LinearDirection = 0f;
            
            AngularSpeed = 50f;
            LinearSpeed = 5f;
        }

        public void Shoot()
        {
            
        }

        public override void Despawn()
        {
            PoolManager.Instance.PlayableShipPool.Release(this);
        }
    }
}
