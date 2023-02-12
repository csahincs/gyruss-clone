using Managers;
using TMPro;
using UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ResultMenu : UIElement
    {
        [SerializeField] private Button ReplayButton;
        [SerializeField] private TMP_Text ScoreText;
        
        /// <summary>
        /// Initializes result menu elements
        /// </summary>
        public override void Initialize()
        {
            ReplayButton.onClick.RemoveAllListeners();
            ReplayButton.onClick.AddListener(GameManager.Instance.StartGame);
        }

        /// <summary>
        /// Updates result score after opening
        /// </summary>
        public override void Show()
        {
            base.Show();
            ScoreText.text = GameManager.Instance.Score.ToString();
        }
    }
}
