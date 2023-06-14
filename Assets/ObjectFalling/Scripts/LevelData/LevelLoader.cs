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
            GlobalEvent.OnFinishGame += FinishActiveLevel;
        }

        private void OnDisable()
        {
            GlobalEvent.OnFinishGame -= FinishActiveLevel;
        }

        private void FinishActiveLevel(bool isWin)
        {
            IsLevelActive = false;
        }

        public void LoadProfile(ProfileData profileData)
        {
            for (int i = 0; i < levels.Count; i++)
            {
                LevelDataAsset level = levels[i];
                bool isCurrentLevel = i == (profileData.CurrentLevelIndex % levels.Count);
                if (isCurrentLevel)
                {
                    LoadLevel(level.data);
                    break;
                }
            }
        }

        private void LoadLevel(LevelData levelData)
        {
            if (IsLevelActive) return;
            IsLevelActive = true;

            ActiveLevel = levelData;
            OnLoadLevel?.Invoke(levelData);
        }
    }
}
