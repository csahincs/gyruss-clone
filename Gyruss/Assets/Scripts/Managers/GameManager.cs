using Controllers;
using Objects;
using UnityEngine;
using Utility;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public Camera Camera { get; private set; }

        public float PlayableShipDiameter { get; private set; }

        public override void Awake()
        {
            base.Awake();
            
            Camera = Camera.main;
            SetupGameScene();
        }

        private void SetupGameScene()
        {
            PlayableShipDiameter = Camera.orthographicSize;
            PlayableShip playableShip = PoolManager.Instance.PlayableShipPool.Get();
            PlayerController.Instance.Initialize(playableShip);

            float width = GyrussUtility.GetPositionInsideScreen(Camera, Vector3.right * PlayableShipDiameter).x;
            float height = GyrussUtility.GetPositionInsideScreen(Camera, Vector3.up * PlayableShipDiameter).y;
            
            playableShip.transform.position = Vector3.down * (width < height ? width : height);
            PlayableShipDiameter = Mathf.Abs(playableShip.transform.position.y);
            playableShip.Initialize(5);

            EnemySpawnController.Instance.Initialize(5);
        }
    }
}
