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

        /// <summary>
        /// Invoke when a brick fall down and ground rotating is down.
        /// <para></para>
        /// <b>Parameters:</b> returns true if the bricks hight reached to the win hight.
        /// </summary>
        public static event Action<bool> OnReached;

        private void OnEnable()
        {
            Ground.Instance.OnRotated += CheckBricksHeight;
        }
        private void OnDisable()
        {
            Ground.Instance.OnRotated -= CheckBricksHeight;
        }

        private void CheckBricksHeight(Brick brick)
        {
            m_CurrentHight = brick.GetBrickHight();

            bool isReached = m_CurrentHight >= m_WinHight;

            OnReached?.Invoke(isReached);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            var hightPosition = transform.position + Vector3.up * m_WinHight;
            Gizmos.DrawLine(transform.position, hightPosition);
#if UNITY_EDITOR
            UnityEditor.Handles.color = Color.green;
            UnityEditor.Handles.DrawWireDisc(hightPosition, Vector3.up, 5);
#endif
        }
    }
}
