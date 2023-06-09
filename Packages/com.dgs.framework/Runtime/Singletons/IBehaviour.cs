using UnityEngine;

namespace DiaGna.Framework.Singletons
{
    public interface IBehaviour
    {
        void BehaviourAwake();
        void BehaviourStart();
        void BehaviourUpdate();
        void BehaviourFixedUpdate();
    }
}