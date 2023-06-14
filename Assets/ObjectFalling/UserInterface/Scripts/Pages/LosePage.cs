using DiaGna.ObjectFalling.Gameplay;
using DiaGna.UserInterface;
using UnityEngine;
using UnityEngine.UI;

namespace DiaGna.ObjectFalling.UserInterface
{
    public class LosePage : UIPageBase
    {
        [SerializeField] private Button m_RetryButton;

        protected override void OnLoadPage()
        {
        }

        protected override void OnOpenPage()
        {
            m_RetryButton.onClick.AddListener(Retring);
        }

        protected override void OnClosePage()
        {
            m_RetryButton.onClick.RemoveListener(Retring);
        }

        private void Retring()
        {
            GlobalEvent.StartGame();
        }
    }
}
