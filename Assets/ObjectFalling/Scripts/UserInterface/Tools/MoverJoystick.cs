using System;
using UnityEngine;

namespace DiaGna.ObjectFalling.UserInterface.Tools
{
    /// <summary>
    /// An UserInterface tools to provides movement event by <see cref="Joystick"/>.
    /// </summary>
    [RequireComponent(typeof(Joystick))]
    public class MoverJoystick : MonoBehaviour
    {
        private static Joystick m_joystick;

        public static event Action<Vector2> OnDrag;
        public static event Action OnPointerUpEvent;

        private void Awake()
        {
            m_joystick = GetComponent<Joystick>();
        }

        private void OnEnable()
        {
            m_joystick.OnPointerUpEvent += OnPointerUp;
        }

        private void OnDisable()
        {
            m_joystick.OnPointerUpEvent -= OnPointerUp;
        }


        private void OnPointerUp()
        {
            OnPointerUpEvent?.Invoke();
        }

        private void FixedUpdate()
        {
            MoveByJoystick();
        }

        private void MoveByJoystick()
        {
            OnDrag?.Invoke(new Vector2(m_joystick.Horizontal, 0));
        }
    }
}
