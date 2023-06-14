using UnityEngine;
using DiaGna.UserInterface;
using UnityEngine.UI;
using DiaGna.ObjectFalling.Gameplay;
using DiaGna.ObjectFalling.LevelUtility;
using System;

namespace DiaGna.ObjectFalling.UserInterface
{
    public class GamePage : UIPageBase
    {
        [SerializeField] private Slider m_HeightSlider;

        protected override void OnLoadPage()
        {
            
        }

        protected override void OnOpenPage()
        {
            GlobalEvent.StartGame();

            HeightController.Instance.OnChangeHeight += ChangeHeight;
            LevelLoader.Instance.OnLoadLevel += SetMaxHieght;
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
    }
}