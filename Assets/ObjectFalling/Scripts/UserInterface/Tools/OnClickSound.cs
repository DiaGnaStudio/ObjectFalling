using DiaGna.AudioPlayer.Core;
using UnityEngine;
using UnityEngine.UI;

namespace DiaGna.ObjectFalling
{
    public class OnClickSound : BaseAudioPlayer
    {
        private Button[] m_Button;

        protected override void OnLoadPlayer()
        {
            m_Button = GetComponentsInChildren<Button>();

            InternalSource.playOnAwake = false;
        }

        protected override void OnEnablePlayer()
        {
            foreach (var button in m_Button)
            {
                button.onClick.AddListener(InternalPlay);
            }
        }

        protected override void OnDisablePlayer()
        {
            foreach (var button in m_Button)
            {
                button.onClick.AddListener(InternalPlay);
            }
        }
    }
}
