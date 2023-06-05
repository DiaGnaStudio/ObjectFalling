using System;
using UnityEngine;

namespace DiaGna.Framework.GenericEventSystem.Test
{
    public class ModuleSecond : MonoBehaviour, IMultipleEventHandler
    {
        private Action<IMultipleEventHandler> m_OnDestroy;

        private void NoArgAction()
        {
            Debug.Log("NoArg Action called");
        }

        private void IntFloatAction(int intValue, float floatValue)
        {
            string message = string.Format("IntFloat Action called, int value: {0}, float value: {1}", intValue, floatValue);
            Debug.Log(message);
        }

        private void SampleBaseAction(SampleBase sample)
        {
            Debug.Log("SampleBase Action called, ToString: " + sample.ToString());
        }

        private void SampleDerivedAction(SampleDerived sample)
        {
            Debug.Log("SampleDerived Action called, ToString: " + sample.ToString());
        }

        public void AddOnDestroy(Action<IMultipleEventHandler> action)
        {
            m_OnDestroy += action;
        }

        public void RemoveOnDestroy(Action<IMultipleEventHandler> action)
        {
            m_OnDestroy -= action;
        }

        public void AddActions(ActionList list)
        {
            list.Add(new CustomAction(NoArgAction));
            list.Add(new CustomAction<int, float>(IntFloatAction));
            list.Add(new CustomAction<SampleBase>(SampleBaseAction));
            //list.Add(new CustomAction<SampleDerived>(SampleBaseAction));
            list.Add(new CustomAction<SampleDerived>(SampleDerivedAction));
        }

        private void OnDestroy()
        {
            m_OnDestroy?.Invoke(this);
        }
    }
}
