using System;
using Managers;

namespace Objects
{
    public class EnemyShip : BaseShip
    {
        public EventHandler<EnemyShip> DespawnEventHandler;
        
        public override void Initialize(int hp)
        {
            base.Initialize(hp);
            
            AngularSpeed = 50f;
            AngularDirection = 1;
            
            LinearSpeed = 1f;
            LinearDirection = 1f;

            MaxDiameter = GameManager.Instance.PlayableShipDiameter * (4 / 5f);
            CurrentDiameter = 0.1f;
        }

        public override void Despawn()
        {
            DespawnEventHandler?.Invoke(this, this);
            PoolManager.Instance.EnemyShipPool.Release(this);
        }
    }
}
