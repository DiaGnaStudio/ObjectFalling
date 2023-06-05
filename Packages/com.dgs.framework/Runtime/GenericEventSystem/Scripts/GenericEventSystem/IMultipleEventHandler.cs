using System;

namespace DiaGna.Framework.GenericEventSystem
{
    public interface IMultipleEventHandler
    {
        /// <summary>
        /// Adds the available actions to the action list of registeror.
        /// </summary>
        /// <param name="list"></param>
        void AddActions(ActionList list);
        /// <summary>
        /// <para>Register the action for unity OnDestory event. The action should be called on OnDestroy() and send the MultipleAction itself.</para>
        /// <para>Note: If your script which implements the IMultipleAction can be destroyed before the IMultipleEvent object which has registered
        /// in, you should register the action and invoke it unity OnDestroy method to avoid "Object has been destroyed ... exception".
        /// Also it lets the destroyed object to be accessible for garbage collectio.</para>
        /// </summary>
        void AddOnDestroy(Action<IMultipleEventHandler> action);
        /// <summary>
        /// Unregister the action for unity OnDestory event.
        /// </summary>
        void RemoveOnDestroy(Action<IMultipleEventHandler> action);
    }
}