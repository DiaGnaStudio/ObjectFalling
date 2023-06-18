using DiaGna.ObjectFalling.BrickUtility;
using DiaGna.ObjectFalling.Gameplay;
using DiaGna.ObjectFalling.LevelUtility;
using DiaGna.UserInterface;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Codice.CM.Common.CmCallContext;

namespace DiaGna.ObjectFalling.UserInterface.Tools
{
    public class BrickCounterDisplayer : UIElement
    {
        [SerializeField] private TMP_Text m_CountText;
        [SerializeField] private string m_format = "{0}/{1}";
        private float m_Max;

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
            BrickCountAnnouncer.OnCollidedBrick += UpdateText;

            if (LevelLoader.Instance.IsLevelActive)
            {
                SetBrickCount(LevelLoader.Instance.ActiveLevel);
            }
        }

        public override void OnDisableElement()
        {
            LevelLoader.Instance.OnLoadLevel += SetBrickCount;
            BrickCountAnnouncer.OnCollidedBrick -= UpdateText;
        }

        private void SetBrickCount(LevelData data)
        {
            m_Max = data.BrickCount;
            UpdateText(0);
        }

        private void UpdateText(IBrick brick, List<IBrick> list)
        {
            UpdateText(list.Count);
        }

        private void UpdateText(int current)
        {
            m_CountText.SetText(string.Format(m_format, current, m_Max));
        }
    }
}
