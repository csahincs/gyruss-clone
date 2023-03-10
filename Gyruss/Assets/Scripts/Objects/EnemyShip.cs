using System;
using Managers;
using UnityEngine;

namespace Objects
{
    public class EnemyShip : BaseShip
    {
        public EventHandler<EnemyShip> DespawnEventHandler;
        
        /// <summary>
        /// Sets initial speed, direction and diameter properties
        /// </summary>
        /// <param name="hp">Initial health point</param>
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

        /// <summary>
        /// Despawns the ship, and increases score
        /// </summary>
        public override void Despawn()
        {
            DespawnEventHandler?.Invoke(this, this);

            GameManager.Instance.Score += Mathf.FloorToInt((1 - CurrentDiameter / MaxDiameter) * 10f);
            PoolManager.Instance.EnemyShipPool.Release(this);
        }
    }
}
