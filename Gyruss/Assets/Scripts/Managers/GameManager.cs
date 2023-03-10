using System;
using Controllers;
using Objects;
using UnityEngine;
using Utility;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public Camera Camera { get; private set; }
        
        private PlayableShip PlayableShip { get; set; }
        public float PlayableShipDiameter { get; private set; }

        private int _score;
        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                ScoreUpdateEventHandler?.Invoke(this, _score);
            }
        }
        public EventHandler<int> ScoreUpdateEventHandler;

        public EventHandler GameStartEventHandler;
        public EventHandler GameEndEventHandler;

        /// <summary>
        /// Sets main camera and resets game scene
        /// </summary>
        public override void Awake()
        {
            base.Awake();
            
            Camera = Camera.main;
            ResetGameScene();
        }

        /// <summary>
        /// Starts the game
        /// </summary>
        public void StartGame()
        {
            GameStartEventHandler?.Invoke(this, EventArgs.Empty);
            SetupGameScene();
        }

        /// <summary>
        /// Ends the game
        /// </summary>
        public void EndGame()
        {
            GameEndEventHandler?.Invoke(this, EventArgs.Empty);
            ResetGameScene();
        }

        /// <summary>
        /// Create playable ship and initializes player controller and enemy spawn controller accordingly
        /// </summary>
        private void SetupGameScene()
        {
            if (PlayableShip != null)
            {
                ResetGameScene();
            }
            
            Score = 0;
            PlayableShipDiameter = Camera.orthographicSize;
            PlayableShip = PoolManager.Instance.PlayableShipPool.Get();
            PlayerController.Instance.Initialize(PlayableShip);

            float width = GyrussUtility.GetPositionInsideScreen(Camera, Vector3.right * PlayableShipDiameter).x;
            float height = GyrussUtility.GetPositionInsideScreen(Camera, Vector3.up * PlayableShipDiameter).y;
            
            PlayableShip.transform.position = Vector3.down * (width < height ? width : height);
            PlayableShipDiameter = Mathf.Abs(PlayableShip.transform.position.y);
            PlayableShip.Initialize(5);

            EnemySpawnController.Instance.Initialize(5);
        }

        /// <summary>
        /// Clears game scene
        /// </summary>
        private void ResetGameScene()
        {
            if (PlayableShip != null)
            {
                PoolManager.Instance.PlayableShipPool.Release(PlayableShip);
            }
            
            PlayableShip = null;
            PlayerController.Instance.ReleasePlayableShip();
            EnemySpawnController.Instance.DespawnAllEnemies();
        }
    }
}
