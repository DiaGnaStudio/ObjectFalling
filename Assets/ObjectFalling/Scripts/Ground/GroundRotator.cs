using DiaGna.ObjectFalling.BrickUtility;
using DiaGna.ObjectFalling.CraneManaging;
using DiaGna.ObjectFalling.Gameplay;
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

        private bool m_CanRotated = false;

        /// <summary>
        /// Invokes when the ground rotation finished.
        /// </summary>
        public event Action OnFinishRotating;

        private void OnEnable()
        {
            Crane.Instance.Component.Hook.OnCatch += StartChecking;
            Crane.Instance.Component.Hook.OnDrop += OnDropBrick;
        }

        private void OnDisable()
        {
            if (Crane.IsAlive)
            {
                Crane.Instance.Component.Hook.OnCatch -= StartChecking;
                Crane.Instance.Component.Hook.OnDrop -= OnDropBrick;
            }
        }

        private void StartChecking(IBrick brick)
        {
            m_CanRotated = true;
        }

        private void OnDropBrick(IBrick brick)
        {
            brick.OnCollided += ConnectFallingObject;
        }

        private void ConnectFallingObject(IBrick brick)
        {
            brick.OnCollided -= ConnectFallingObject;

            RotateGround();
        }

        private void RotateGround()
        {
            if (!m_CanRotated) return;
            m_CanRotated = false;

            StartCoroutine(RotateCube());
        }

        IEnumerator RotateCube()
        {
            yield return new WaitForSeconds(3);


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
            OnFinishRotating?.Invoke();
        }
    }
}
