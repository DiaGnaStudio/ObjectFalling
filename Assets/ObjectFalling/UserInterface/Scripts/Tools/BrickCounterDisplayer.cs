using DiaGna.ObjectFalling.Gameplay;
using DiaGna.ObjectFalling.LevelUtility;
using DiaGna.UserInterface;
using TMPro;
using UnityEngine;

namespace DiaGna.ObjectFalling.UserInterface.Tools
{
    public class BrickCounterDisplayer : UIElement
    {
        [SerializeField] private TMP_Text m_CountText;
        [SerializeField] private string m_format = "{0}/{1}";

        public override void OnLoadElement()
        {
            if (LevelLoader.Instance.IsLevelActive)
            {
                SetBrickCount(LevelLoader.Instance.ActiveLevel);
            }
        }
        public override void OnEnableElement()
        {
            LevelLoader.Instance.OnLoadLevel += SetBrickCount;
            BrickCountAnnouncer.OnIncrease += UpdateText;

            if (LevelLoader.Instance.IsLevelActive)
            {
                SetBrickCount(LevelLoader.Instance.ActiveLevel);
            }
        }

        public override void OnDisableElement()
        {
            LevelLoader.Instance.OnLoadLevel += SetBrickCount;
            BrickCountAnnouncer.OnIncrease -= UpdateText;
        }

        private void SetBrickCount(LevelData data)
        {
            UpdateText(0, data.BrickCount);
        }

        private void UpdateText(int current, int total)
        {
            m_CountText.SetText(string.Format(m_format, current, total));
        }
    }
}
