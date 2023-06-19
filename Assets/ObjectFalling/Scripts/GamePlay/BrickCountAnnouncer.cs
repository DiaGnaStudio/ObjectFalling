using DiaGna.ObjectFalling.BrickUtility;
using System;
using System.Collections.Generic;

namespace DiaGna.ObjectFalling.Gameplay
{
    public static class BrickCountAnnouncer
    {
        public static int TotalCount { get; private set; }
        public static int CreatedCount => DroppedBricks.Count;

        /// <summary>
        /// Parameters: brick throwed count, total count
        /// </summary>
        public static event Action<int, int> OnIncrease;
        public static event Action<IBrick, List<IBrick>> OnCollidedBrick;
        public static event Action<IBrick, List<IBrick>> OnCreatedBrick;

        private static List<IBrick> CountedBricks = new List<IBrick>();
        private static List<IBrick> DroppedBricks = new List<IBrick>();

        public static void StartCounting(LevelData data)
        {
            CountedBricks.Clear();
            DroppedBricks.Clear();
            TotalCount = data.BrickCount;
        }

        public static void AddCollidedBrick(IBrick brick)
        {
            if (CountedBricks.Contains(brick)) return;
            CountedBricks.Add(brick);

            OnIncrease?.Invoke(CreatedCount, TotalCount);
            OnCollidedBrick?.Invoke(brick, DroppedBricks);
        }

        public static void AddBrick(IBrick brick)
        {
            if (DroppedBricks.Contains(brick)) return;
            DroppedBricks.Add(brick);
            OnCreatedBrick?.Invoke(brick, DroppedBricks);
        }

        public static bool CanCreate()
        {
            return CreatedCount < TotalCount;
        }
    }
}
