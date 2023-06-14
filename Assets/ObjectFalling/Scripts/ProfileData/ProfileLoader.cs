using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiaGna.ObjectFalling.ProfileUtility
{
    public abstract class ProfileLoader : MonoBehaviour
    {
        public abstract ProfileData Profile { get; protected set; }
    }
}
