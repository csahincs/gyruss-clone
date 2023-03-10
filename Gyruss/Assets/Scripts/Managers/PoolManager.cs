using Objects;
using UnityEngine;
using UnityEngine.Pool;
using Utility;

namespace Managers
{
    /// <summary>
    /// A singleton manager that handles object to be pooled
    /// </summary>
    public class PoolManager : Singleton<PoolManager>
    {
        public bool CollectionChecks = true;
        public int MaxPoolSize = 10;

        #region Playable Ship

        [SerializeField] private PlayableShip PlayableShip;

        private IObjectPool<PlayableShip> _playableShipPool;
        public IObjectPool<PlayableShip> PlayableShipPool =>
            _playableShipPool ??= new LinkedPool<PlayableShip>(CreatePlayableShipPooledItem, OnTakeFromPool, 
                OnReturnedToPool, OnDestroyPoolObject, CollectionChecks, MaxPoolSize);

        private PlayableShip CreatePlayableShipPooledItem()
        {
            var go = Instantiate(PlayableShip);
            return go;
        }

        // Called when an item is returned to the pool using Release
        private void OnReturnedToPool(PlayableShip element)
        {
            element.gameObject.SetActive(false);
        }

        // Called when an item is taken from the pool using Get
        private void OnTakeFromPool(PlayableShip element)
        {
            element.gameObject.SetActive(true);
        }

        // If the pool capacity is reached then any items returned will be destroyed.
        // We can control what the destroy behavior does, here we destroy the GameObject.
        private void OnDestroyPoolObject(PlayableShip element)
        {
            Destroy(element.gameObject);
        }

        #endregion
        
        #region Enemy Ship

        [SerializeField] private EnemyShip EnemyShip;

        private IObjectPool<EnemyShip> _enemyShipPool;
        public IObjectPool<EnemyShip> EnemyShipPool =>
            _enemyShipPool ??= new LinkedPool<EnemyShip>(CreateEnemyShipPooledItem, OnTakeFromPool, 
                OnReturnedToPool, OnDestroyPoolObject, CollectionChecks, MaxPoolSize);

        private EnemyShip CreateEnemyShipPooledItem()
        {
            var go = Instantiate(EnemyShip);
            return go;
        }

        // Called when an item is returned to the pool using Release
        private void OnReturnedToPool(EnemyShip element)
        {
            element.gameObject.SetActive(false);
        }

        // Called when an item is taken from the pool using Get
        private void OnTakeFromPool(EnemyShip element)
        {
            element.gameObject.SetActive(true);
        }

        // If the pool capacity is reached then any items returned will be destroyed.
        // We can control what the destroy behavior does, here we destroy the GameObject.
        private void OnDestroyPoolObject(EnemyShip element)
        {
            Destroy(element.gameObject);
        }

        #endregion
        
        #region Bullet

        [SerializeField] private Bullet Bullet;

        private IObjectPool<Bullet> _bulletPool;
        public IObjectPool<Bullet> BulletPool =>
            _bulletPool ??= new LinkedPool<Bullet>(CreateBulletPooledItem, OnTakeFromPool, 
                OnReturnedToPool, OnDestroyPoolObject, CollectionChecks, MaxPoolSize);

        private Bullet CreateBulletPooledItem()
        {
            var go = Instantiate(Bullet);
            return go;
        }

        // Called when an item is returned to the pool using Release
        private void OnReturnedToPool(Bullet element)
        {
            element.gameObject.SetActive(false);
        }

        // Called when an item is taken from the pool using Get
        private void OnTakeFromPool(Bullet element)
        {
            element.gameObject.SetActive(true);
        }

        // If the pool capacity is reached then any items returned will be destroyed.
        // We can control what the destroy behavior does, here we destroy the GameObject.
        private void OnDestroyPoolObject(Bullet element)
        {
            Destroy(element.gameObject);
        }

        #endregion
    }
}