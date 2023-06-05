using System;

namespace DiaGna.Framework.GenericEventSystem
{
    public class CustomEvent<T1, T2, T3, T4> : BaseCustomEvent<Action<T1, T2, T3, T4>, CustomEvent<T1, T2, T3, T4>.Args>
    {
        public struct Args
        {
            public T1 arg1;
            public T2 arg2;
            public T3 arg3;
            public T4 arg4;
        }

        public override Type[] ArgTypes => new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) };

        internal sealed override void Add0ArgsListener(BaseAction baseAction)
        {
            try
            {
                Action action = (Action)baseAction.RawAction;
                ActionConverter0Args<T1, T2, T3, T4> actionConverter = new ActionConverter0Args<T1, T2, T3, T4>(action);
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
                ActionConverter0Args<T1, T2, T3, T4> actionConverter = new ActionConverter0Args<T1, T2, T3, T4>(action);
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
                ActionConverter1Args<T1, T2, T3, T4> actionConverter = new ActionConverter1Args<T1, T2, T3, T4>(action);
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
                ActionConverter1Args<T1, T2, T3, T4> actionConverter = new ActionConverter1Args<T1, T2, T3, T4>(action);
                RemoveListener(actionConverter);
            }
            catch (InvalidCastException)
            {
                throw new ActionNotSupportedException(GetActionUnsupportedRemoveMessage(baseAction));
            }
        }

        internal sealed override void Add2ArgsListener(BaseAction baseAction)
        {
            try
            {
                Action<T1, T2> action = (Action<T1, T2>)baseAction.RawAction;
                ActionConverter2Args<T1, T2, T3, T4> actionConverter = new ActionConverter2Args<T1, T2, T3, T4>(action);
                AddListener(actionConverter);
            }
            catch (InvalidCastException)
            {
                throw new ActionNotSupportedException(GetActionUnsupportedAddMessage(baseAction));
            }
        }

        internal sealed override void Remove2ArgsListener(BaseAction baseAction)
        {
            try
            {
                Action<T1, T2> action = (Action<T1, T2>)baseAction.RawAction;
                ActionConverter2Args<T1, T2, T3, T4> actionConverter = new ActionConverter2Args<T1, T2, T3, T4>(action);
                RemoveListener(actionConverter);
            }
            catch (InvalidCastException)
            {
                throw new ActionNotSupportedException(GetActionUnsupportedRemoveMessage(baseAction));
            }
        }

        internal sealed override void Add3ArgsListener(BaseAction baseAction)
        {
            try
            {
                Action<T1, T2, T3> action = (Action<T1, T2, T3>)baseAction.RawAction;
                ActionConverter3Args<T1, T2, T3, T4> actionConverter = new ActionConverter3Args<T1, T2, T3, T4>(action);
                AddListener(actionConverter);
            }
            catch (InvalidCastException)
            {
                throw new ActionNotSupportedException(GetActionUnsupportedAddMessage(baseAction));
            }
        }

        internal sealed override void Remove3ArgsListener(BaseAction baseAction)
        {
            try
            {
                Action<T1, T2, T3> action = (Action<T1, T2, T3>)baseAction.RawAction;
                ActionConverter3Args<T1, T2, T3, T4> actionConverter = new ActionConverter3Args<T1, T2, T3, T4>(action);
                RemoveListener(actionConverter);
            }
            catch (InvalidCastException)
            {
                throw new ActionNotSupportedException(GetActionUnsupportedRemoveMessage(baseAction));
            }
        }

        internal sealed override void Add4ArgsListener(BaseAction baseAction)
        {
            AddCorrespondingCustomAction(baseAction);
        }

        internal sealed override void Remove4ArgsListener(BaseAction baseAction)
        {
            RemoveCorrespondingCustomAction(baseAction);
        }

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4)
        {
            InvokeEvents(new Args()
            {
                arg1 = value1,
                arg2 = value2,
                arg3 = value3,
                arg4 = value4
            });
        }

        protected override BaseCustomAction<Action<T1, T2, T3, T4>> GetCustomAction(Action<T1, T2, T3, T4> action)
        {
            return new CustomAction<T1, T2, T3, T4>(action);
        }

        protected override void InvokeEvent(IActionReference<Action<T1, T2, T3, T4>> actionReference, Args args)
        {
            if (SystemSettings.m_CatchExceptions)
            {
                try
                {
                    actionReference.Action?.Invoke(args.arg1, args.arg2, args.arg3, args.arg4);
                }
                catch (Exception exception)
                {
                    LogException(exception, actionReference, args.arg1, args.arg2, args.arg3, args.arg4);
                }
            }
            else
            {
                actionReference.Action?.Invoke(args.arg1, args.arg2, args.arg3, args.arg4);
            }
        }
    }
}
