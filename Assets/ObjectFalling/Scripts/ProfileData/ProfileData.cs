using System;

namespace DiaGna.ObjectFalling.ProfileUtility
{
    [Serializable]
    public class ProfileData
    {
        public string Id { get; private set; }
        public int CurrentLevelIndex { get; private set; }
        public int GoldAmount { get; private set; }

        public ProfileData(string id, int currentLevelIndex, int goldAmount)
        {
            Id = id;
            CurrentLevelIndex = currentLevelIndex;
            GoldAmount = goldAmount;
        }

        public void WinGame()
        {
            CurrentLevelIndex++;
        }
    }


    public class ProfileKeys
    {
        public const string Profile = "PROFILE";
    }

}
