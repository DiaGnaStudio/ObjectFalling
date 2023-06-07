using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiaGna.ObjectFalling
{
    public class LevelLoader : MonoBehaviour
    {
        public static LevelLoader Instance { get; private set; }

        [SerializeField] private List<LevelDataAsset> levels = new List<LevelDataAsset>();

        public event Action OnLoadLevel;

        private void Awake()
        {
            if (!Instance)
                Instance = this;
            else
                Destroy(gameObject);
        }

        public void LoadProfile(ProfileData profileData)
        {
            foreach (LevelDataAsset level in levels)
            {
                bool isCurrentLevel = level.data.LevelIndex == profileData.CurrentLevel;
                if (isCurrentLevel)
                {
                    LoadLevel(level.data);
                    break;
                }
            }
        }

        private void LoadLevel(LevelData levelData)
        {
            OnLoadLevel?.Invoke();
        }
    }
}
