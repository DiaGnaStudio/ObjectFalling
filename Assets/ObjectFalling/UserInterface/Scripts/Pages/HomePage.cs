using DiaGna.ObjectFalling.Gameplay;
using DiaGna.UserInterface;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace DiaGna.ObjectFalling.UserInterface
{
    public class HomePage : UIPageBase
    {
        public static event Action OnPageLoaded;

        [SerializeField] private Button m_PlayButton;

        protected override void OnLoadPage()
        {
        }

        protected override void OnOpenPage()
        {
            OnPageLoaded?.Invoke();
            m_PlayButton.onClick.AddListener(StartGame);
        }

        protected override void OnClosePage()
        {
            m_PlayButton.onClick.RemoveListener(StartGame);
        }

        private void StartGame()
        {
            GlobalEvent.StartGame();
        }
    }
}