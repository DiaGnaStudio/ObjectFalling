using DiaGna.ObjectFalling.BrickUtility;
using DiaGna.ObjectFalling.GroundUtility;
using DiaGna.ObjectFalling.LevelUtility;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DiaGna.ObjectFalling.Gameplay
{
    public class BrickCountAnnouncer : MonoBehaviour
    {
        public int Count { get; private set; }
        public int ThrowedCount => AvailableBricks.Count;

        /// <summary>
        /// Parameters: brick throwed count, total count
        /// </summary>
        public static event Action<int, int> OnIncrease;

        private List<Brick> AvailableBricks;

        private void Awake()
        {
            AvailableBricks = new List<Brick>();
        }

        private void OnEnable()
        {
            LevelLoader.Instance.OnLoadLevel += SetBrickCount;
            Ground.Instance.OnRotated += AddBrick;
            GlobalEvent.OnStartGame += StartCounting;
            GlobalEvent.OnFinishGame += DestoyBricks;

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
            GlobalEvent.OnFinishGame -= DestoyBricks;
        }

        private void StartCounting()
        {
            AvailableBricks.Clear();
        }

        private void SetBrickCount(LevelData data)
        {
            Count = data.BrickCount;
        }

        private void AddBrick(Brick brick)
        {
            AvailableBricks.Add(brick);

            if (ThrowedCount >= Count)
            {
                var isWin = HeightController.Instance.IsWin;
                GlobalEvent.FinishGame(isWin);
            }

            OnIncrease?.Invoke(ThrowedCount, Count);
        }

        private void DestoyBricks(bool obj)
        {
            foreach (var brick in AvailableBricks)
            {
                Destroy(brick.gameObject);
            }
        }
    }
}
