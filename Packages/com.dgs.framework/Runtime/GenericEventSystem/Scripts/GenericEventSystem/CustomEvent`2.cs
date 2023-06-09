using System;

namespace DiaGna.Framework.GenericEventSystem
{
    public class CustomEvent<T1, T2> : BaseCustomEvent<Action<T1, T2>, CustomEvent<T1, T2>.Args>
    {
        public struct Args
        {
            public T1 arg1;
            public T2 arg2;
        }

        public override Type[] ArgTypes => new Type[] { typeof(T1), typeof(T2)};

        internal sealed override void Add0ArgsListener(BaseAction baseAction)
        {
            try
            {
                Action action = (Action)baseAction.RawAction;
                ActionConverter0Args<T1, T2> actionConverter = new ActionConverter0Args<T1, T2>(action);
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
                ActionConverter0Args<T1 , T2> actionConverter = new ActionConverter0Args<T1, T2>(action);
                RemoveListener(actionConverter);
            }
            catch (InvalidCastException)
            {
                throw new ActionNotSupportedException(GetActionUnsupportedRemoveMessage(baseAction));
            }
        }

        internal sealed override void Add1ArgsListener(BaseAction baseAction)
        {
            try
            {
                Action<T1> action = (Action<T1>)baseAction.RawAction;
                ActionConverter1Args<T1, T2> actionConverter = new ActionConverter1Args<T1, T2>(action);
                AddListener(actionConverter);
            }
            catch (InvalidCastException)
            {
                throw new ActionNotSupportedException(GetActionUnsupportedAddMessage(baseAction));
            }
        }

        internal sealed override void Remove1ArgsListener(BaseAction baseAction)
        {
            try
            {
                Action<T1> action = (Action<T1>)baseAction.RawAction;
                ActionConverter1Args<T1, T2> actionConverter = new ActionConverter1Args<T1, T2>(action);
                RemoveListener(actionConverter);
            }
            catch (InvalidCastException)
            {
                throw new ActionNotSupportedException(GetActionUnsupportedRemoveMessage(baseAction));
            }
        }

        internal sealed override void Add2ArgsListener(BaseAction baseAction)
        {
            AddCorrespondingCustomAction(baseAction);
        }

        internal sealed override void Remove2ArgsListener(BaseAction baseAction)
        {
            RemoveCorrespondingCustomAction(baseAction);
        }

        public void Invoke(T1 value1, T2 value2)
        {
            InvokeEvents(new Args()
            {
                arg1 = value1,
                arg2 = value2
            });
        }

        protected override BaseCustomAction<Action<T1, T2>> GetCustomAction(Action<T1, T2> action)
        {
            return new CustomAction<T1, T2>(action);
        }

        protected override void InvokeEvent(IActionReference<Action<T1, T2>> actionReferece, Args args)
        {
            if (SystemSettings.m_CatchExceptions)
            {
                try
                {
                    actionReferece.Action?.Invoke(args.arg1, args.arg2);
                }
                catch (Exception exception)
                {
                    LogException(exception, actionReferece, args.arg1, args.arg2);
                }
            }
            else
            {
                actionReferece.Action?.Invoke(args.arg1, args.arg2);
            }
        }
    }
}
