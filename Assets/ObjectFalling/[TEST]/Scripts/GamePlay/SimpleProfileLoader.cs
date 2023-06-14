using DiaGna.ObjectFalling.LevelUtility;
using Newtonsoft.Json;
using UnityEngine;

namespace DiaGna.ObjectFalling.ProfileUtility.Test
{
    public class SimpleProfileLoader : ProfileLoader
    {
        public override ProfileData Profile { get; protected set; }

        private void Start()
        {
            if (PlayerPrefs.HasKey(ProfileKeys.Profile))
            {
                Profile = JsonConvert.DeserializeObject<ProfileData>(PlayerPrefs.GetString(ProfileKeys.Profile));
            }
            else
            {
                Profile = new ProfileData("User", 0, 0);
                PlayerPrefs.SetString(ProfileKeys.Profile, JsonConvert.SerializeObject(Profile));
            }

            LevelLoader.Instance.LoadProfile(Profile);
        }
    }
}
