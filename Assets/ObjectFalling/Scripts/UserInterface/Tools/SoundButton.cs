using UnityEngine;
using UnityEngine.UI;
using DiaGna.AudioPlayer.Core;

namespace DiaGna.ObjectFalling.UserInterface
{
    [RequireComponent(typeof(Toggle))]
    public class SoundButton : MonoBehaviour
    {
        private Toggle m_Toggle;
        [SerializeField] private Image m_SoundIcon;
        [SerializeField] private Sprite m_OnSprite;
        [SerializeField] private Sprite m_OffSprite;

        private void Awake()
        {
            m_Toggle = GetComponent<Toggle>();

            m_Toggle.isOn = true;
        }

        private void OnEnable()
        {
            m_Toggle.onValueChanged.AddListener(ChangeSprite);
            m_Toggle.onValueChanged.AddListener(ChangeSetting);
        }

        private void OnDisable()
        {
            m_Toggle.onValueChanged.RemoveListener(ChangeSprite);
            m_Toggle.onValueChanged.RemoveListener(ChangeSetting);
        }

        private void ChangeSprite(bool value)
        {
            m_SoundIcon.sprite = value ? m_OnSprite : m_OffSprite;
        }

        private void ChangeSetting(bool value)
        {
            AudioController.SetMute(AudioPlayer.Core.AudioType.Music, !value);
            AudioController.SetMute(AudioPlayer.Core.AudioType.SFX, !value);
        }
    }
}
