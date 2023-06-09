using System;
using UnityEngine;

namespace DiaGna.ObjectFalling.CraneManaging
{
    [RequireComponent(typeof(JoystickRef))]
    public class CraneMover : MonoBehaviour
    {
        [SerializeField] private float m_Speed = 10.0f;
        [SerializeField] private Limit m_HorizontalLimit;
        [SerializeField] private Limit m_VerticalLimit;

        private float m_PremitiveHight;

        private FloatingJoystick movementJoystick;
        [SerializeField] private float joystickDeadzone;

        [Serializable]
        private struct Limit
        {
            [SerializeField] private float m_Min;
            [SerializeField] private float m_Max;

            public float GetValue(float value)
            {
                return Mathf.Clamp(value, m_Min, m_Max);
            }
        }

        private void OnEnable()
        {
            movementJoystick.OnPointerUpEvent += OnReleaseTouch;
        }
        private void OnDisable()
        {
            movementJoystick.OnPointerUpEvent -= OnReleaseTouch;
        }

        private void Awake()
        {
            FillReferences();
        }

        private void Start()
        {
            m_PremitiveHight = transform.position.y;
        }

        private void Update()
        {
            float horizontal = Input.GetAxis("Horizontal") * m_Speed * Time.deltaTime;
            float vertical = Input.GetAxis("Vertical") * m_Speed * Time.deltaTime;

            if(CanMoveByJoystick())
            {
                Vector2 joystickDirection = MoveByJoystick();

                horizontal = joystickDirection.x;
                vertical = joystickDirection.y;
            }
                

            var currentPostion = transform.position;
            transform.position = new Vector3(m_HorizontalLimit.GetValue(currentPostion.x + horizontal), m_PremitiveHight, m_VerticalLimit.GetValue(currentPostion.z + vertical));
        }

        private Vector2 MoveByJoystick()
        {
            float horizontal = movementJoystick.Horizontal * m_Speed * Time.deltaTime;
            float vertical = movementJoystick.Vertical * m_Speed * Time.deltaTime;

            Vector2 joystickDirection = new Vector2(horizontal, vertical);

            return joystickDirection;
        }
        private bool CanMoveByJoystick()
        {
            var canMove = movementJoystick.Horizontal >= joystickDeadzone ||
                 movementJoystick.Horizontal <= -joystickDeadzone;

            return canMove;
        }

        private void OnReleaseTouch()
        {
            Crane.Instance.Component.Hook.DropObject();
        }

        private void FillReferences()
        {
            var joystickRef = GetComponent<JoystickRef>();
            movementJoystick = joystickRef.Joystick;
        }
    }
}
