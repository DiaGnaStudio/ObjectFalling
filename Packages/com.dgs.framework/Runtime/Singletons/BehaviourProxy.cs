using UnityEngine;

namespace DiaGna.Framework.Singletons
{
    public class BehaviourProxy : MonoBehaviour
    {
        public IBehaviour m_Parent;

        public void Awake() { if (m_Parent != null) m_Parent.BehaviourAwake(); }
        public void Start() { if (m_Parent != null) m_Parent.BehaviourStart(); }
        public void Update() { if (m_Parent != null) m_Parent.BehaviourUpdate(); }
        public void FixedUpdate() { if (m_Parent != null) m_Parent.BehaviourFixedUpdate(); }
    }
}