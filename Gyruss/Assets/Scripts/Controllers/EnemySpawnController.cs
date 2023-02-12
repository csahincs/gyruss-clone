using System.Collections.Generic;
using Managers;
using Objects;
using UnityEngine;
using Utility;
using Random = UnityEngine.Random;

namespace Controllers
{
    public class EnemySpawnController : Singleton<EnemySpawnController>
    {
        private int _leftWaveCount = 0;
        private int _enemyShipLeftInWave;

        public List<EnemyShip> SpawnedEnemies = new List<EnemyShip>();

        /// <summary>
        /// Initializes enemy spawn controller for the current game
        /// </summary>
        /// <param name="waveCount">Total number of enemy waves for the current game</param>
        public void Initialize(int waveCount)
        { 
            _leftWaveCount = waveCount;
            
            PrepareNextWave();
        }

        /// <summary>
        /// Spawns new batch of enemies for the next round. If no wave left, ends the game
        /// </summary>
        private void PrepareNextWave()
        {
            if (_leftWaveCount == 0)
            {
                GameManager.Instance.EndGame();
                return;
            }
            
            int enemySpawnCount = Random.Range(2, 5);
            _enemyShipLeftInWave = enemySpawnCount;

            for (int i = 0; i < enemySpawnCount; i++)
            {
                EnemyShip enemy = PoolManager.Instance.EnemyShipPool.Get();
                enemy.transform.position = GyrussUtility.RotateVector(Vector3.down * 0.2f, 
                    i * (360 / enemySpawnCount));
                enemy.Initialize(1);
                enemy.DespawnEventHandler += EnemyShipDespawnEventHandler;
                SpawnedEnemies.Add(enemy);
            }

            _leftWaveCount--;
        }

        /// <summary>
        /// Checks if the current wave is over or not after every ship despawn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnemyShipDespawnEventHandler(object sender, EnemyShip e)
        {
            e.DespawnEventHandler -= EnemyShipDespawnEventHandler;
            SpawnedEnemies.Remove(e);
            _enemyShipLeftInWave -= 1;
            
            if (_enemyShipLeftInWave <= 0)
            {
                PrepareNextWave();
            }
        }

        /// <summary>
        /// Despawns all enemy ships
        /// </summary>
        public void DespawnAllEnemies()
        {
            foreach (EnemyShip enemy in SpawnedEnemies)
            {
                enemy.DespawnEventHandler -= EnemyShipDespawnEventHandler;
                PoolManager.Instance.EnemyShipPool.Release(enemy);
            }
            
            SpawnedEnemies.Clear();
        }
    }
}
