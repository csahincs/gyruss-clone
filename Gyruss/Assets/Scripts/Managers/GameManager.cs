using Controllers;
using Objects;
using UnityEngine;
using Utility;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public Camera Camera { get; private set; }

        public override void Awake()
        {
            base.Awake();
            
            Camera = Camera.main;
            SetupGameScene();
        }

        public void SetupGameScene()
        {
            PlayableShip playableShip = PoolManager.Instance.PlayableShipPool.Get();
            PlayerController.Instance.Initialize(playableShip);
            
            playableShip.Initialize(5);
            playableShip.transform.position = Vector3.down * 100f;
            playableShip.transform.position =
                GyrussUtility.GetPositionInsideScreen(Camera, Vector3.zero, 
                    playableShip.transform.position);
        }
    }
}
