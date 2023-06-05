using System;

namespace DiaGna.Framework.GenericEventSystem
{
    internal class ActionConverter0Args<T> : BaseActionConverter<Action<T>, Action>
    {
        public ActionConverter0Args(Action internalAction) : base(internalAction)
        {
        }

        protected override Action<T> ConvertAction(Action action)
        {
            return (t) => action();
        }
    }

    internal class ActionConverter0Args<T1, T2> : BaseActionConverter<Action<T1, T2>, Action>
    {
        public ActionConverter0Args(Action internalAction) : base(internalAction)
        {
        }

        protected override Action<T1, T2> ConvertAction(Action action)
        {
            return (t1, t2) => action();
        }
    }

    internal class ActionConverter0Args<T1, T2, T3> : BaseActionConverter<Action<T1, T2, T3>, Action>
    {
        public ActionConverter0Args(Action internalAction) : base(internalAction)
        {
        }

        protected override Action<T1, T2, T3> ConvertAction(Action action)
        {
            return (t1, t2, t3) => action();
        }
    }

    internal class ActionConverter0Args<T1, T2, T3, T4> : BaseActionConverter<Action<T1, T2, T3, T4>, Action>
    {
        public ActionConverter0Args(Action internalAction) : base(internalAction)
        {
        }

        protected override Action<T1, T2, T3, T4> ConvertAction(Action action)
        {
            return (t1, t2, t3, t4) => action();
        }
    }

    internal class ActionConverter0Args<T1, T2, T3, T4, T5> : BaseActionConverter<Action<T1, T2, T3, T4, T5>, Action>
    {
        public ActionConverter0Args(Action internalAction) : base(internalAction)
        {
        }

        protected override Action<T1, T2, T3, T4, T5> ConvertAction(Action action)
        {
            return (t1, t2, t3, t4, t5) => action();
        }
    }

    internal class ActionConverter0Args<T1, T2, T3, T4, T5, T6> : BaseActionConverter<Action<T1, T2, T3, T4, T5, T6>, Action>
    {
        public ActionConverter0Args(Action internalAction) : base(internalAction)
        {
        }

        protected override Action<T1, T2, T3, T4, T5, T6> ConvertAction(Action action)
        {
            return (t1, t2, t3, t4, t5, t6) => action();
        }
    }
}
