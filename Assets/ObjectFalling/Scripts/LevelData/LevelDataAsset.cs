using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiaGna.ObjectFalling
{
    [CreateAssetMenu(fileName = "New Level Data", menuName = "Level Data")]
    public class LevelDataAsset : ScriptableObject
    {
        public LevelData data;
    }
}
