using System;

namespace DiaGna.Framework.GenericEventSystem
{
    internal abstract class BaseActionConverter<TAction, TInternalAction> : IActionReference<TAction>
        where TAction : Delegate where TInternalAction : Delegate
    {
        protected TInternalAction m_InternalAction;
        protected TAction m_Action;
        public Delegate InternalAction => m_InternalAction;
        public TAction Action => m_Action;

        public BaseActionConverter(TInternalAction internalAction)
        {
            if (internalAction == null)
            {
                string error = string.Format("The internal action of {0} can not be null", GetType());
                throw new System.ArgumentNullException(error);
            }

            m_InternalAction = internalAction;
            m_Action = ConvertAction(internalAction);
        }

        public bool Equals(IActionReference<TAction> actionRef)
        {
            if (actionRef == null) return false;
            if (actionRef.InternalAction == null) return false;
            return m_InternalAction == (TInternalAction)actionRef.InternalAction;
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
            return m_InternalAction.GetHashCode();
        }

        protected abstract TAction ConvertAction(TInternalAction action);
    }
}
