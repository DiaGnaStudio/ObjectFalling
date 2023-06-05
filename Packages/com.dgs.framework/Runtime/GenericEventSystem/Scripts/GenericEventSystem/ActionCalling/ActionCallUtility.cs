using System.Collections.Generic;
using DiaGna.Framework.GenericEventSystem.CallingArguments;

namespace DiaGna.Framework.GenericEventSystem.ActionCalling
{
    /// <summary>
    /// Utility class to call actions of <see cref="IMultipleEventHandler"/> with provided index.
    /// <para>Note: Calling actions in this way is not thread safe.</para>
    /// </summary>
    public static class ActionCallUtility
    {
        private static List<BaseAction> m_AvailableActions;

        /// <summary>
        /// Call the action with provided index in the <paramref name="actionContainer"/>.
        /// </summary>
        /// <param name="checkCast">Whether checking the type of corresponding <see cref="BaseAction"/> for invoking the internal delegate.</param>
        public static void Call(IMultipleEventHandler actionContainer, int actionIndex, bool checkCast = true)
        {
            InitizeActionList();
            ActionCaller.Instance.Call(actionContainer, actionIndex, new NoArgs(), m_AvailableActions, checkCast);
        }

        /// <summary>
        /// Call the action with provided index in the <paramref name="actionContainer"/>.
        /// </summary>
        /// <param name="checkCast">Whether checking the type of corresponding <see cref="BaseAction"/> for invoking the internal delegate.</param>
        public static void Call(ActionRegisterData actionData, bool checkCast = true)
        {
            InitizeActionList();
            ActionCaller.Instance.Call(actionData, new NoArgs(), m_AvailableActions, checkCast);
        }

        /// <summary>
        /// Call the action with provided index in the <paramref name="actionContainer"/> with it's corresponding arguments.
        /// </summary>
        /// <param name="checkCast">Whether checking the type of corresponding <see cref="BaseAction"/> for invoking the internal delegate.</param>
        public static void Call<T>(IMultipleEventHandler actionContainer, int actionIndex, T arg, bool checkCast = true)
        {
            InitizeActionList();
            ActionCaller<T>.Instance.Call(actionContainer, actionIndex, new Args<T>(arg), m_AvailableActions, checkCast);
        }

        /// <summary>
        /// Call the action with provided index in the <paramref name="actionContainer"/> with it's corresponding arguments.
        /// </summary>
        /// <param name="checkCast">Whether checking the type of corresponding <see cref="BaseAction"/> for invoking the internal delegate.</param>
        public static void Call<T>(ActionRegisterData actionData, T arg, bool checkCast = true)
        {
            InitizeActionList();
            ActionCaller<T>.Instance.Call(actionData, new Args<T>(arg), m_AvailableActions, checkCast);
        }

        /// <summary>
        /// Call the action with provided index in the <paramref name="actionContainer"/> with it's corresponding arguments.
        /// </summary>
        /// <param name="checkCast">Whether checking the type of corresponding <see cref="BaseAction"/> for invoking the internal delegate.</param>
        public static void Call<T1, T2>(IMultipleEventHandler actionContainer, int actionIndex, T1 arg1, T2 arg2, bool checkCast = true)
        {
            InitizeActionList();
            ActionCaller<T1, T2>.Instance.Call(actionContainer, actionIndex, new Args<T1, T2>(arg1, arg2), m_AvailableActions, checkCast);
        }

        /// <summary>
        /// Call the action with provided index in the <paramref name="actionContainer"/> with it's corresponding arguments.
        /// </summary>
        /// <param name="checkCast">Whether checking the type of corresponding <see cref="BaseAction"/> for invoking the internal delegate.</param>
        public static void Call<T1, T2>(ActionRegisterData actionData, T1 arg1, T2 arg2, bool checkCast = true)
        {
            InitizeActionList();
            ActionCaller<T1, T2>.Instance.Call(actionData, new Args<T1, T2>(arg1, arg2), m_AvailableActions, checkCast);
        }

        /// <summary>
        /// Call the action with provided index in the <paramref name="actionContainer"/> with it's corresponding arguments.
        /// </summary>
        /// <param name="checkCast">Whether checking the type of corresponding <see cref="BaseAction"/> for invoking the internal delegate.</param>
        public static void Call<T1, T2, T3>(IMultipleEventHandler actionContainer, int actionIndex, T1 arg1, T2 arg2, T3 arg3,
            bool checkCast = true)
        {
            InitizeActionList();
            ActionCaller<T1, T2, T3>.Instance.Call(actionContainer, actionIndex, new Args<T1, T2, T3>(arg1, arg2, arg3), m_AvailableActions,
                checkCast);
        }

        /// <summary>
        /// Call the action with provided index in the <paramref name="actionContainer"/> with it's corresponding arguments.
        /// </summary>
        /// <param name="checkCast">Whether checking the type of corresponding <see cref="BaseAction"/> for invoking the internal delegate.</param>
        public static void Call<T1, T2, T3>(ActionRegisterData actionData, T1 arg1, T2 arg2, T3 arg3, bool checkCast = true)
        {
            InitizeActionList();
            ActionCaller<T1, T2, T3>.Instance.Call(actionData, new Args<T1, T2, T3>(arg1, arg2, arg3), m_AvailableActions, checkCast);
        }

        /// <summary>
        /// Call the action with provided index in the <paramref name="actionContainer"/> with it's corresponding arguments.
        /// </summary>
        /// <param name="checkCast">Whether checking the type of corresponding <see cref="BaseAction"/> for invoking the internal delegate.</param>
        public static void Call<T1, T2, T3, T4>(IMultipleEventHandler actionContainer, int actionIndex, T1 arg1, T2 arg2, T3 arg3, T4 arg4,
           bool checkCast = true)
        {
            InitizeActionList();
            ActionCaller<T1, T2, T3, T4>.Instance.Call(actionContainer, actionIndex, new Args<T1, T2, T3, T4>(arg1, arg2, arg3, arg4),
                m_AvailableActions, checkCast);
        }

        /// <summary>
        /// Call the action with provided index in the <paramref name="actionContainer"/> with it's corresponding arguments.
        /// </summary>
        /// <param name="checkCast">Whether checking the type of corresponding <see cref="BaseAction"/> for invoking the internal delegate.</param>
        public static void Call<T1, T2, T3, T4>(ActionRegisterData actionData, T1 arg1, T2 arg2, T3 arg3, T4 arg4,
          bool checkCast = true)
        {
            InitizeActionList();
            ActionCaller<T1, T2, T3, T4>.Instance.Call(actionData, new Args<T1, T2, T3, T4>(arg1, arg2, arg3, arg4),
                m_AvailableActions, checkCast);
        }

        /// <summary>
        /// Call the action with provided index in the <paramref name="actionContainer"/> with it's corresponding arguments.
        /// </summary>
        /// <param name="checkCast">Whether checking the type of corresponding <see cref="BaseAction"/> for invoking the internal delegate.</param>
        public static void Call<T1, T2, T3, T4, T5>(IMultipleEventHandler actionContainer, int actionIndex, T1 arg1, T2 arg2, T3 arg3, T4 arg4,
           T5 arg5, bool checkCast = true)
        {
            InitizeActionList();
            ActionCaller<T1, T2, T3, T4, T5>.Instance.Call(actionContainer, actionIndex, new Args<T1, T2, T3, T4, T5>(arg1, arg2, arg3, arg4,
                arg5), m_AvailableActions, checkCast);
        }

        /// <summary>
        /// Call the action with provided index in the <paramref name="actionContainer"/> with it's corresponding arguments.
        /// </summary>
        /// <param name="checkCast">Whether checking the type of corresponding <see cref="BaseAction"/> for invoking the internal delegate.</param>
        public static void Call<T1, T2, T3, T4, T5>(ActionRegisterData actionData, T1 arg1, T2 arg2, T3 arg3, T4 arg4,
           T5 arg5, bool checkCast = true)
        {
            InitizeActionList();
            ActionCaller<T1, T2, T3, T4, T5>.Instance.Call(actionData, new Args<T1, T2, T3, T4, T5>(arg1, arg2, arg3, arg4,
                arg5), m_AvailableActions, checkCast);
        }

        /// <summary>
        /// Call the action with provided index in the <paramref name="actionContainer"/> with it's corresponding arguments.
        /// </summary>
        /// <param name="checkCast">Whether checking the type of corresponding <see cref="BaseAction"/> for invoking the internal delegate.</param>
        public static void Call<T1, T2, T3, T4, T5, T6>(IMultipleEventHandler actionContainer, int actionIndex, T1 arg1, T2 arg2, T3 arg3,
            T4 arg4, T5 arg5, T6 arg6, bool checkCast = true)
        {
            InitizeActionList();
            ActionCaller<T1, T2, T3, T4, T5, T6>.Instance.Call(actionContainer, actionIndex, new Args<T1, T2, T3, T4, T5, T6>(arg1, arg2, arg3,
                arg4, arg5, arg6), m_AvailableActions, checkCast);
        }

        /// <summary>
        /// Call the action with provided index in the <paramref name="actionContainer"/> with it's corresponding arguments.
        /// </summary>
        /// <param name="checkCast">Whether checking the type of corresponding <see cref="BaseAction"/> for invoking the internal delegate.</param>
        public static void Call<T1, T2, T3, T4, T5, T6>(ActionRegisterData actionData, T1 arg1, T2 arg2, T3 arg3,
            T4 arg4, T5 arg5, T6 arg6, bool checkCast = true)
        {
            InitizeActionList();
            ActionCaller<T1, T2, T3, T4, T5, T6>.Instance.Call(actionData, new Args<T1, T2, T3, T4, T5, T6>(arg1, arg2, arg3,
                arg4, arg5, arg6), m_AvailableActions, checkCast);
        }

        /// <summary>
        /// Returns the chosen custom action.
        /// </summary>
        /// <param name="checkCast">Whether checking the type of corresponding <see cref="BaseAction"/> for returning custom action.</param>
        public static CustomAction GetAction(ActionRegisterData actionData, bool checkCast = true)
        {
            InitizeActionList();
            return ActionGetter<CustomAction>.GetAction(actionData, m_AvailableActions, checkCast);
        }

        /// <summary>
        /// Returns the custom action with provided index in the <paramref name="actionContainer"/>.
        /// </summary>
        /// <param name="checkCast">Whether checking the type of corresponding <see cref="BaseAction"/> for returning custom action.</param>
        public static CustomAction GetAction(IMultipleEventHandler actionContainer, int actionIndex, bool checkCast = true)
        {
            InitizeActionList();
            return ActionGetter<CustomAction>.GetAction(actionContainer, actionIndex, m_AvailableActions, checkCast);
        }

        /// <summary>
        /// Returns the chosen custom action.
        /// </summary>
        /// <param name="checkCast">Whether checking the type of corresponding <see cref="BaseAction"/> for returning custom action.</param>
        public static CustomAction<T> GetAction<T>(ActionRegisterData actionData, bool checkCast = true)
        {
            InitizeActionList();
            return ActionGetter<CustomAction<T>>.GetAction(actionData, m_AvailableActions, checkCast);
        }

        /// <summary>
        /// Returns the custom action with provided index in the <paramref name="actionContainer"/>.
        /// </summary>
        /// <param name="checkCast">Whether checking the type of corresponding <see cref="BaseAction"/> for returning custom action.</param>
        public static CustomAction<T> GetAction<T>(IMultipleEventHandler actionContainer, int actionIndex, bool checkCast = true)
        {
            InitizeActionList();
            return ActionGetter<CustomAction<T>>.GetAction(actionContainer, actionIndex, m_AvailableActions, checkCast);
        }

        /// <summary>
        /// Returns the chosen custom action.
        /// </summary>
        /// <param name="checkCast">Whether checking the type of corresponding <see cref="BaseAction"/> for returning custom action.</param>
        public static CustomAction<T1, T2> GetAction<T1, T2>(ActionRegisterData actionData, bool checkCast = true)
        {
            InitizeActionList();
            return ActionGetter<CustomAction<T1, T2>>.GetAction(actionData, m_AvailableActions, checkCast);
        }

        /// <summary>
        /// Returns the custom action with provided index in the <paramref name="actionContainer"/>.
        /// </summary>
        /// <param name="checkCast">Whether checking the type of corresponding <see cref="BaseAction"/> for returning custom action.</param>
        public static CustomAction<T1, T2> GetAction<T1, T2>(IMultipleEventHandler actionContainer, int actionIndex, bool checkCast = true)
        {
            InitizeActionList();
            return ActionGetter<CustomAction<T1, T2>>.GetAction(actionContainer, actionIndex, m_AvailableActions, checkCast);
        }

        /// <summary>
        /// Returns the chosen custom action.
        /// </summary>
        /// <param name="checkCast">Whether checking the type of corresponding <see cref="BaseAction"/> for returning custom action.</param>
        public static CustomAction<T1, T2, T3> GetAction<T1, T2, T3>(ActionRegisterData actionData, bool checkCast = true)
        {
            InitizeActionList();
            return ActionGetter<CustomAction<T1, T2, T3>>.GetAction(actionData, m_AvailableActions, checkCast);
        }

        /// <summary>
        /// Returns the custom action with provided index in the <paramref name="actionContainer"/>.
        /// </summary>
        /// <param name="checkCast">Whether checking the type of corresponding <see cref="BaseAction"/> for returning custom action.</param>
        public static CustomAction<T1, T2, T3> GetAction<T1, T2, T3>(IMultipleEventHandler actionContainer, int actionIndex, bool checkCast = true)
        {
            InitizeActionList();
            return ActionGetter<CustomAction<T1, T2, T3>>.GetAction(actionContainer, actionIndex, m_AvailableActions, checkCast);
        }

        /// <summary>
        /// Returns the chosen custom action.
        /// </summary>
        /// <param name="checkCast">Whether checking the type of corresponding <see cref="BaseAction"/> for returning custom action.</param>
        public static CustomAction<T1, T2, T3, T4> GetAction<T1, T2, T3, T4>(ActionRegisterData actionData, bool checkCast = true)
        {
            InitizeActionList();
            return ActionGetter<CustomAction<T1, T2, T3, T4>>.GetAction(actionData, m_AvailableActions, checkCast);
        }

        /// <summary>
        /// Returns the custom action with provided index in the <paramref name="actionContainer"/>.
        /// </summary>
        /// <param name="checkCast">Whether checking the type of corresponding <see cref="BaseAction"/> for returning custom action.</param>
        public static CustomAction<T1, T2, T3, T4> GetAction<T1, T2, T3, T4>(IMultipleEventHandler actionContainer, int actionIndex, bool checkCast = true)
        {
            InitizeActionList();
            return ActionGetter<CustomAction<T1, T2, T3, T4>>.GetAction(actionContainer, actionIndex, m_AvailableActions, checkCast);
        }

        /// <summary>
        /// Returns the chosen custom action.
        /// </summary>
        /// <param name="checkCast">Whether checking the type of corresponding <see cref="BaseAction"/> for returning custom action.</param>
        public static CustomAction<T1, T2, T3, T4, T5> GetAction<T1, T2, T3, T4, T5>(ActionRegisterData actionData, bool checkCast = true)
        {
            InitizeActionList();
            return ActionGetter<CustomAction<T1, T2, T3, T4, T5>>.GetAction(actionData, m_AvailableActions, checkCast);
        }

        /// <summary>
        /// Returns the custom action with provided index in the <paramref name="actionContainer"/>.
        /// </summary>
        /// <param name="checkCast">Whether checking the type of corresponding <see cref="BaseAction"/> for returning custom action.</param>
        public static CustomAction<T1, T2, T3, T4, T5> GetAction<T1, T2, T3, T4, T5>(IMultipleEventHandler actionContainer, int actionIndex, bool checkCast = true)
        {
            InitizeActionList();
            return ActionGetter<CustomAction<T1, T2, T3, T4, T5>>.GetAction(actionContainer, actionIndex, m_AvailableActions, checkCast);
        }

        /// <summary>
        /// Returns the chosen custom action.
        /// </summary>
        /// <param name="checkCast">Whether checking the type of corresponding <see cref="BaseAction"/> for returning custom action.</param>
        public static CustomAction<T1, T2, T3, T4, T5, T6> GetAction<T1, T2, T3, T4, T5, T6>(ActionRegisterData actionData, bool checkCast = true)
        {
            InitizeActionList();
            return ActionGetter<CustomAction<T1, T2, T3, T4, T5, T6>>.GetAction(actionData, m_AvailableActions, checkCast);
        }

        /// <summary>
        /// Returns the custom action with provided index in the <paramref name="actionContainer"/>.
        /// </summary>
        /// <param name="checkCast">Whether checking the type of corresponding <see cref="BaseAction"/> for returning custom action.</param>
        public static CustomAction<T1, T2, T3, T4, T5, T6> GetAction<T1, T2, T3, T4, T5, T6>(IMultipleEventHandler actionContainer, int actionIndex, bool checkCast = true)
        {
            InitizeActionList();
            return ActionGetter<CustomAction<T1, T2, T3, T4, T5, T6>>.GetAction(actionContainer, actionIndex, m_AvailableActions, checkCast);
        }

        private static void InitizeActionList()
        {
            if(m_AvailableActions == null)
            {
                m_AvailableActions = new List<BaseAction>();
            }
        }
    }
}
