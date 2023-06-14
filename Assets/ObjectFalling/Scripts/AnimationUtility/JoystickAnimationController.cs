using DiaGna.ObjectFalling.UserInterface.Tools;
using UnityEngine;

namespace DiaGna.ObjectFalling.AnimationUtility
{
    [RequireComponent(typeof(Animator))]
    public class JoystickAnimationController : MonoBehaviour
    {
        private Animator m_Animator;
        [SerializeField] private string m_BlendParameter;
        [SerializeField] private float m_MinBlendValue;
        [SerializeField] private float m_MaxBlendValue;
        private void Awake()
        {
            m_Animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            MoverEvent.OnDrag += HandMoving;
            MoverJoystick.OnDrag += HandMoving;
        }

        private void OnDisable()
        {
            MoverEvent.OnDrag -= HandMoving;
            MoverJoystick.OnDrag -= HandMoving;
        }

        private void HandMoving(Vector2 vector)
        {
            var value = Mathf.Clamp(vector.x, m_MinBlendValue, m_MaxBlendValue);
            m_Animator.SetFloat(m_BlendParameter, value);
        }
    }
}