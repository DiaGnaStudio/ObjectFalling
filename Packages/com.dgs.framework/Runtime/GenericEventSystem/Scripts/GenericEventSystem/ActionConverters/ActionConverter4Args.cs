using System;

namespace DiaGna.Framework.GenericEventSystem
{
    internal class ActionConverter4Args<T1, T2, T3, T4, T5> : BaseActionConverter<Action<T1, T2, T3, T4, T5>, Action<T1, T2, T3, T4>>
    {
        public ActionConverter4Args(Action<T1, T2, T3, T4> internalAction) : base(internalAction)
        {
        }

        protected override Action<T1, T2, T3, T4, T5> ConvertAction(Action<T1, T2, T3, T4> action)
        {
            return (t1, t2, t3, t4, t5) => action(t1, t2, t3, t4);
        }
    }

    internal class ActionConverter4Args<T1, T2, T3, T4, T5, T6> : BaseActionConverter<Action<T1, T2, T3, T4, T5, T6>, Action<T1, T2, T3, T4>>
    {
        public ActionConverter4Args(Action<T1, T2, T3, T4> internalAction) : base(internalAction)
        {
        }

        protected override Action<T1, T2, T3, T4, T5, T6> ConvertAction(Action<T1, T2, T3, T4> action)
        {
            return (t1, t2, t3, t4, t5, t6) => action(t1, t2, t3, t4);
        }
    }
}
