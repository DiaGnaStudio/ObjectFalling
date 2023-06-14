using DiaGna.ObjectFalling.UserInterface.Tools;
using System;
using UnityEngine;

namespace DiaGna.ObjectFalling.CraneManaging
{
    public class CraneMover : MonoBehaviour
    {
        [SerializeField] private float m_Speed = 10.0f;
        [SerializeField] private Limit m_HorizontalLimit;
        [SerializeField] private Limit m_VerticalLimit;

        private float m_PremitiveHight;

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

        private void Start()
        {
            m_PremitiveHight = transform.position.y;
        }

        private void OnEnable()
        {
            MoverEvent.OnDrag += MoveHook;
            MoverJoystick.OnDrag += MoveHook;
        }

        private void OnDisable()
        {
            MoverEvent.OnDrag -= MoveHook;
            MoverJoystick.OnDrag -= MoveHook;
        }

        private void MoveHook(Vector2 vector)
        {
            float horizontal = vector.x * m_Speed * Time.deltaTime;
            float vertical = vector.y * m_Speed * Time.deltaTime;

            var currentPostion = transform.position;
            transform.position = new Vector3(m_HorizontalLimit.GetValue(currentPostion.x + horizontal), m_PremitiveHight, m_VerticalLimit.GetValue(currentPostion.z + vertical));
        }
    }
}
