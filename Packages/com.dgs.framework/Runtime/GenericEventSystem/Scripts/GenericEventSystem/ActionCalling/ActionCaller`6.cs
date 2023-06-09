using DiaGna.Framework.GenericEventSystem.CallingArguments;

namespace DiaGna.Framework.GenericEventSystem.ActionCalling
{
    internal class ActionCaller<T1, T2, T3, T4, T5, T6> : BaseActionCaller<ActionCaller<T1, T2, T3, T4, T5, T6>, 
        CustomAction<T1, T2, T3, T4, T5, T6>, Args<T1, T2, T3, T4, T5, T6>>
    {
        protected override void CustomCall(CustomAction<T1, T2, T3, T4, T5, T6> customAction, Args<T1, T2, T3, T4, T5, T6> args)
        {
            customAction.Action?.Invoke(args.m_Arg1, args.m_Arg2, args.m_Arg3, args.m_Arg4, args.m_Arg5, args.m_Arg6);
        }
    }
}
