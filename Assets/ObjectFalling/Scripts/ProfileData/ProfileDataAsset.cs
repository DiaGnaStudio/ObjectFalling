using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiaGna.ObjectFalling
{
    [CreateAssetMenu(fileName = "New Profile Data", menuName = "Profile Data")]
    public class ProfileDataAsset : ScriptableObject
    {
        public ProfileData data;
    }
}
