using UnityEngine;
using DiaGna.Framework.GenericEventSystem.ActionCalling;

namespace DiaGna.Framework.GenericEventSystem
{
    public class EnableEvent : MonoBehaviour
    {
        [SerializeField] private ActionRegisterData[] m_OnEnableActions;
        [SerializeField] private ActionRegisterData[] m_OnDisableActions;

        private void OnEnable()
        {
            RunActions(m_OnEnableActions);
        }

        private void OnDisable()
        {
            RunActions(m_OnDisableActions);
        }

        private void RunActions(ActionRegisterData[] actions)
        {
            for (int i = 0; i < actions.Length; i++)
            {
                if (actions[i].m_Action != null)
                {
                    ActionCallUtility.Call(actions[i], false);
                }
            }
        }
    }
}
