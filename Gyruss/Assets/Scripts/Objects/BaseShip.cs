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
        
        public float CurrentDiameter { get; set; }
        public float MaxDiameter { get; set; }

        public Vector3 Direction;

        public virtual void Initialize(int hp)
        {
            Hp = hp;
            Direction = transform.position.normalized;
        }

        protected virtual void Update()
        {
            CurrentDiameter = Mathf.Min(CurrentDiameter + LinearDirection * LinearSpeed * Time.deltaTime, MaxDiameter);
            Direction = GyrussUtility.RotateVector(Direction, AngularDirection * AngularSpeed * Time.deltaTime);
            
            transform.position = Direction * CurrentDiameter + Vector3.back;
            transform.LookAt(Vector3.zero);
        }
        
        public void TakeDamage(int damage)
        {
            Hp -= damage;

            if (Hp <= 0)
            {
                Despawn();
            }
        }

        public abstract void Despawn();
    }
}
