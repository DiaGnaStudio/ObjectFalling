using DiaGna.ObjectFalling.Gameplay;
using DiaGna.ObjectFalling.LevelUtility;
using DiaGna.UserInterface;
using DiaGna.UserInterface.Controller;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DiaGna.ObjectFalling.UserInterface
{
    public class GamePage : UIPageBase
    {
        [SerializeField] private Slider m_HeightSlider;

        [Header("Other Pages")]
        [SerializeField] private UIPageBase m_WinPage;
        [SerializeField] private UIPageBase m_LosePage;

        protected override void OnLoadPage()
        {

        }

        protected override void OnOpenPage()
        {
            HeightController.Instance.OnChangeHeight += ChangeHeight;
            LevelLoader.Instance.OnLoadLevel += SetMaxHieght;

            GlobalEvent.OnFinishGame += OpenPage;
        }

        protected override void OnClosePage()
        {
            if (HeightController.IsAlive)
            {
                HeightController.Instance.OnChangeHeight -= ChangeHeight;
            }

            if (LevelLoader.IsAlive)
            {
                LevelLoader.Instance.OnLoadLevel += SetMaxHieght;
            }

            GlobalEvent.OnFinishGame -= OpenPage;
        }

        private void SetMaxHieght(LevelData data)
        {
            m_HeightSlider.minValue = 0;
            m_HeightSlider.maxValue = data.WinHeight;
            m_HeightSlider.value = 0;
        }

        private void ChangeHeight(float currentHeight)
        {
            m_HeightSlider.value = currentHeight;
        }

        private void OpenPage(bool isWin)
        {
            if (isWin)
            {
                UserInterfaceUtility.OpenPage(m_WinPage);
            }
            else
            {
                UserInterfaceUtility.OpenPage(m_LosePage);
            }
        }
    }
}