using UnityEngine;
using DiaGna.Framework.Attributes;

namespace DiaGna.Framework.GenericEventSystem
{
    [System.Serializable]
    public struct RegisterData
    {
        [EditorModifiable(FieldID = ActionId)]
        [TypeRestrictor(typeof(IMultipleEventHandler))]
        public Object m_Action;
        [EditorModifiable(FieldID = ActionIndexId)]
        public int m_ActionIndex;
        [EditorModifiable(FieldID = EventId)]
        [TypeRestrictor(typeof(IMultipleEvent))]
        public Object m_Event;
        [EditorModifiable(FieldID = EventIndexId)]
        public int m_EventIndex;

        public const int ActionId = 0;
        public const int EventId = 1;
        public const int ActionIndexId = 2;
        public const int EventIndexId = 3;

#if UNITY_EDITOR
        [EditorModifiable(FieldID = ActionPopupIndexId)]
        [SerializeField]
        private int m_ActionPopupIndex;
        [EditorModifiable(FieldID = EventPopupIndexId)]
        [SerializeField]
        private int m_EventPopupIndex;

        public const int ActionPopupIndexId = 4;
        public const int EventPopupIndexId = 5;
#endif
    }
}