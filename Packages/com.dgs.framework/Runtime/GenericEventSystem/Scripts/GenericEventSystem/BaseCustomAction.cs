using System;

namespace DiaGna.Framework.GenericEventSystem
{
    /// <summary>
    /// Base class for custom actions.
    /// </summary>
    /// <typeparam name="TAction">Type of System.Action</typeparam>
    public abstract class BaseCustomAction<TAction> : BaseAction, IActionReference<TAction> where TAction : Delegate
    {
        protected TAction m_Action;
        public sealed override object RawAction => m_Action;
        public Delegate InternalAction => null;
        public TAction Action => m_Action;

        public BaseCustomAction(TAction action)
        {
            m_Action = action;
        }

        public bool Equals(IActionReference<TAction> actionRef)
        {
            if (actionRef == null) return false;
            return m_Action == actionRef.Action;
        }

        public sealed override bool Equals(object obj)
        {
            if (obj == null) return false;
            IActionReference<TAction> actionRef = obj as IActionReference<TAction>;
            if (actionRef == null) return false;
            return Equals(actionRef);
        }

        public sealed override int GetHashCode()
        {
            return m_Action.GetHashCode();
        }
    }
}
