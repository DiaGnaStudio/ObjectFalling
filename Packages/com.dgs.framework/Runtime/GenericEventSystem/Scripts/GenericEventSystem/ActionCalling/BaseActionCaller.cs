using System.Collections.Generic;

namespace DiaGna.Framework.GenericEventSystem.ActionCalling
{
    internal abstract class BaseActionCaller<TCaller, TCustomAction, TArgs> where TCaller : BaseActionCaller<TCaller, TCustomAction, TArgs>,
        new() where TCustomAction : BaseAction where TArgs : struct
    {
        private static TCaller m_Instance;

        public static TCaller Instance
        {
            get
            {
                if(m_Instance == null)
                {
                    m_Instance = new TCaller();
                }

                return m_Instance;
            }
        }

        public void Call(ActionRegisterData actionData, TArgs args, List<BaseAction> availableActions, bool checkCast = true)
        {
            if (actionData.m_Action != null)
            {
                if (checkCast)
                {
                    if (actionData.m_Action is IMultipleEventHandler action)
                    {
                        Call(action, actionData.m_ActionIndex, args, availableActions, checkCast);
                    }
                }
                else
                {
                    IMultipleEventHandler action = (IMultipleEventHandler)actionData.m_Action;
                    Call(action, actionData.m_ActionIndex, args, availableActions, checkCast);
                }
            }
        }

        public void Call(IMultipleEventHandler actionContainer, int actionIndex, TArgs args, List<BaseAction> availableActions,
            bool checkCast = true)
        {
            if (actionContainer != null && actionIndex > -1)
            {
                AddActions(actionContainer, availableActions);

                if (actionIndex < availableActions.Count)
                {
                    if (checkCast)
                    {
                        if (availableActions[actionIndex] is TCustomAction customAction)
                        {
                            CustomCall(customAction, args);
                        }
                    }
                    else
                    {
                        TCustomAction customAction = (TCustomAction)availableActions[actionIndex];
                        CustomCall(customAction, args);
                    }
                }

                availableActions.Clear();
            }
        }

        protected abstract void CustomCall(TCustomAction customAction, TArgs args);

        private static void AddActions(IMultipleEventHandler actionContainer, List<BaseAction> availableActions)
        {
            availableActions.Clear();
            ActionList actions = new ActionList(availableActions);
            actionContainer.AddActions(actions);
        }
    }
}
