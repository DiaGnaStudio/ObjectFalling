using DiaGna.Framework.Singletons;
using DiaGna.ObjectFalling.Gameplay;
using UnityEngine;

namespace DiaGna.ObjectFalling.ProfileUtility
{
    public class ProfileController : ComponentSingleton<ProfileController>
    {
        [SerializeField] private ProfileLoader m_Loader;

        public ProfileData Profile => m_Loader.Profile;

        private void Awake()
        {
            if(m_Loader == null)
            {
                Debug.LogError("No Loader Found!", gameObject);
            }
        }

        private void OnEnable()
        {
            GlobalEvent.OnFinishGame += UpdateProfile;
        }

        private void OnDisable()
        {
            GlobalEvent.OnFinishGame -= UpdateProfile;
        }

        private void UpdateProfile(bool isWin)
        {
            if (isWin)
            {
                m_Loader.Profile.WinGame();
            }
        }
    }
}
