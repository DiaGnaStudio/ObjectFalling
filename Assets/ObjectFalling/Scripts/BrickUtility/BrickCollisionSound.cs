using DiaGna.AudioPlayer.Core;
using UnityEngine;

namespace DiaGna.ObjectFalling.BrickUtility
{
    [RequireComponent(typeof(Brick))]
    public class BrickCollisionSound : BaseAudioPlayer
    {
        private Brick m_Brick;

        protected override void OnLoadPlayer()
        {
            m_Brick = GetComponent<Brick>();
        }

        protected override void OnEnablePlayer()
        {
            m_Brick.OnCollision += Play;
        }

        protected override void OnDisablePlayer()
        {
            m_Brick.OnCollision -= Play;
        }

        private void Play(Brick brick, Collision collision)
        {
            InternalPlay();
        }
    }
}
