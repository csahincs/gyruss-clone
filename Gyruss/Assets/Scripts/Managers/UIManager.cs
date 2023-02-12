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

        /// <summary>
        /// Initializes menu elements list
        /// </summary>
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

        /// <summary>
        /// Initializes menu elements, and opens first menu
        /// </summary>
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

        /// <summary>
        /// Event handler for game start event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameStartEventHandler(object sender, EventArgs e)
        {
            OpenGameMenu();
        }
        
        /// <summary>
        /// Event handler for game end event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameEndEventHandler(object sender, EventArgs e)
        {
            OpenResultMenu();
        }

        /// <summary>
        /// Closes all menu elements, and opens main menu
        /// </summary>
        private void OpenMainMenu()
        {
            CloseAllMenuElements();
            MainMenu.Show();
        }

        /// <summary>
        /// Closes all menu elements, and opens game menu
        /// </summary>
        private void OpenGameMenu()
        {
            CloseAllMenuElements();
            GameMenu.Show();
        }
        
        /// <summary>
        /// Closes all menu elements, and opens result menu
        /// </summary>
        private void OpenResultMenu()
        {
            CloseAllMenuElements();
            ResultMenu.Show();
        }

        /// <summary>
        /// Closes all menus
        /// </summary>
        private void CloseAllMenuElements()
        {
            for (int i = 0; i < _menuElements.Count; i++)
            {
                _menuElements[i].Close();
            }
        }
    }
}
