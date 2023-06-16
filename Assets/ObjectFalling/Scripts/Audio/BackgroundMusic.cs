using DiaGna.AudioPlayer.Core;
using DiaGna.ObjectFalling.Gameplay;
using System.Collections;
using UnityEngine;

namespace DiaGna.ObjectFalling
{
    public class BackgroundMusic : BaseAudioPlayer
    {
        [SerializeField] private float m_InGameVolume;
        [SerializeField] private float m_InHomeVolume;

        protected override void OnLoadPlayer()
        {
            InternalSource.volume = m_InHomeVolume;
        }

        protected override void OnEnablePlayer()
        {
            GlobalEvent.OnStartGame += DecreseSound;
            GlobalEvent.OnHome += IncreaseSound;
        }

        protected override void OnDisablePlayer()
        {
            GlobalEvent.OnStartGame -= DecreseSound;
            GlobalEvent.OnHome -= IncreaseSound;
        }

        private void DecreseSound()
        {
            StartCoroutine(ChangeSound(m_InGameVolume));
        }

        private void IncreaseSound()
        {
            StartCoroutine(ChangeSound(m_InHomeVolume));
        }

        IEnumerator ChangeSound(float volume)
        {
            while (InternalSource.volume != volume)
            {
                InternalSource.volume = Mathf.Lerp(InternalSource.volume, volume, 1f * Time.deltaTime);
                yield return 0f;
            }
        }
    }
}
