using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DiaGna.ObjectFalling
{
    [Serializable]
    public class ProfileData
    {
        [SerializeField] private string m_id;
        [SerializeField] private string m_currentLevel;
        [SerializeField,Min(0)] private int m_goldAmount;

        public string CurrentLevel => m_currentLevel;
    }
}
