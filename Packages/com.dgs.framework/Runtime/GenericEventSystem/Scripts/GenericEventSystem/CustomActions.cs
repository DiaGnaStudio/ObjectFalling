using System;

namespace DiaGna.Framework.GenericEventSystem
{
    public class CustomAction : BaseCustomAction<Action>
    {
        public override string ActionName => m_Action.Method.Name;
        public override Type[] ArgTypes => null;

        public CustomAction(Action action) : base(action) { }

        public override void AddToEvent(BaseEvent baseEvent)
        {
            baseEvent.Add0ArgsListener(this);
        }

        public override void RemoveFromEvent(BaseEvent baseEvent)
        {
            baseEvent.Remove0ArgsListener(this);
        }
    }

    public class CustomAction<T> : BaseCustomAction<Action<T>>
    {
        public override string ActionName => m_Action.Method.Name;
        public override Type[] ArgTypes => new Type[] { typeof(T) };

        public CustomAction(Action<T> action) : base(action) { }

        public override void AddToEvent(BaseEvent baseEvent)
        {
            baseEvent.Add1ArgsListener(this);
        }

        public override void RemoveFromEvent(BaseEvent baseEvent)
        {
            baseEvent.Remove1ArgsListener(this);
        }
    }

    public class CustomAction<T1, T2> : BaseCustomAction<Action<T1, T2>>
    {
        public override string ActionName => m_Action.Method.Name;
        public override Type[] ArgTypes => new Type[] { typeof(T1), typeof(T2) };

        public CustomAction(Action<T1, T2> action) : base(action) { }

        public override void AddToEvent(BaseEvent baseEvent)
        {
            baseEvent.Add2ArgsListener(this);
        }

        public override void RemoveFromEvent(BaseEvent baseEvent)
        {
            baseEvent.Remove2ArgsListener(this);
        }
    }

    public class CustomAction<T1, T2, T3> : BaseCustomAction<Action<T1, T2, T3>>
    {
        public override string ActionName => m_Action.Method.Name;
        public override Type[] ArgTypes => new Type[] { typeof(T1), typeof(T2), typeof(T3) };

        public CustomAction(Action<T1, T2, T3> action) : base(action) { }

        public override void AddToEvent(BaseEvent baseEvent)
        {
            baseEvent.Add3ArgsListener(this);
        }

        public override void RemoveFromEvent(BaseEvent baseEvent)
        {
            baseEvent.Remove3ArgsListener(this);
        }
    }

    public class CustomAction<T1, T2, T3, T4> : BaseCustomAction<Action<T1, T2, T3, T4>>
    {
        public override string ActionName => m_Action.Method.Name;
        public override Type[] ArgTypes => new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) };

        public CustomAction(Action<T1, T2, T3, T4> action) : base(action) { }

        public override void AddToEvent(BaseEvent baseEvent)
        {
            baseEvent.Add4ArgsListener(this);
        }

        public override void RemoveFromEvent(BaseEvent baseEvent)
        {
            baseEvent.Remove4ArgsListener(this);
        }
    }

    public class CustomAction<T1, T2, T3, T4, T5> : BaseCustomAction<Action<T1, T2, T3, T4, T5>>
    {
        public override string ActionName => m_Action.Method.Name;
        public override Type[] ArgTypes => new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) };

        public CustomAction(Action<T1, T2, T3, T4, T5> action) : base(action) { }

        public override void AddToEvent(BaseEvent baseEvent)
        {
            baseEvent.Add5ArgsListener(this);
        }

        public override void RemoveFromEvent(BaseEvent baseEvent)
        {
            baseEvent.Remove5ArgsListener(this);
        }
    }

    public class CustomAction<T1, T2, T3, T4, T5, T6> : BaseCustomAction<Action<T1, T2, T3, T4, T5, T6>>
    {
        public override string ActionName => m_Action.Method.Name;
        public override Type[] ArgTypes => new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) };

        public CustomAction(Action<T1, T2, T3, T4, T5, T6> action) : base(action) { }

        public override void AddToEvent(BaseEvent baseEvent)
        {
            baseEvent.Add6ArgsListener(this);
        }

        public override void RemoveFromEvent(BaseEvent baseEvent)
        {
            baseEvent.Remove6ArgsListener(this);
        }
    }
}
