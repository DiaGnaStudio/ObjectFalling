using DiaGna.Framework.GenericEventSystem.CallingArguments;

namespace DiaGna.Framework.GenericEventSystem.ActionCalling
{
    internal class ActionCaller<T> : BaseActionCaller<ActionCaller<T>, CustomAction<T>, Args<T>>
    {
        protected override void CustomCall(CustomAction<T> customAction, Args<T> args)
        {
            customAction.Action?.Invoke(args.m_Arg);
        }
    }
}
