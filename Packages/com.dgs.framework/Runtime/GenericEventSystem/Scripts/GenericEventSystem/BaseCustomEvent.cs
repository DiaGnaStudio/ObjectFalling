using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace DiaGna.Framework.GenericEventSystem
{
    /// <summary>
    /// Base class for custom events.
    /// </summary>
    /// <typeparam name="TAction">Type of System.Action</typeparam>
    public abstract class BaseCustomEvent<TAction, TArgs> : BaseEvent where TAction : Delegate where TArgs : struct
    {
        #region Event
        private List<IActionReference<TAction>> m_ActionList;
        #endregion

        #region Registering Methods
        public sealed override void AddListener(BaseAction baseAction)
        {
            baseAction.AddToEvent(this);
        }

        public sealed override void RemoveListener(BaseAction baseAction)
        {
            baseAction.RemoveFromEvent(this);
        }

        public sealed override void RemoveAllListeners()
        {
            if(m_ActionList != null)
            {
                m_ActionList.Clear();
            }
        }

        protected void AddListener(IActionReference<TAction> actionReference)
        {
            if (m_ActionList != null)
            {
                m_ActionList.Add(actionReference);
            }
            else
            {
                m_ActionList = new List<IActionReference<TAction>>(SystemSettings.InitialEventSize);
                m_ActionList.Add(actionReference);
            }
        }

        protected void RemoveListener(IActionReference<TAction> actionReference)
        {
            if(m_ActionList != null)
            {
                for(int i = m_ActionList.Count - 1; i > -1; i--)
                {
                    bool isEqual = m_ActionList[i].Equals(actionReference);
                    if (isEqual)
                    {
                        m_ActionList.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        public void AddListener(BaseCustomAction<TAction> customAction)
        {
            AddListener((IActionReference<TAction>)customAction);
        }

        public void RemoveListener(BaseCustomAction<TAction> customAction)
        {
            RemoveListener((IActionReference<TAction>)customAction);
        }

        public void AddListener(TAction action)
        {
            AddListener(GetCustomAction(action));
        }

        public void RemoveListener(TAction action)
        {
            RemoveListener(GetCustomAction(action));
        }

        protected void AddCorrespondingCustomAction(BaseAction baseAction)
        {
            try
            {
                // it is required to create another instance of CustomAction because it's generic modifier may not be the same as CustomEvent,
                // but it's action can be implicitly casted to TAction.
                TAction action = (TAction)baseAction.RawAction;
                BaseCustomAction<TAction> customAction = GetCustomAction(action);
                AddListener(customAction);
            }
            catch (InvalidCastException)
            {
                throw new ActionNotSupportedException(GetActionUnsupportedAddMessage(baseAction));
            }
        }

        protected void RemoveCorrespondingCustomAction(BaseAction baseAction)
        {
            try
            {
                // it is required to create another instance of CustomAction because it's generic modifier may not be the same as CustomEvent,
                // but it's action can be implicitly casted to TAction.
                TAction action = (TAction)baseAction.RawAction;
                BaseCustomAction<TAction> customAction = GetCustomAction(action);
                RemoveListener(customAction);
            }
            catch (InvalidCastException)
            {
                throw new ActionNotSupportedException(GetActionUnsupportedAddMessage(baseAction));
            }
        }

        protected abstract BaseCustomAction<TAction> GetCustomAction(TAction action);
        #endregion

        #region Invoke Event
        protected void InvokeEvents(TArgs args)
        {
            if (m_ActionList != null)
            {
                for (int i = m_ActionList.Count - 1; i > -1;)
                {
                    if(m_ActionList[i].Action != null)
                    {
                        InvokeEvent(m_ActionList[i], args);
                    }

                    i--;

                    //In InvokeEvent() method some of actions may be removed. Check actions count again to avoid index out of range exception.
                    if(i > m_ActionList.Count - 1)
                    {
                        i = m_ActionList.Count - 1;
                    }
                }
            }
        }

        /// <summary>
        /// Invoke a registered action of custom event
        /// </summary>
        /// <param name="actionReference">Action refernece containing the action to be invoked</param>
        /// <param name="args">Arguments to pass to action</param>
        protected abstract void InvokeEvent(IActionReference<TAction> actionReference, TArgs args);
        #endregion

        #region Message Methods
        /// <summary>
        /// Log custom event exception with no arguments
        /// </summary>
        protected void LogException(Exception exception, IActionReference<TAction> actionReference)
        {
            LogException(exception, actionReference, null);
        }

        /// <summary>
        /// Log custom event exception with one argument
        /// </summary>
        protected void LogException<T>(Exception exception, IActionReference<TAction> actionReference, T arg)
        {
            LogException(exception, actionReference, arg.ToString());
        }

        /// <summary>
        /// Log custom event exception with 2 arguments
        /// </summary>
        protected void LogException<T1, T2>(Exception exception, IActionReference<TAction> actionReference, T1 arg1, T2 arg2)
        {
            string args = string.Format("{0}, {1}", arg1.ToString(), arg2.ToString());
            LogException(exception, actionReference, args);
        }

        /// <summary>
        /// Log custom event exception with 3 arguments
        /// </summary>
        protected void LogException<T1, T2, T3>(Exception exception, IActionReference<TAction> actionReference, T1 arg1, T2 arg2, T3 arg3)
        {
            string args = string.Format("{0}, {1}, {2}", arg1.ToString(), arg2.ToString(), arg3.ToString());
            LogException(exception, actionReference, args);
        }

        /// <summary>
        /// Log custom event exception with 4 arguments
        /// </summary>
        protected void LogException<T1, T2, T3, T4>(Exception exception, IActionReference<TAction> actionReference, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            object[] argsMessageArgs = new object[4];
            argsMessageArgs[0] = arg1.ToString();
            argsMessageArgs[1] = arg2.ToString();
            argsMessageArgs[2] = arg3.ToString();
            argsMessageArgs[3] = arg4.ToString();
            string args = string.Format("{0}, {1}, {2}, {3}", argsMessageArgs);
            LogException(exception, actionReference, args);
        }

        /// <summary>
        /// Log custom event exception with 5 arguments
        /// </summary>
        protected void LogException<T1, T2, T3, T4, T5>(Exception exception, IActionReference<TAction> actionReference, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            object[] argsMessageArgs = new object[5];
            argsMessageArgs[0] = arg1.ToString();
            argsMessageArgs[1] = arg2.ToString();
            argsMessageArgs[2] = arg3.ToString();
            argsMessageArgs[3] = arg4.ToString();
            argsMessageArgs[4] = arg5.ToString();
            string args = string.Format("{0}, {1}, {2}, {3}, {4}", argsMessageArgs);
            LogException(exception, actionReference, args);
        }

        /// <summary>
        /// Log custom event exception with 6 arguments
        /// </summary>
        protected void LogException<T1, T2, T3, T4, T5, T6>(Exception exception, IActionReference<TAction> actionReference, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            object[] argsMessageArgs = new object[6];
            argsMessageArgs[0] = arg1.ToString();
            argsMessageArgs[1] = arg2.ToString();
            argsMessageArgs[2] = arg3.ToString();
            argsMessageArgs[3] = arg4.ToString();
            argsMessageArgs[4] = arg5.ToString();
            argsMessageArgs[5] = arg6.ToString();
            string args = string.Format("{0}, {1}, {2}, {3}, {4}, {5}", argsMessageArgs);
            LogException(exception, actionReference, args);
        }

        private void LogException(Exception exception, IActionReference<TAction> actionReference, string args)
        {
            object[] messageArgs = new object[5];
            messageArgs[0] = typeof(TAction).Name;
            Delegate internalAction = (actionReference.InternalAction != null) ? actionReference.InternalAction : actionReference.Action;
            messageArgs[1] = internalAction.Method.Name;
            messageArgs[2] = internalAction.Target.ToString();
            if(args != null)
            {
                messageArgs[3] = "event arguments {" + args + "}";

            }
            else
            {
                messageArgs[3] = "no event arguments";
            }
            messageArgs[4] = exception.ToString();
            string message = string.Format("Exception was caught by generic event system while invoking event. Event type: {0}, Problematic " +
                "action: method `{1}` of `{2}` with {3}.\n===Exception: {4}", messageArgs);

            Object targetObject = internalAction.Target as Object;
            if(targetObject != null)
            {
                Debug.LogError(message, targetObject);
            }
            else
            {
                Debug.LogError(message);
            }
        }
        #endregion
    }
}
