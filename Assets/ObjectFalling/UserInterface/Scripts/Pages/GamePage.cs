using UnityEngine;
using DiaGna.UserInterface;
using UnityEngine.UI;
using DiaGna.ObjectFalling.Gameplay;

namespace DiaGna.ObjectFalling.UserInterface
{
    public class GamePage : UIPageBase
    {
        [SerializeField] private Slider m_HeightSlider;

        protected override void OnLoadPage()
        {
            m_HeightSlider.minValue = 0;
            m_HeightSlider.maxValue = HeightController.Instance.WinHight;
            m_HeightSlider.value = 0;
        }

        protected override void OnOpenPage()
        {
            GlobalEvent.StartGame();

            HeightController.Instance.OnChangeHeight += ChangeHeight;
        }

        protected override void OnClosePage()
        {
            HeightController.Instance.OnChangeHeight -= ChangeHeight;
        }

        private void ChangeHeight(float currentHeight)
        {
            m_HeightSlider.value = currentHeight;
        }
    }
}