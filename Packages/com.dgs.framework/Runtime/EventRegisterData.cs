using UnityEngine;
using DiaGna.Framework.Attributes;

namespace DiaGna.Framework.GenericEventSystem
{
    [System.Serializable]
    public struct EventRegisterData
    {
#if UNITY_EDITOR
        public const int EventId = 0;
        public const int EventIndexId = 1;
        public const int EventPopupIndexId = 2;
#endif

#if UNITY_EDITOR
        [EditorModifiable(FieldID = EventId)]
#endif
        [TypeRestrictor(typeof(IMultipleEvent))]
        public Object m_Event;

#if UNITY_EDITOR
        [EditorModifiable(FieldID = EventIndexId)]
#endif
        public int m_EventIndex;

#if UNITY_EDITOR
        [EditorModifiable(FieldID = EventPopupIndexId)]
#endif
        [SerializeField]
        private int m_EventPopupIndex;
    }
}
