using Objects;
using UnityEngine;
using Utility;

namespace Controllers
{
    public class PlayerController : Singleton<PlayerController>
    {
        private PlayableShip PlayableShip { get; set; }
        
        public void Initialize(PlayableShip playableShip)
        {
            PlayableShip = playableShip;
        }
        
        // Update is called once per frame
        void Update()
        {
            if (PlayableShip == null)
            {
                return;
            }
            
            if (Input.GetKeyDown(KeyCode.W))
            {
                PlayableShip.LinearDirection = -1f;
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                PlayableShip.LinearDirection = 0f;
            }
            
            if (Input.GetKeyDown(KeyCode.S))
            {
                PlayableShip.LinearDirection = 1f;
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                PlayableShip.LinearDirection = 0f;
            }
            
            if (Input.GetKeyDown(KeyCode.A))
            {
                PlayableShip.AngularDirection = -1f;
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                PlayableShip.AngularDirection = 0f;
            }
            
            if (Input.GetKeyDown(KeyCode.D))
            {
                PlayableShip.AngularDirection = 1f;
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                PlayableShip.AngularDirection = 0f;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayableShip.Shoot();
            }
        }
    }
}
