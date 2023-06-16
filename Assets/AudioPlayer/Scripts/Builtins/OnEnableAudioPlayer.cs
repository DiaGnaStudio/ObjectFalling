using DiaGna.AudioPlayer.Core;

namespace DiaGna.AudioPlayer.Builtins
{
    public class OnEnableAudioPlayer : BaseAudioPlayer
    {
        protected override void OnLoadPlayer()
        {
            InternalSource.playOnAwake = false;
        }

        protected override void OnEnablePlayer()
        {
            InternalPlay();
        }
    }
}
