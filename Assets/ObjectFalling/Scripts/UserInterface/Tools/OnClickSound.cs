using UnityEngine;
using UnityEngine.UI;

namespace DiaGna.ObjectFalling
{
    [RequireComponent(typeof(AudioSource))]
    public class OnClickSound : MonoBehaviour
    {
        [SerializeField] private AudioClip m_Sound;
        private AudioSource m_Source;
        private Button[] m_Button;

        private void Awake()
        {
            m_Source = GetComponent<AudioSource>();
            m_Button = GetComponentsInChildren<Button>();

            m_Source.playOnAwake = false;
            m_Source.clip = m_Sound;
        }

        private void OnEnable()
        {
            foreach (var button in m_Button)
            {
                button.onClick.AddListener(Play);
            }
        }

        private void OnDisable()
        {
            foreach (var button in m_Button)
            {
                button.onClick.AddListener(Play);
            }
        }

        private void Play()
        {
            m_Source.Play();
        }
    }
}
