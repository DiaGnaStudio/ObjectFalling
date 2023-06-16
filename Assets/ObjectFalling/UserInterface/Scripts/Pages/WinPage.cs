using DiaGna.ObjectFalling.Gameplay;
using DiaGna.UserInterface;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DiaGna.ObjectFalling.UserInterface
{
    public class WinPage : UIPageBase
    {
        [SerializeField] private Button m_NextButton;
        [SerializeField] private Slider m_ScoreSlider;
        [SerializeField] private NumberCounter Wirter;

        protected override void OnLoadPage()
        {
        }

        protected override void OnOpenPage()
        {
            m_NextButton.onClick.AddListener(Retring);

            var reward = RewardCalculator.GetReward();
            m_ScoreSlider.maxValue = reward.MaxBrickCount;
            m_ScoreSlider.minValue = 0;
            m_ScoreSlider.value = reward.ReminingBrickCount;

            Wirter.Value = reward.GoldReward;
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
