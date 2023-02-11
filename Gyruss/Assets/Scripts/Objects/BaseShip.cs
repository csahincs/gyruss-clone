using Managers;
using UnityEngine;
using Utility;

namespace Objects
{
    public abstract class BaseShip : MonoBehaviour
    {
        public int Hp { get; private set; }

        public float AngularDirection { get; set; }
        public float LinearDirection { get; set; }

        protected float AngularSpeed { get; set; }
        protected float LinearSpeed { get; set; }

        public virtual void Initialize(int hp)
        {
            Hp = hp;
        }

        protected virtual void Update()
        {
            Vector3 currentPosition = transform.position;
            Vector3 newPosition =
                currentPosition + currentPosition.normalized * (LinearDirection * LinearSpeed * Time.deltaTime);

            transform.position = GyrussUtility.GetPositionInsideScreen(GameManager.Instance.Camera, 
                currentPosition, newPosition);
            
            transform.RotateAround(Vector3.zero, Vector3.forward, 
                AngularDirection * AngularSpeed * Time.deltaTime);
        }
        
        public void TakeDamage(int damage)
        {
            Hp -= damage;
        }

        public abstract void Despawn();
    }
}
