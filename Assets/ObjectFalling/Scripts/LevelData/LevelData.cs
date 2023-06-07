using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DiaGna.ObjectFalling.BrickUtility;
using Random = UnityEngine.Random;

namespace DiaGna.ObjectFalling
{
    [Serializable]
    public class LevelData 
    {
        [SerializeField] private string m_id;
        [SerializeField,Min(0)] private int m_levelIndex;
        [SerializeField] private float m_winHeight;
        [SerializeField,Min(0)] private int m_brickCount;
        [SerializeField] private List<Brick> m_brickPrefabs = new List<Brick>();

        public string LevelIndex => m_levelIndex.ToString();

        public bool Equals(int level)
        {
            if (level == m_levelIndex)
                return true;

            return false;
        }

        public Brick GetRandomBricks()
        {
            var randomIndex = Random.Range(0, m_brickPrefabs.Count);
            Brick brick = m_brickPrefabs[randomIndex];

            return brick;
        }
    }
}
