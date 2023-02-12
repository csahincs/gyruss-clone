using System.Collections;
using Managers;
using UnityEngine;

namespace Objects
{
    public class Bullet : MonoBehaviour
    {
        private int Damage { get; set; }
        private float Speed => 5f;

        private Vector3 Direction { get; set; }

        private const float LIFETIME = 2f;

        /// <summary>
        /// Initializes the bullet with the given damage and direction
        /// </summary>
        /// <param name="damage">Damage dealt on impact</param>
        /// <param name="direction">Movement direction</param>
        public void Initialize(int damage, Vector3 direction)
        {
            Damage = damage;
            Direction = direction;
            StartCoroutine(MoveCoroutine());
        }

        /// <summary>
        /// Moves bullet in the initialized direction during its lifetime
        /// </summary>
        /// <returns></returns>
        private IEnumerator MoveCoroutine()
        {
            float lifetime = 0;
            while (lifetime < LIFETIME)
            {
                transform.Translate(Direction * (Speed * Time.deltaTime));
                yield return new WaitForEndOfFrame();
                lifetime += Time.deltaTime;
            }
            PoolManager.Instance.BulletPool.Release(this);
        }

        /// <summary>
        /// Detects enemy ship and deals damage
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                if (other.TryGetComponent(out EnemyShip enemyShip))
                {
                    enemyShip.TakeDamage(Damage);
                    StopCoroutine(MoveCoroutine());
                    PoolManager.Instance.BulletPool.Release(this);
                }
            }
        }
    }
}
