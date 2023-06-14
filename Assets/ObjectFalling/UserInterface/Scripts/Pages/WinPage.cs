using DiaGna.ObjectFalling.Gameplay;
using DiaGna.UserInterface;
using UnityEngine;
using UnityEngine.UI;

namespace DiaGna.ObjectFalling.UserInterface
{
    public class WinPage : UIPageBase
    {
        [SerializeField] private Button m_NextButton;

        protected override void OnLoadPage()
        {
        }

        protected override void OnOpenPage()
        {
            m_NextButton.onClick.AddListener(Retring);
        }

        protected override void OnClosePage()
        {
            m_NextButton.onClick.RemoveListener(Retring);
        }

        private void Retring()
        {
            GlobalEvent.StartGame();
        }
    }
}
