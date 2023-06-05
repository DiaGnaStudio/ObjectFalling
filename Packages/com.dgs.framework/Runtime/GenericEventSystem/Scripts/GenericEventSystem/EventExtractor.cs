using System.Collections.Generic;

namespace DiaGna.Framework.GenericEventSystem
{
    public static class EventExtractor
    {
        private static List<BaseEvent> m_AvailableEvents;


        public static BaseEvent GetEvent(EventRegisterData eventData)
        {
            InitizeEventList();
            if (eventData.m_Event != null)
            {
                IMultipleEvent baseEvent = (IMultipleEvent)eventData.m_Event;
                return GetEvent(baseEvent, eventData.m_EventIndex);
            }

            return null;
        }

        public static BaseEvent GetEvent(IMultipleEvent eventContainer, int eventIndex)
        {
            InitizeEventList();

            if (eventContainer != null && eventIndex > -1)
            {
                AddEvents(eventContainer);

                if (eventIndex < m_AvailableEvents.Count)
                {
                    BaseEvent baseEvent = m_AvailableEvents[eventIndex];
                    m_AvailableEvents.Clear();
                    return baseEvent;
                }
            }

            m_AvailableEvents.Clear();
            return null;
        }

        private static void InitizeEventList()
        {
            if (m_AvailableEvents == null)
            {
                m_AvailableEvents = new List<BaseEvent>();
            }
        }

        private static void AddEvents(IMultipleEvent eventContainer)
        {
            m_AvailableEvents.Clear();
            EventList events = new EventList(m_AvailableEvents);
            eventContainer.AddEvents(events);
        }
    }
}
