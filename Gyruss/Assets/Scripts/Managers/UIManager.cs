using System;
using System.Collections.Generic;
using UI;
using UI.Core;
using UnityEngine;
using Utility;

namespace Managers
{
    public class UIManager : Singleton<UIManager>
    {
        private List<UIElement> _menuElements;

        [SerializeField] private MainMenu MainMenu;
        [SerializeField] private GameMenu GameMenu;
        [SerializeField] private ResultMenu ResultMenu;

        public override void Awake()
        {
            base.Awake();

            _menuElements = new List<UIElement>()
            {
                MainMenu,
                GameMenu,
                ResultMenu,
            };
        }

        private void Start()
        {
            foreach (var t in _menuElements)
            {
                t.Initialize();
            }
            
            OpenMainMenu();
            
            GameManager.Instance.GameStartEventHandler += GameStartEventHandler;
            GameManager.Instance.GameEndEventHandler += GameEndEventHandler;
        }

        private void GameStartEventHandler(object sender, EventArgs e)
        {
            OpenGameMenu();
        }
        
        private void GameEndEventHandler(object sender, EventArgs e)
        {
            OpenResultMenu();
        }

        private void OpenMainMenu()
        {
            CloseAllMenuElements();
            MainMenu.Show();
        }

        public void OpenGameMenu()
        {
            CloseAllMenuElements();
            GameMenu.Show();
        }

        public void OpenResultMenu()
        {
            CloseAllMenuElements();
            ResultMenu.Show();
        }

        private void CloseAllMenuElements()
        {
            for (int i = 0; i < _menuElements.Count; i++)
            {
                _menuElements[i].Close();
            }
        }
    }
}
