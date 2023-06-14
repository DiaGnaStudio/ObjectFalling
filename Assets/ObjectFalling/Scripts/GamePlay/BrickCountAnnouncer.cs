using DiaGna.ObjectFalling.BrickUtility;
using DiaGna.ObjectFalling.GroundUtility;
using DiaGna.ObjectFalling.LevelUtility;
using System;
using UnityEngine;

namespace DiaGna.ObjectFalling.Gameplay
{
    public class BrickCountAnnouncer : MonoBehaviour
    {
        public int Count { get; private set; }
        public int ThrowedCount { get; private set; } = 0;

        /// <summary>
        /// Parameters: brick throwed count, total count
        /// </summary>
        public static event Action<int, int> OnIncrease;

        private void OnEnable()
        {
            LevelLoader.Instance.OnLoadLevel += SetBrickCount;
            Ground.Instance.OnRotated += AddBrick;
            GlobalEvent.OnStartGame += StartCounting;

            if (LevelLoader.Instance.IsLevelActive)
            {
                SetBrickCount(LevelLoader.Instance.ActiveLevel);
            }
        }

        private void OnDisable()
        {
            if (LevelLoader.IsAlive)
            {
                LevelLoader.Instance.OnLoadLevel -= SetBrickCount;
            }

            if (Ground.IsAlive)
            {
                Ground.Instance.OnRotated -= AddBrick;
            }

            GlobalEvent.OnStartGame -= StartCounting;
        }

        private void StartCounting()
        {
            ThrowedCount = 0;
        }

        private void SetBrickCount(LevelData data)
        {
            Count = data.BrickCount;
        }

        private void AddBrick(Brick brick)
        {
            ThrowedCount++;

            if (ThrowedCount >= Count)
            {
                var isWin = HeightController.Instance.IsWin;
                GlobalEvent.FinishGame(isWin);
            }

            OnIncrease?.Invoke(ThrowedCount, Count);
        }
    }
}
