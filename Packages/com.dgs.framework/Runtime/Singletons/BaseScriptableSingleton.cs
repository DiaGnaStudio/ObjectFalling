using UnityEngine;

namespace DiaGna.Framework.Singletons
{
    public abstract class BaseScriptableSingleton : ScriptableObject, IBehaviour
    {
        [Tooltip("Set true to create a MonoBehaviour as a proxy for MonoBehaviour methods and register for unity event functions such" +
            " as Awake, Start, ...")]
        [SerializeField] private bool m_UseProxy = false;

        public bool UseProxy => m_UseProxy;

        protected abstract void Initialize();

        public virtual void BehaviourAwake() { }

        public virtual void BehaviourFixedUpdate() { }

        public virtual void BehaviourStart() { }

        public virtual void BehaviourUpdate() { }
    }
}