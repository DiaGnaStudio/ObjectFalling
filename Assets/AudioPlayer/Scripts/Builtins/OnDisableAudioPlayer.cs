using DiaGna.AudioPlayer.Core;

namespace DiaGna.AudioPlayer.Builtins
{
    public class OnDisableAudioPlayer : BaseAudioPlayer
    {
        protected override void OnLoadPlayer()
        {
            InternalSource.playOnAwake = false;
        }

        protected override void OnDisablePlayer()
        {
            InternalPlay();
        }
    }
}
