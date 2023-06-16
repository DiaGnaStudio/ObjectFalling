using DiaGna.ObjectFalling.BrickUtility;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DiaGna.ObjectFalling
{
    [Serializable]
    public class LevelData
    {
        [SerializeField] private string m_id;
        [SerializeField, Min(0)] private int m_levelIndex;
        [SerializeField, Min(0)] private float m_winHeight;
        [SerializeField, Min(0)] private int m_brickCount;
        [SerializeField] private List<GameObject> m_brickPrefabs;

        public int LevelIndex => m_levelIndex;

        public float WinHeight => m_winHeight;
        public int BrickCount => m_brickCount;

        public bool Equals(int level)
        {
            if (level == m_levelIndex)
                return true;

            return false;
        }

        public IBrick GetRandomBricks()
        {
            var randomIndex = Random.Range(0, m_brickPrefabs.Count);
            IBrick brick = m_brickPrefabs[randomIndex].GetComponent<IBrick>();

            return brick;
        }
    }
}
