using System;

namespace DiaGna.Framework.GenericEventSystem
{
    internal class ActionConverter5Args<T1, T2, T3, T4, T5, T6> : BaseActionConverter<Action<T1, T2, T3, T4, T5, T6>, Action<T1, T2, T3, T4, T5>>
    {
        public ActionConverter5Args(Action<T1, T2, T3, T4, T5> internalAction) : base(internalAction)
        {
        }

        protected override Action<T1, T2, T3, T4, T5, T6> ConvertAction(Action<T1, T2, T3, T4, T5> action)
        {
            return (t1, t2, t3, t4, t5, t6) => action(t1, t2, t3, t4, t5);
        }
    }
}
