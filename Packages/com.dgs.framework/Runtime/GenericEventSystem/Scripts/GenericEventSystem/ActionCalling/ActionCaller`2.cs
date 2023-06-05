using DiaGna.Framework.GenericEventSystem.CallingArguments;

namespace DiaGna.Framework.GenericEventSystem.ActionCalling
{
    internal class ActionCaller<T1, T2> : BaseActionCaller<ActionCaller<T1, T2>, CustomAction<T1, T2>, Args<T1, T2>>
    {
        protected override void CustomCall(CustomAction<T1, T2> customAction, Args<T1, T2> args)
        {
            customAction.Action?.Invoke(args.m_Arg1, args.m_Arg2);
        }
    }
}
