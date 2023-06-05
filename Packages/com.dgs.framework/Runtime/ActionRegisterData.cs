using UnityEngine;
using DiaGna.Framework.Attributes;

namespace DiaGna.Framework.GenericEventSystem
{
    [System.Serializable]
    public struct ActionRegisterData
    {
#if UNITY_EDITOR
        public const int ActionId = 0;
        public const int ActionIndexId = 1;
        public const int ActionPopupIndexId = 2;
#endif

#if UNITY_EDITOR
        [EditorModifiable(FieldID = ActionId)]
#endif
        [TypeRestrictor(typeof(IMultipleEventHandler))]
        public Object m_Action;

#if UNITY_EDITOR
        [EditorModifiable(FieldID = ActionIndexId)]
#endif
        public int m_ActionIndex;

#if UNITY_EDITOR
        [EditorModifiable(FieldID = ActionPopupIndexId)]
#endif
        [SerializeField]
        private int m_ActionPopupIndex;
    }
}
