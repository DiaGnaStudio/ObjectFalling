using UnityEngine;

namespace DiaGna.Framework.GenericEventSystem
{
    internal class EventUnregisteror
    {
        private readonly BaseEvent m_Event;
        private readonly BaseAction m_Action;

        public EventUnregisteror(BaseEvent eventReference, BaseAction actionReference)
        {
            m_Event = eventReference;
            m_Action = actionReference;
        }

        public void OnActionDestroyed(IMultipleEventHandler destroyedAction)
        {
            m_Event.RemoveListener(m_Action);

            if(destroyedAction != null)
            {
                destroyedAction.RemoveOnDestroy(OnActionDestroyed);
            }
            else
            {
                string error = string.Format("The MultiAction's OnDestoryed send null for Registeror. ActionReference: {0}." +
                    "\nIf you don't need any registeration" +
                    "for tha MultipleAction, do nothing instead of registering the Registeror's action and send null." +
                    "Note: If your script which implements the IMultipleAction can be destroyed before the IMultipleEvent object which has registered" +
                    "in, your should register the action in AddOnDestroy and invoke it unity OnDestroy method to avoid \"Object has been" +
                    "destroyed ... exception\".", m_Action.ActionName);
                Debug.LogError(error);
            }
        }
    }
}
