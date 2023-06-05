# Multiple Event System

An event system for unity which works with c# events and supports registering actions to those events in unity inspector. It still register actions in runtime but marks to register what action to what event.

## How To Use

### Setup Evetns

Setup your class events for multiple event system.

- Implement the `IMultipleEvent` interface.

- In `AddEvetns(EventList list)` add your desired `CustomEvent` instances.

Example:

```csharp
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
```

### Setup Actions

Setup your class actions for multiple event system.

- Implement the `IMultipleEventHandler` interface.

- In `AddEvetns(EventList list)` add your desired `CustomAction<T>` instances with your required `EventArgs` types.

- Have an event of type `Action<IMultipleEventHandler>` which you call on `OnDestroy` method and add and remove actions to/from it in `AddOnDestroy(Action<IMultipleEventHandler> action)` and `RemoveOnDestroy(Action<IMultipleEventHandler> action)` methods respectively. This avoids calling methods on destroyed objects and let destroyed object to be garbage collected.

Example:

```csharp
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
```

Example Requirements:

```csharp
public class SampleBase
    {
        public override string ToString()
        {
            return "Sample Base";
        }
    }
    
public class SampleDerived : SampleBase
    {
        public override string ToString()
        {
            return "Sample Derived";
        }
    }
```

### Setup Registeror

With `EventRegisteror` component you attach your desired events in any class implemented `IMultipleEvent` to the actions in any class implemented `IMultipleEventHandler`.

Above examples exist in `[demo]` scene.
