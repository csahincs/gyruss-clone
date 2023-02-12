using Managers;
using TMPro;
using UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameMenu : UIElement
    {
        [SerializeField] private Button ExitButton;
        [SerializeField] private TMP_Text ScoreText;

        /// <summary>
        /// Initializes game menu elements
        /// </summary>
        public override void Initialize()
        {
            ScoreText.text = "0";
            
            ExitButton.onClick.RemoveAllListeners();
            ExitButton.onClick.AddListener(GameManager.Instance.EndGame);
            
            GameManager.Instance.ScoreUpdateEventHandler += ScoreUpdateEventHandler;
        }

        /// <summary>
        /// Updates score text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScoreUpdateEventHandler(object sender, int e)
        {
            ScoreText.text = e.ToString();
        }
        
        /// <summary>
        /// Subscribe to score update event after opening
        /// </summary>
        public override void Show()
        {
            base.Show();
            GameManager.Instance.ScoreUpdateEventHandler += ScoreUpdateEventHandler;
        }
        
        /// <summary>
        /// Unsubscribe to score update event after opening
        /// </summary>
        public override void Close()
        {
            GameManager.Instance.ScoreUpdateEventHandler -= ScoreUpdateEventHandler;
            base.Close();
        }
    }
}
