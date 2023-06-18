using System;
using UnityEngine;

namespace DiaGna.ObjectFalling.Gameplay
{
    public static class GlobalEvent
    {
        public static event Action OnStartGame;
        public static event Action<bool> OnFinishGame;

        public static event Action OnHome;

        public static bool IsWin { get; private set; }

        public static void StartGame()
        {
            IsWin = false;
            OnStartGame?.Invoke();
        }

        public static void FinishGame(bool isWin)
        {
            IsWin = isWin;
            OnFinishGame?.Invoke(isWin);
        }

        public static void HomeOpened()
        {
            OnHome?.Invoke();
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Reset()
        {
            IsWin = false;
        }
    }
}
