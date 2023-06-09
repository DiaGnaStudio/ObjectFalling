using System;
using System.Collections.Generic;

namespace DiaGna.Framework.GenericEventSystem
{
    public struct ActionList
    {
        private List<BaseAction> m_List;

        public ActionList(List<BaseAction> list)
        {
            m_List = list;
        }

        public void Add(BaseAction baseAction)
        {
            m_List.Add(baseAction);
        }

        public void Add(Action action)
        {
            m_List.Add(new CustomAction(action));
        }

        public void Add<T>(Action<T> action)
        {
            m_List.Add(new CustomAction<T>(action));
        }

        public void Add<T1, T2>(Action<T1, T2> action)
        {
            m_List.Add(new CustomAction<T1, T2>(action));
        }

        public void Add<T1, T2, T3>(Action<T1, T2, T3> action)
        {
            m_List.Add(new CustomAction<T1, T2, T3>(action));
        }

        public void Add<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action)
        {
            m_List.Add(new CustomAction<T1, T2, T3, T4>(action));
        }

        public void Add<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action)
        {
            m_List.Add(new CustomAction<T1, T2, T3, T4, T5>(action));
        }

        public void Add<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> action)
        {
            m_List.Add(new CustomAction<T1, T2, T3, T4, T5, T6>(action));
        }
    }
}
