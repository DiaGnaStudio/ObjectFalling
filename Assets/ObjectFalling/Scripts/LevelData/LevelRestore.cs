using DiaGna.Framework.Singletons;
using DiaGna.ObjectFalling.Gameplay;
using System;

namespace DiaGna.ObjectFalling.LevelUtility
{
    public class LevelRestore : ComponentSingleton<LevelRestore>
    {
        public event Action OnRestoring;

        private void OnEnable()
        {
            GlobalEvent.OnFinishGame += FinishActiveLevel;
        }

        private void OnDisable()
        {
            GlobalEvent.OnFinishGame -= FinishActiveLevel;
        }

        private void FinishActiveLevel(bool isWin)
        {
            OnRestoring?.Invoke();
        }
    }
}
