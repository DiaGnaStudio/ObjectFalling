using DiaGna.Framework.GenericEventSystem.CallingArguments;

namespace DiaGna.Framework.GenericEventSystem.ActionCalling
{
    internal class ActionCaller<T1, T2, T3, T4, T5> : BaseActionCaller<ActionCaller<T1, T2, T3, T4, T5>, CustomAction<T1, T2, T3, T4, T5>, 
        Args<T1, T2, T3, T4, T5>>
    {
        protected override void CustomCall(CustomAction<T1, T2, T3, T4, T5> customAction, Args<T1, T2, T3, T4, T5> args)
        {
            customAction.Action?.Invoke(args.m_Arg1, args.m_Arg2, args.m_Arg3, args.m_Arg4, args.m_Arg5);
        }
    }
}
