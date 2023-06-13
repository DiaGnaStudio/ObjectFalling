using DiaGna.ObjectFalling.BrickUtility;
using DiaGna.ObjectFalling.GroundUtility;
using System;
using UnityEngine;

namespace DiaGna.ObjectFalling.Gameplay
{
    public class FinishLine : MonoBehaviour
    {
        [SerializeField] private float m_WinHight;
        private float m_CurrentHight;
        private float m_LastHight;

        [Header("Line")]
        [SerializeField] private Material m_LineMaterial;

        /// <summary>
        /// Invoke when a brick fall down and ground rotating is down.
        /// <para></para>
        /// <b>Parameters:</b> returns true if the bricks hight reached to the win hight.
        /// </summary>
        public static event Action<bool> OnReached;
        public static event Action<float> OnChangeHeight;

        private void Awake()
        {
            CreateFinishLine();
        }

        private void OnEnable()
        {
            Ground.Instance.OnRotated += CheckBricksHeight;
        }
        private void OnDisable()
        {
            if (Ground.IsAlive)
            {
                Ground.Instance.OnRotated -= CheckBricksHeight;
            }
        }

        private void CheckBricksHeight(Brick brick)
        {
            m_CurrentHight = brick.GetBrickHight();

            Debug.Log("H = " + m_CurrentHight);
            //bool increaseHeight = m_CurrentHight > m_LastHight;
            //if(increaseHeight)
            //{
            //    m_LastHight = m_CurrentHight;
            //}
            OnChangeHeight?.Invoke(m_CurrentHight);

            bool isReached = m_CurrentHight >= m_WinHight;

            OnReached?.Invoke(isReached);
        }

        private void OnDrawGizmos()
        {
#if UNITY_EDITOR
            Gizmos.color = Color.green;
            var hightPosition = transform.position + Vector3.up * m_WinHight;
            Gizmos.DrawLine(transform.position, hightPosition);
            UnityEditor.Handles.color = Color.green;
            UnityEditor.Handles.DrawWireDisc(hightPosition, Vector3.up, 5);
#endif
        }

        private void CreateFinishLine()
        {
            var line = transform.GetChild(0);
            line.SetParent(transform);
            line.localPosition = new Vector3(3, m_WinHight / 2, 0);
            line.localRotation = Quaternion.Euler(0, 45, 0);
            line.localScale = new Vector3(0.5f, m_WinHight, 0.5f);
        }
    }
}
