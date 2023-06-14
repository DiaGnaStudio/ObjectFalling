using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DiaGna.ObjectFalling.UserInterface.Tools
{
    /// <summary>
    /// An UserInterface tools to provides movement event by <see cref="EventTrigger"/>.
    /// </summary>
    [RequireComponent(typeof(EventTrigger))]
    public class MoverEvent : MonoBehaviour
    {
        private EventTrigger m_Trigger;

        private EventTrigger.Entry m_DragEntry;
        private EventTrigger.Entry m_PointerUpEntry;

        public static event Action<Vector2> OnDrag;
        public static event Action OnPointerUp;

        private void Awake()
        {
            m_Trigger = GetComponent<EventTrigger>();
            m_DragEntry = CreateDragEntry();
        }

        private void OnEnable()
        {
            m_DragEntry ??= CreateDragEntry();
            m_Trigger.triggers.Add(m_DragEntry);

            m_PointerUpEntry ??= CreatePointerUpEntry();
            m_Trigger.triggers.Add(m_PointerUpEntry);
        }

        private void OnDisable()
        {
            RemoveEnty(m_DragEntry);
            RemoveEnty(m_PointerUpEntry);
        }

        private void RemoveEnty(EventTrigger.Entry enty)
        {
            if (m_Trigger.triggers.Contains(enty))
            {
                m_Trigger.triggers.Remove(enty);
            }
        }

        private EventTrigger.Entry CreateDragEntry()
        {
            EventTrigger.Entry dragEntry = new EventTrigger.Entry();
            dragEntry.eventID = EventTriggerType.Drag;
            dragEntry.callback.AddListener((data) => { OnDragDelegate((PointerEventData)data); });
            return dragEntry;
        }

        private EventTrigger.Entry CreatePointerUpEntry()
        {
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerUp;
            entry.callback.AddListener((data) => { OnPointerUpDelegate((PointerEventData)data); });
            return entry;
        }

        public void OnDragDelegate(PointerEventData data)
        {
            OnDrag?.Invoke(data.delta);
        }

        private void OnPointerUpDelegate(PointerEventData data)
        {
            OnPointerUp?.Invoke();
        }
    }
}
