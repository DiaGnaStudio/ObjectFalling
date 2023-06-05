using System;
using UnityEngine;

namespace DiaGna.Framework.GenericEventSystem
{
    /// <summary>
    /// Base class for <see cref="MonoBehaviour"/> classes to implement <see cref="IMultipleEvent"/> for adding <see cref="CustomEvent"/>s and 
    /// <see cref="IMultipleEventHandler"/> for adding <see cref="CustomAction"/>s to the generic event system. Derive from this class to easily
    /// work with events and actions.
    /// </summary>
    public abstract class EventableBehaviour : MonoBehaviour, IMultipleEvent, IMultipleEventHandler
    {
        private Action<IMultipleEventHandler> m_OnDestroy;

        protected virtual void OnDestroy()
        {
            m_OnDestroy?.Invoke(this);
        }

        public virtual void AddEvents(EventList list)
        {
        }

        public virtual void AddActions(ActionList list)
        {
        }

        void IMultipleEventHandler.AddOnDestroy(Action<IMultipleEventHandler> action)
        {
            m_OnDestroy += action;
        }

        void IMultipleEventHandler.RemoveOnDestroy(Action<IMultipleEventHandler> action)
        {
            m_OnDestroy -= action;
        }
    }
}
