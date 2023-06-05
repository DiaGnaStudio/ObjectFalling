using System.Collections.Generic;

namespace DiaGna.Framework.GenericEventSystem.ActionCalling
{
    internal static class ActionGetter<TCustomAction> where TCustomAction : BaseAction
    {
        public static TCustomAction GetAction(ActionRegisterData actionData, List<BaseAction> availableActions,
            bool checkCast = true) 
        {
            if (actionData.m_Action != null)
            {
                if (checkCast)
                {
                    if (actionData.m_Action is IMultipleEventHandler action)
                    {
                        return GetAction(action, actionData.m_ActionIndex, availableActions, checkCast);
                    }
                }
                else
                {
                    IMultipleEventHandler action = (IMultipleEventHandler)actionData.m_Action;
                    return GetAction(action, actionData.m_ActionIndex, availableActions, checkCast);
                }
            }

            return null;
        }

        public static TCustomAction GetAction(IMultipleEventHandler actionContainer, int actionIndex, List<BaseAction> availableActions,
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
                            availableActions.Clear();
                            return customAction;
                        }
                    }
                    else
                    {
                        TCustomAction customAction = (TCustomAction)availableActions[actionIndex];
                        availableActions.Clear();
                        return customAction;
                    }
                }
            }

            availableActions.Clear();
            return null;
        }

        private static void AddActions(IMultipleEventHandler actionContainer, List<BaseAction> availableActions)
        {
            availableActions.Clear();
            ActionList actions = new ActionList(availableActions);
            actionContainer.AddActions(actions);
        }
    }
}
