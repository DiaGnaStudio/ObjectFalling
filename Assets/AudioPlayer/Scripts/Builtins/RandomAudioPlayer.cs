using DiaGna.AudioPlayer.Core;
using UnityEngine;

namespace DiaGna.AudioPlayer.Builtins
{
    public class RandomAudioPlayer : BaseAudioPlayer
    {
        [SerializeField, Range(0, 1)] private float m_Chance;

        public void RandomPlay()
        {
            if (Random.value > 1-m_Chance)
            {
                InternalPlay();
            }
        }
    }
}
