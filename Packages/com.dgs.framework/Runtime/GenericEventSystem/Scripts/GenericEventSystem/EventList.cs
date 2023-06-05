using System.Collections.Generic;

namespace DiaGna.Framework.GenericEventSystem
{
    public struct EventList
    {
        private List<BaseEvent> m_List;
        private List<string> m_Names;

        public EventList(List<BaseEvent> list, List<string> names = null)
        {
            m_List = list;
            m_Names = names;
        }

        public void Add(BaseEvent customEvent, string name = null)
        {
            m_List.Add(customEvent);

            if(m_Names != null)
            {
                m_Names.Add(name);
            }
        }
    }
}
