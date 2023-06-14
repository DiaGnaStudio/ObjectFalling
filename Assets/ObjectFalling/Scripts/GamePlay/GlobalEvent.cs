using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiaGna.ObjectFalling.Gameplay
{
    public static class GlobalEvent
    {
        public static event Action OnStartGame;
        public static event Action<bool> OnFinishGame;

        public static void StartGame()
        {
            OnStartGame?.Invoke();
        }

        public static void FinishGame(bool isWin)
        {
            OnFinishGame?.Invoke(isWin);
        }
    }
}
