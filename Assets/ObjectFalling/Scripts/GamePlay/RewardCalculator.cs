using DiaGna.ObjectFalling.BrickUtility;

namespace DiaGna.ObjectFalling.Gameplay
{
    public static class RewardCalculator
    {
        public struct Reward
        {
            public Reward(int reminingBrickCount, int maxBrickCount)
            {
                ReminingBrickCount = reminingBrickCount;

                GoldReward = (int)(reminingBrickCount * 1.5f);
                MaxBrickCount = maxBrickCount;
            }

            public int ReminingBrickCount { get; private set; }
            public int MaxBrickCount { get; private set; }
            public int GoldReward { get; private set; }
        }

        public static Reward GetReward()
        {
            var bricks = UnityEngine.Object.FindObjectsOfType<Brick>(true);
            int maxCount = bricks.Length;
            int reminingBrickCount = 0;
            foreach (var brick in bricks)
            {
                if (brick.gameObject.activeSelf)
                {
                    reminingBrickCount++;
                }
            }

            return new Reward(reminingBrickCount, maxCount);
        }
    }
}
