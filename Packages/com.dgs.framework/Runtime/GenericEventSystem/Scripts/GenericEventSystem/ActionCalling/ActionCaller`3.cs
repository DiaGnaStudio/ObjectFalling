using DiaGna.Framework.GenericEventSystem.CallingArguments;

namespace DiaGna.Framework.GenericEventSystem.ActionCalling
{
    internal class ActionCaller<T1, T2, T3> : BaseActionCaller<ActionCaller<T1, T2, T3>, CustomAction<T1, T2, T3>, Args<T1, T2, T3>>
    {
        protected override void CustomCall(CustomAction<T1, T2, T3> customAction, Args<T1, T2, T3> args)
        {
            customAction.Action?.Invoke(args.m_Arg1, args.m_Arg2, args.m_Arg3);
        }
    }
}
