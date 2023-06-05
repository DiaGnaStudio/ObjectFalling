using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using DiaGna.Framework.Attributes;

namespace DiaGna.Framework.GenericEventSystem
{
    public abstract class EventRegisteror : MonoBehaviour
    {
        public const int RegistersId = 0;

        [Tooltip("If true register events, otherwise it won't register events anytime.")]
        [SerializeField] private bool m_IsActive = true;
        [HideInInspector]
        [EditorModifiable(FieldID = RegistersId)]
        [SerializeField] protected RegisterData[] m_Registers;
        private static List<BaseEvent> m_EventList = new List<BaseEvent>();
        private static List<BaseAction> m_ActionList = new List<BaseAction>();

        public void RegisterEvents()
        {
            if (m_IsActive && m_Registers != null)
            {
                for (int i = 0; i < m_Registers.Length; i++)
                {
                    RegisterData registerData = m_Registers[i];
                    bool actionExists = registerData.m_Action != null;
                    bool eventExists = registerData.m_Event != null;

                    if (actionExists && eventExists)
                    {
                        IMultipleEventHandler multiAction = (IMultipleEventHandler)registerData.m_Action;
                        IMultipleEvent multiEvent = (IMultipleEvent)registerData.m_Event;
                        RegisterEvent(multiAction, registerData.m_ActionIndex, multiEvent, registerData.m_EventIndex);
                    }
                }
            }
        }

        public void UnregisterEvents()
        {
            for (int i = 0; i < m_Registers.Length; i++)
            {
                RegisterData registerData = m_Registers[i];
                bool actionExists = registerData.m_Action != null;
                bool eventExists = registerData.m_Event != null;

                if (actionExists && eventExists)
                {
                    IMultipleEventHandler multiAction = (IMultipleEventHandler)registerData.m_Action;
                    IMultipleEvent multiEvent = (IMultipleEvent)registerData.m_Event;
                    UnregisterEvent(multiAction, registerData.m_ActionIndex, multiEvent, registerData.m_EventIndex);
                }
            }
        }

        protected void RegisterEvent(IMultipleEventHandler multiAction, int actionIndex, IMultipleEvent multiEvent, int eventIndex)
        {
            try
            {
                BaseAction actionReference = GetActionReference(multiAction, actionIndex);
                BaseEvent eventReference = GetEventReference(multiEvent, eventIndex);

                if (actionReference != null && eventReference != null)
                {
                    eventReference.AddListener(actionReference);
                    EventUnregisteror unregisteror = new EventUnregisteror(eventReference, actionReference);
                    multiAction.AddOnDestroy(unregisteror.OnActionDestroyed);
                }
            }
            catch (Exception exception)
            {
                Object actionObject = (Object)multiAction;
                Object eventObject = (Object)multiEvent;
                Debug.LogException(exception, actionObject);
                object[] errorArgs = new object[6];
                errorArgs[0] = actionObject.name;
                errorArgs[1] = multiAction.GetType();
                errorArgs[2] = actionIndex;
                errorArgs[3] = eventObject.name;
                errorArgs[4] = multiEvent.GetType();
                errorArgs[5] = eventIndex;
                string error = string.Format("The multiple registeration for MultipleAction \"{0}\" of type {1} with index {2} and MultipleEvent " +
                    "\"{3}\" of type {4} with index {5} was failed by exception.", errorArgs);
                Debug.LogError(error);
            }
        }

        private void UnregisterEvent(IMultipleEventHandler multiAction, int actionIndex, IMultipleEvent multiEvent, int eventIndex)
        {
            try
            {
                BaseAction actionReference = GetActionReference(multiAction, actionIndex);
                BaseEvent eventReference = GetEventReference(multiEvent, eventIndex);

                if (actionReference != null && eventReference != null)
                {
                    eventReference.RemoveListener(actionReference);
                }
            }
            catch (Exception exception)
            {
                Object actionObject = (Object)multiAction;
                Object eventObject = (Object)multiEvent;
                Debug.LogException(exception, actionObject);
                object[] errorArgs = new object[6];
                errorArgs[0] = actionObject.name;
                errorArgs[1] = multiAction.GetType();
                errorArgs[2] = actionIndex;
                errorArgs[3] = eventObject.name;
                errorArgs[4] = multiEvent.GetType();
                errorArgs[5] = eventIndex;
                string error = string.Format("The multiple unregisteration for MultipleAction \"{0}\" of type {1} with index {2} and MultipleEvent " +
                    "\"{3}\" of type {4} with index {5} was failed by exception.", errorArgs);
                Debug.LogError(error);
            }
        }

        private BaseAction GetActionReference(IMultipleEventHandler multiAction, int actionIndex)
        {
            m_ActionList.Clear();
            multiAction.AddActions(new ActionList(m_ActionList));
            if (actionIndex > -1 && actionIndex < m_ActionList.Count)
            {
                return m_ActionList[actionIndex];
            }

            Object actionsObject = (Object)multiAction;
            object[] errorArgs = new object[6];
            errorArgs[0] = actionIndex.ToString();
            errorArgs[1] = (m_ActionList.Count - 1).ToString();
            errorArgs[2] = actionsObject.name;
            errorArgs[3] = multiAction.GetType().ToString();
            errorArgs[4] = typeof(IMultipleEventHandler).ToString();
            errorArgs[5] = this.name;
            string error = string.Format("The stored action index {0} is not in the range (0-{1}) of added actions by {2}. The AddActions() code in" +
                " {3} or the {4} reference in {5} may have changed. Try reselecting the desired action in registeror.", errorArgs);
            Debug.LogError(error);
            return null;
        }

        private BaseEvent GetEventReference(IMultipleEvent multiEvent, int eventIndex)
        {
            m_EventList.Clear();
            multiEvent.AddEvents(new EventList(m_EventList));
            if (eventIndex > -1 && eventIndex < m_EventList.Count)
            {
                return m_EventList[eventIndex];
            }

            Object eventsObject = (Object)multiEvent;
            object[] errorArgs = new object[6];
            errorArgs[0] = eventIndex.ToString();
            errorArgs[1] = (m_EventList.Count - 1).ToString();
            errorArgs[2] = eventsObject.name;
            errorArgs[3] = multiEvent.GetType().ToString();
            errorArgs[4] = typeof(IMultipleEvent).ToString();
            errorArgs[5] = this.name;
            string error = string.Format("The stored event index {0} is not in the range (0-{1}) of added events by {2}. The AddEvents() code in" +
                " {3} or the {4} reference in {5} may have changed. Try reselecting the desired event in registeror.", errorArgs);
            Debug.LogError(error);
            return null;
        }
    }
}
