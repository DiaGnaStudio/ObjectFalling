using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiaGna.ObjectFalling
{
    public class ProfileLoader : MonoBehaviour
    {
        public static ProfileLoader Instance { get; private set; }

        public event Action<ProfileData> OnLoadProfile;

        private void Awake()
        {
            if (!Instance)
                Instance = this;
            else
                Destroy(gameObject);
        }


        // need Profile Data to this invoke action

        //private void OnEnable()
        //{
        //    LevelLoader.Instance.OnLoadLevel += loadProfile;
        //}
        //private void OnDisable()
        //{
        //    LevelLoader.Instance.OnLoadLevel -= loadProfile;
        //}

        //private void loadProfile(ProfileData profileData)
        //{
        //    OnLoadProfile?.Invoke(profileData);
        //}
    }
}
