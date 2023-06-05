using System;

namespace DiaGna.Framework.GenericEventSystem
{
    public class CustomEvent<T> : BaseCustomEvent<Action<T>, CustomEvent<T>.Args>
    {
        public struct Args
        {
            public T arg;
        }

        public override Type[] ArgTypes => new Type[] { typeof(T) };

        internal sealed override void Add0ArgsListener(BaseAction baseAction)
        {
            try
            {
                Action action = (Action)baseAction.RawAction;
                ActionConverter0Args<T> actionConverter = new ActionConverter0Args<T>(action);
                AddListener(actionConverter);
            }
            catch (InvalidCastException)
            {
                throw new ActionNotSupportedException(GetActionUnsupportedAddMessage(baseAction));
            }
        }

        internal sealed override void Remove0ArgsListener(BaseAction baseAction)
        {
            try
            {
                Action action = (Action)baseAction.RawAction;
                ActionConverter0Args<T> actionConverter = new ActionConverter0Args<T>(action);
                RemoveListener(actionConverter);
            }
            catch (InvalidCastException)
            {
                throw new ActionNotSupportedException(GetActionUnsupportedRemoveMessage(baseAction));
            }
        }

        internal sealed override void Add1ArgsListener(BaseAction baseAction)
        {
            AddCorrespondingCustomAction(baseAction);
        }

        internal sealed override void Remove1ArgsListener(BaseAction baseAction)
        {
            RemoveCorrespondingCustomAction(baseAction);
        }

        public void Invoke(T value)
        {
            InvokeEvents(new Args() { arg = value });
        }

        protected override BaseCustomAction<Action<T>> GetCustomAction(Action<T> action)
        {
            return new CustomAction<T>(action);
        }

        protected override void InvokeEvent(IActionReference<Action<T>> actionReferece, Args args)
        {
            if (SystemSettings.m_CatchExceptions)
            {
                try
                {
                    actionReferece.Action?.Invoke(args.arg);
                }
                catch (Exception exception)
                {
                    LogException(exception, actionReferece, args.arg);
                }
            }
            else
            {
                actionReferece.Action?.Invoke(args.arg);
            }
        }
    }
}
