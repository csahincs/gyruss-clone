using Managers;
using UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenu : UIElement
    {
        [SerializeField] private Button PlayButton;
        
        /// <summary>
        /// Initializes main menu elements
        /// </summary>
        public override void Initialize()
        {
            PlayButton.onClick.RemoveAllListeners();
            PlayButton.onClick.AddListener(GameManager.Instance.StartGame);
        }
    }
}
