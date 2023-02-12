using Objects;
using UnityEngine;
using Utility;

namespace Controllers
{
    public class PlayerController : Singleton<PlayerController>
    {
        private PlayableShip PlayableShip { get; set; }
        
        /// <summary>
        /// Sets the playable ship property 
        /// </summary>
        /// <param name="playableShip">Ship to be controlled</param>
        public void Initialize(PlayableShip playableShip)
        {
            PlayableShip = playableShip;
        }
        
        
        /// <summary>
        /// Checks movement and firing inputs
        /// </summary>
        void Update()
        {
            if (PlayableShip == null)
            {
                return;
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

        /// <summary>
        /// Resets the playable ship property
        /// </summary>
        public void ReleasePlayableShip()
        {
            PlayableShip = null;
        }
    }
}
