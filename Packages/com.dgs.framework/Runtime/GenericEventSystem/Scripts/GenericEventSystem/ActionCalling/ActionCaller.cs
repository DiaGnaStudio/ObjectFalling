using DiaGna.Framework.GenericEventSystem.CallingArguments;

namespace DiaGna.Framework.GenericEventSystem.ActionCalling
{
    internal class ActionCaller : BaseActionCaller<ActionCaller, CustomAction, NoArgs>
    {
        protected override void CustomCall(CustomAction customAction, NoArgs args)
        {
            customAction.Action?.Invoke();
        }
    }
}
