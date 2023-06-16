using DiaGna.ObjectFalling.BrickUtility;
using DiaGna.ObjectFalling.CraneManaging;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiaGna.ObjectFalling.GroundUtility
{
    /// <summary>
    /// A ground component to rotates the ground after each brick droped.
    /// </summary>
    public class GroundRotator : MonoBehaviour
    {
        [SerializeField] private float m_rotationAmount = 90.0f;
        [SerializeField] private float m_roteteDuration;

        private readonly List<IBrick> m_BrickList = new List<IBrick>();

        /// <summary>
        /// Invokes when the ground rotation finished.
        /// </summary>
        public event Action<IBrick> OnRotated;

        private void OnEnable()
        {
            Crane.Instance.Component.Hook.OnDrop += OnDropBrick;
        }

        private void OnDisable()
        {
            if (Crane.IsAlive)
            {
                Crane.Instance.Component.Hook.OnDrop -= OnDropBrick;
            }
        }

        private void OnDropBrick(IBrick brick)
        {
            brick.OnCollided += ConnectFallingObject;
        }

        private void ConnectFallingObject(IBrick brick)
        {
            brick.OnCollided -= ConnectFallingObject;

            AddBrick(brick);

            RotateGround();
        }

        private void AddBrick(IBrick brick)
        {
            if (!m_BrickList.Contains(brick))
            {
                m_BrickList.Add(brick);
            }
        }

        private void RotateGround()
        {
            StartCoroutine(RotateCube());
        }

        IEnumerator RotateCube()
        {
            float rotationPerFrame = m_rotationAmount / (m_roteteDuration / Time.deltaTime);

            float rotatedAmount = 0f;
            while (rotatedAmount < m_rotationAmount)
            {
                transform.Rotate(0f, rotationPerFrame, 0f);
                rotatedAmount += rotationPerFrame;
                yield return null;
            }

            EndRotation();
        }

        private void EndRotation()
        {
            var brick = m_BrickList[m_BrickList.Count - 1];

            OnRotated?.Invoke(brick);
        }
    }
}
