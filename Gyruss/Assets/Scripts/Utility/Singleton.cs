using UnityEngine;

namespace Utility
{
    /// <summary>
    /// A generic singleton class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T _instance;
    
        public static T Instance 
        {
            get 
            {
                if (_instance != null) return _instance;
            
                _instance = FindObjectOfType<T> ();

                if (_instance != null) return _instance;

                GameObject obj = new GameObject(typeof(T).Name);
                _instance = obj.AddComponent<T>();
                return _instance;
            }
        }
 
        public virtual void Awake ()
        {
            if (_instance == null) 
            {
                _instance = this as T;
                DontDestroyOnLoad (gameObject);
            }
            else 
            {
                Destroy (gameObject);
            }
        }
    }
}