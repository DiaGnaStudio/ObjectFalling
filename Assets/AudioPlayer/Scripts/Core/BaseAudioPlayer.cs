using UnityEngine;

namespace DiaGna.AudioPlayer.Core
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class BaseAudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioType m_AudioType;
        private AudioSource m_Source;

        public AudioSource InternalSource => m_Source;

        private void Awake()
        {
            m_Source = GetComponent<AudioSource>();

            OnLoadPlayer();
        }

        private void OnEnable()
        {
            AudioController.AddSource(m_Source, m_AudioType);

            OnEnablePlayer();
        }

        private void OnDisable()
        {
            AudioController.RemoveSource(m_Source, m_AudioType);

            OnDisablePlayer();
        }

        protected void InternalPlay()
        {
            m_Source.Play();
        }

        protected virtual void OnLoadPlayer() { }
        protected virtual void OnEnablePlayer() { }
        protected virtual void OnDisablePlayer() { }
    }
}
