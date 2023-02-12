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


        public void Initialize(int waveCount)
        {
            if (_leftWaveCount > 0)
            {
                return;
            }

            _leftWaveCount = waveCount;
            
            PrepareNextWave();
        }

        private void PrepareNextWave()
        {
            int enemySpawnCount = Random.Range(2, 5);
            _enemyShipLeftInWave = enemySpawnCount;

            for (int i = 0; i < enemySpawnCount; i++)
            {
                EnemyShip enemy = PoolManager.Instance.EnemyShipPool.Get();
                enemy.transform.position = GyrussUtility.RotateVector(Vector3.down * 0.2f, 
                    i * (360 / enemySpawnCount));
                enemy.Initialize(1);
                enemy.DespawnEventHandler += EnemyShipDespawnEventHandler;
            }

            _leftWaveCount--;
        }

        private void EnemyShipDespawnEventHandler(object sender, EnemyShip e)
        {
            e.DespawnEventHandler -= EnemyShipDespawnEventHandler;

            _enemyShipLeftInWave--;

            if (_leftWaveCount == 0)
            {
                // todo(cem): finish current level
            }
            
            if (_enemyShipLeftInWave <= 0)
            {
                PrepareNextWave();
            }
        }
    }
}
