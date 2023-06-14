using DiaGna.ObjectFalling.UserInterface.Tools;
using UnityEngine;

namespace DiaGna.ObjectFalling.AnimationUtility
{
    [RequireComponent(typeof(Animator))]
    public class ReleaseAnimationController : MonoBehaviour
    {
        private Animator m_Animator;
        [SerializeField] private string m_ReleaseParameter;

        private void Awake()
        {
            m_Animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            MoverEvent.OnPointerUp += Relesing;
            MoverJoystick.OnPointerUpEvent += Relesing;
        }

        private void OnDisable()
        {
            MoverEvent.OnPointerUp -= Relesing;
            MoverJoystick.OnPointerUpEvent -= Relesing;
        }

        private void Relesing()
        {
            m_Animator.SetTrigger(m_ReleaseParameter);
        }
    }
}