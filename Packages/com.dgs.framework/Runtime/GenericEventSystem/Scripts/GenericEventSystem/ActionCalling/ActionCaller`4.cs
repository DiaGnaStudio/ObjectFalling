using DiaGna.Framework.GenericEventSystem.CallingArguments;

namespace DiaGna.Framework.GenericEventSystem.ActionCalling
{
    internal class ActionCaller<T1, T2, T3, T4> : BaseActionCaller<ActionCaller<T1, T2, T3, T4>, CustomAction<T1, T2, T3, T4>, 
        Args<T1, T2, T3, T4>>
    {
        protected override void CustomCall(CustomAction<T1, T2, T3, T4> customAction, Args<T1, T2, T3, T4> args)
        {
            customAction.Action?.Invoke(args.m_Arg1, args.m_Arg2, args.m_Arg3, args.m_Arg4);
        }
    }
}
