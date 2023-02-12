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

        public override void Initialize()
        {
            ScoreText.text = "0";
            
            ExitButton.onClick.RemoveAllListeners();
            ExitButton.onClick.AddListener(GameManager.Instance.EndGame);
            
            GameManager.Instance.ScoreUpdateEventHandler += ScoreUpdateEventHandler;
        }

        private void ScoreUpdateEventHandler(object sender, int e)
        {
            ScoreText.text = e.ToString();
        }
        
        public override void Show()
        {
            base.Show();
            GameManager.Instance.ScoreUpdateEventHandler += ScoreUpdateEventHandler;
        }

        public override void Close()
        {
            GameManager.Instance.ScoreUpdateEventHandler -= ScoreUpdateEventHandler;
            base.Close();
        }
    }
}
