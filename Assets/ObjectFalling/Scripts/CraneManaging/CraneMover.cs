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

        private void Update()
        {
            float horizontal = Input.GetAxis("Horizontal") * m_Speed * Time.deltaTime;
            float vertical = Input.GetAxis("Vertical") * m_Speed * Time.deltaTime;

            var currentPostion = transform.position;
            transform.position = new Vector3(m_HorizontalLimit.GetValue(currentPostion.x + horizontal), m_PremitiveHight, m_VerticalLimit.GetValue(currentPostion.z + vertical));
        }
    }
}
