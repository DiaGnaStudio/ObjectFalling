using System;

namespace DiaGna.Framework.GenericEventSystem
{
    public class CustomEvent : BaseCustomEvent<Action, bool>
    {
        public override Type[] ArgTypes => new Type[] { typeof(void) };

        internal sealed override void Add0ArgsListener(BaseAction baseAction)
        {
            AddCorrespondingCustomAction(baseAction);
        }

        internal sealed override void Remove0ArgsListener(BaseAction baseAction)
        {
            RemoveCorrespondingCustomAction(baseAction);
        }

        public void Invoke()
        {
            InvokeEvents(true);
        }

        protected override BaseCustomAction<Action> GetCustomAction(Action action)
        {
            return new CustomAction(action);
        }

        protected override void InvokeEvent(IActionReference<Action> actionReference, bool args)
        {
            if (SystemSettings.m_CatchExceptions)
            {
                try
                {
                    actionReference.Action?.Invoke();
                }
                catch (Exception exception)
                {
                    LogException(exception, actionReference);
                }
            }
            else
            {
                actionReference.Action?.Invoke();
            }
        }
    }
}
