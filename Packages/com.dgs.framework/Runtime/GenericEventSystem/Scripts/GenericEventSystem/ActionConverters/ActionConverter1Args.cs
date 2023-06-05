using System;

namespace DiaGna.Framework.GenericEventSystem
{
    internal class ActionConverter1Args<T1 , T2> : BaseActionConverter<Action<T1, T2>, Action<T1>>
    {
        public ActionConverter1Args(Action<T1> internalAction) : base(internalAction)
        {
        }

        protected override Action<T1, T2> ConvertAction(Action<T1> action)
        {
            return (t1, t2) => action(t1);
        }
    }

    internal class ActionConverter1Args<T1, T2, T3> : BaseActionConverter<Action<T1, T2, T3>, Action<T1>>
    {
        public ActionConverter1Args(Action<T1> internalAction) : base(internalAction)
        {
        }

        protected override Action<T1, T2, T3> ConvertAction(Action<T1> action)
        {
            return (t1, t2, t3) => action(t1);
        }
    }

    internal class ActionConverter1Args<T1, T2, T3, T4> : BaseActionConverter<Action<T1, T2, T3, T4>, Action<T1>>
    {
        public ActionConverter1Args(Action<T1> internalAction) : base(internalAction)
        {
        }

        protected override Action<T1, T2, T3, T4> ConvertAction(Action<T1> action)
        {
            return (t1, t2, t3, t4) => action(t1);
        }
    }

    internal class ActionConverter1Args<T1, T2, T3, T4, T5> : BaseActionConverter<Action<T1, T2, T3, T4, T5>, Action<T1>>
    {
        public ActionConverter1Args(Action<T1> internalAction) : base(internalAction)
        {
        }

        protected override Action<T1, T2, T3, T4, T5> ConvertAction(Action<T1> action)
        {
            return (t1, t2, t3, t4, t5) => action(t1);
        }
    }

    internal class ActionConverter1Args<T1, T2, T3, T4, T5, T6> : BaseActionConverter<Action<T1, T2, T3, T4, T5, T6>, Action<T1>>
    {
        public ActionConverter1Args(Action<T1> internalAction) : base(internalAction)
        {
        }

        protected override Action<T1, T2, T3, T4, T5, T6> ConvertAction(Action<T1> action)
        {
            return (t1, t2, t3, t4, t5, t6) => action(t1);
        }
    }
}
