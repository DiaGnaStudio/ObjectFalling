using UnityEngine;
using UnityEngine.UI;

namespace DiaGna.Framework.GenericEventSystem.Test
{
    public class ModuleFirst : MonoBehaviour, IMultipleEvent
    {
        [SerializeField] private Button m_NoArgButton;
        [SerializeField] private Button m_IntFloatButton;
        [SerializeField] private Button m_SampleDerivedButton;

        public readonly CustomEvent OnNoArgEvent = new CustomEvent();
        public readonly CustomEvent<int, float> OnIntFloatEvent = new CustomEvent<int, float>();
        public readonly CustomEvent<SampleDerived> OnSampleDerivedEvent = new CustomEvent<SampleDerived>();

        private void Awake()
        {
            m_NoArgButton.onClick.AddListener(RaiseNoArgEvent);
            m_IntFloatButton.onClick.AddListener(RaiseIntFloatEvent);
            m_SampleDerivedButton.onClick.AddListener(RaiseSampleDerivedEvent);
        }

        public void AddEvents(EventList list)
        {
            list.Add(OnNoArgEvent);
            list.Add(OnIntFloatEvent);
            list.Add(OnSampleDerivedEvent);
        }

        private void RaiseNoArgEvent()
        {
            OnNoArgEvent.Invoke();
        }

        private void RaiseIntFloatEvent()
        {
            OnIntFloatEvent.Invoke(7, 3.5f);
        }

        private void RaiseSampleDerivedEvent()
        {
            OnSampleDerivedEvent.Invoke(new SampleDerived());
        }
    }
}
