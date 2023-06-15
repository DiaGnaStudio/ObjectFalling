using DiaGna.ObjectFalling.BrickUtility;
using DiaGna.ObjectFalling.CraneManaging;
using DiaGna.ObjectFalling.UserInterface.Tools;
using UnityEngine;

namespace DiaGna.ObjectFalling
{
    [RequireComponent(typeof(Animator))]
    public class ClawAnimationController : MonoBehaviour
    {
        private Animator m_Animator;

        [SerializeField] private string m_ReleaseParameter;
        [SerializeField] private string m_CatchParameter;

        private void Awake()
        {
            m_Animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            MoverEvent.OnPointerUp += Relesing;
            MoverJoystick.OnPointerUpEvent += Relesing;

            Crane.Instance.Component.Hook.OnCatch += Catching;
        }

        private void OnDisable()
        {
            MoverEvent.OnPointerUp -= Relesing;
            MoverJoystick.OnPointerUpEvent -= Relesing;

            if (Crane.IsAlive)
            {
                Crane.Instance.Component.Hook.OnCatch -= Catching;
            }
        }

        private void Relesing()
        {
            m_Animator.SetTrigger(m_ReleaseParameter);
        }

        private void Catching(Brick brick)
        {
            m_Animator.SetTrigger(m_CatchParameter);
        }
    }
}
