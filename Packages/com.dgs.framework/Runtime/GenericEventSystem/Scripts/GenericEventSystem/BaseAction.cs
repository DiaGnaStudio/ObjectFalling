using System;

namespace DiaGna.Framework.GenericEventSystem
{
    public abstract class BaseAction
    {
        public abstract object RawAction { get; }
        public abstract Type[] ArgTypes { get; }
        public abstract string ActionName { get; }

        /// <summary>
        /// It is called by the generic event system.
        /// </summary>
        public abstract void AddToEvent(BaseEvent baseEvent);
        /// <summary>
        /// It is called by the generic event system.
        /// </summary>
        public abstract void RemoveFromEvent(BaseEvent baseEvent);
    }
}
