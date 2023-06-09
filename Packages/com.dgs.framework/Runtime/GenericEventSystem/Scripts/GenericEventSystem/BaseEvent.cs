using System;

namespace DiaGna.Framework.GenericEventSystem
{
    public abstract class BaseEvent
    {
        protected const string RegisterNotSpportedMessage = "CustomEvent of type {0} does not support registering action: {1}";
        protected const string UnRegisterNotSpportedMessage = "CustomEvent of type {0} does not support unregistering action: {1}";

        public abstract Type[] ArgTypes { get; }

        public BaseEvent() { }

        /// <summary>
        /// It is called by the generic event system.
        /// </summary>
        public abstract void AddListener(BaseAction baseAction);
        /// <summary>
        /// It is called by the generic event system.
        /// </summary>
        public abstract void RemoveListener(BaseAction baseAction);
        public abstract void RemoveAllListeners();

        #region Add Custom Args Listeners
        /// <summary>
        /// Add the listener which has System.Action with zero args. It is called by generic event system.
        /// </summary>
        internal virtual void Add0ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedAddMessage(baseAction));
        }

        /// <summary>
        /// Add the listener which has System.Action with 1 args. It is called by generic event system.
        /// </summary>
        internal virtual void Add1ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedAddMessage(baseAction));
        }

        /// <summary>
        /// Add the listener which has System.Action with 2 args. It is called by generic event system.
        /// </summary>
        internal virtual void Add2ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedAddMessage(baseAction));
        }

        /// <summary>
        /// Add the listener which has System.Action with 3 args. It is called by generic event system.
        /// </summary>
        internal virtual void Add3ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedAddMessage(baseAction));
        }

        /// <summary>
        /// Add the listener which has System.Action with 4 args. It is called by generic event system.
        /// </summary>
        internal virtual void Add4ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedAddMessage(baseAction));
        }

        /// <summary>
        /// Add the listener which has System.Action with 5 args. It is called by generic event system.
        /// </summary>
        internal virtual void Add5ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedAddMessage(baseAction));
        }

        /// <summary>
        /// Add the listener which has System.Action with 6 args. It is called by generic event system.
        /// </summary>
        internal virtual void Add6ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedAddMessage(baseAction));
        }

        /// <summary>
        /// Add the listener which has System.Action with 7 args. It is called by generic event system.
        /// </summary>
        internal virtual void Add7ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedAddMessage(baseAction));
        }

        /// <summary>
        /// Add the listener which has System.Action with 8 args. It is called by generic event system.
        /// </summary>
        internal virtual void Add8ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedAddMessage(baseAction));
        }

        /// <summary>
        /// Add the listener which has System.Action with 9 args. It is called by generic event system.
        /// </summary>
        internal virtual void Add9ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedAddMessage(baseAction));
        }

        /// <summary>
        /// Add the listener which has System.Action with 10 args. It is called by generic event system.
        /// </summary>
        internal virtual void Add10ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedAddMessage(baseAction));
        }

        /// <summary>
        /// Add the listener which has System.Action with 11 args. It is called by generic event system.
        /// </summary>
        internal virtual void Add11ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedAddMessage(baseAction));
        }

        /// <summary>
        /// Add the listener which has System.Action with 12 args. It is called by generic event system.
        /// </summary>
        internal virtual void Add12ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedAddMessage(baseAction));
        }

        /// <summary>
        /// Add the listener which has System.Action with 13 args. It is called by generic event system.
        /// </summary>
        internal virtual void Add13ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedAddMessage(baseAction));
        }

        /// <summary>
        /// Add the listener which has System.Action with 14 args. It is called by generic event system.
        /// </summary>
        internal virtual void Add14ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedAddMessage(baseAction));
        }

        /// <summary>
        /// Add the listener which has System.Action with 15 args. It is called by generic event system.
        /// </summary>
        internal virtual void Add15ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedAddMessage(baseAction));
        }

        /// <summary>
        /// Add the listener which has System.Action with 16 args. It is called by generic event system.
        /// </summary>
        internal virtual void Add16ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedAddMessage(baseAction));
        }
        #endregion

        #region Remove Custom Args Listeners
        /// <summary>
        /// Remove the listener which has System.Action with zero args. It is called by generic event system.
        /// </summary>
        internal virtual void Remove0ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedRemoveMessage(baseAction));
        }

        /// <summary>
        /// Remove the listener which has System.Action with 1 args. It is called by generic event system.
        /// </summary>
        internal virtual void Remove1ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedRemoveMessage(baseAction));
        }

        /// <summary>
        /// Remove the listener which has System.Action with 2 args. It is called by generic event system.
        /// </summary>
        internal virtual void Remove2ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedRemoveMessage(baseAction));
        }

        /// <summary>
        /// Remove the listener which has System.Action with 3 args. It is called by generic event system.
        /// </summary>
        internal virtual void Remove3ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedRemoveMessage(baseAction));
        }

        /// <summary>
        /// Remove the listener which has System.Action with 4 args. It is called by generic event system.
        /// </summary>
        internal virtual void Remove4ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedRemoveMessage(baseAction));
        }

        /// <summary>
        /// Remove the listener which has System.Action with 5 args. It is called by generic event system.
        /// </summary>
        internal virtual void Remove5ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedRemoveMessage(baseAction));
        }

        /// <summary>
        /// Remove the listener which has System.Action with 6 args. It is called by generic event system.
        /// </summary>
        internal virtual void Remove6ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedRemoveMessage(baseAction));
        }

        /// <summary>
        /// Remove the listener which has System.Action with 7 args. It is called by generic event system.
        /// </summary>
        internal virtual void Remove7ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedRemoveMessage(baseAction));
        }

        /// <summary>
        /// Remove the listener which has System.Action with 8 args. It is called by generic event system.
        /// </summary>
        internal virtual void Remove8ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedRemoveMessage(baseAction));
        }

        /// <summary>
        /// Remove the listener which has System.Action with 9 args. It is called by generic event system.
        /// </summary>
        internal virtual void Remove9ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedRemoveMessage(baseAction));
        }

        /// <summary>
        /// Remove the listener which has System.Action with 10 args. It is called by generic event system.
        /// </summary>
        internal virtual void Remove10ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedRemoveMessage(baseAction));
        }

        /// <summary>
        /// Remove the listener which has System.Action with 11 args. It is called by generic event system.
        /// </summary>
        internal virtual void Remove11ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedRemoveMessage(baseAction));
        }

        /// <summary>
        /// Remove the listener which has System.Action with 12 args. It is called by generic event system.
        /// </summary>
        internal virtual void Remove12ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedRemoveMessage(baseAction));
        }

        /// <summary>
        /// Remove the listener which has System.Action with 13 args. It is called by generic event system.
        /// </summary>
        internal virtual void Remove13ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedRemoveMessage(baseAction));
        }

        /// <summary>
        /// Remove the listener which has System.Action with 14 args. It is called by generic event system.
        /// </summary>
        internal virtual void Remove14ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedRemoveMessage(baseAction));
        }

        /// <summary>
        /// Remove the listener which has System.Action with 15 args. It is called by generic event system.
        /// </summary>
        internal virtual void Remove15ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedRemoveMessage(baseAction));
        }

        /// <summary>
        /// Remove the listener which has System.Action with 16 args. It is called by generic event system.
        /// </summary>
        internal virtual void Remove16ArgsListener(BaseAction baseAction)
        {
            throw new ActionNotSupportedException(GetActionUnsupportedRemoveMessage(baseAction));
        }
        #endregion

        protected string GetActionUnsupportedAddMessage(BaseAction baseAction)
        {
            return string.Format(RegisterNotSpportedMessage, ArgTypes, baseAction.RawAction);
        }

        protected string GetActionUnsupportedRemoveMessage(BaseAction baseAction)
        {
            return string.Format(UnRegisterNotSpportedMessage, ArgTypes, baseAction.RawAction);
        }
    }
}