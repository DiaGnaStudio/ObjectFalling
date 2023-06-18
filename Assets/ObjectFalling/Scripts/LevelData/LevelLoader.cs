using DiaGna.Framework.Singletons;
using DiaGna.ObjectFalling.Gameplay;
using DiaGna.ObjectFalling.ProfileUtility;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DiaGna.ObjectFalling.LevelUtility
{
    public class LevelLoader : ComponentSingleton<LevelLoader>
    {
        [SerializeField] private List<LevelDataAsset> levels = new List<LevelDataAsset>();

        public event Action<LevelData> OnLoadLevel;

        public bool IsLevelActive { get; private set; }
        public LevelData ActiveLevel { get; private set; }

        private void OnEnable()
        {
            GlobalEvent.OnStartGame += LoadLevel;
            GlobalEvent.OnFinishGame += FinishActiveLevel;
        }

        private void OnDisable()
        {
            GlobalEvent.OnStartGame -= LoadLevel;
            GlobalEvent.OnFinishGame -= FinishActiveLevel;
        }

        private void LoadLevel()
        {
            if (IsLevelActive) return;
            IsLevelActive = true;

            var newLevel = GetLevel(ProfileController.Instance.Profile.CurrentLevelIndex);
            ActiveLevel = newLevel;
            OnLoadLevel?.Invoke(newLevel);

            BrickCountAnnouncer.StartCounting(newLevel);
        }

        private void FinishActiveLevel(bool isWin)
        {
            IsLevelActive = false;
            ActiveLevel = null;
        }

        private LevelData GetLevel(int levelIndex)
        {
            for (int i = 0; i < levels.Count; i++)
            {
                LevelDataAsset level = levels[i];
                bool isCurrentLevel = i == (levelIndex % levels.Count);
                if (isCurrentLevel)
                {
                    return level.data;
                }
            }
            return null;
        }

    }
}
