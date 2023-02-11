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

        public void Initialize(int damage, Vector3 direction)
        {
            Damage = damage;
            Direction = direction;
            StartCoroutine(MoveCoroutine());
        }

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
