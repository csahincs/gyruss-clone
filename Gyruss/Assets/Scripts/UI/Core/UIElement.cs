using UnityEngine;

namespace UI.Core
{
    public abstract class UIElement : MonoBehaviour
    {
        public abstract void Initialize();
        
        /// <summary>
        /// Enables ui elements game object
        /// </summary>
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Disables ui elements game object
        /// </summary>
        public virtual void Close()
        {
            gameObject.SetActive(false);
        }
    }
}