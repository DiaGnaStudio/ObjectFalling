using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DiaGna.ObjectFalling.BrickUtility;

namespace DiaGna.ObjectFalling.GroundUtility
{
    public class GroundRotator : MonoBehaviour
    {
        [SerializeField] private float m_rotationAmount = 90.0f;
        [SerializeField] private float m_roteteDuration;
        private bool isRotating;

        [SerializeField] private List<Brick> brickList = new List<Brick>();

        public event Action<Brick> OnEndRotation;


        public void ConnectFallingObject(Brick brick)
        {
            AddBrick(brick);

            RotateGround();
        }

        private void AddBrick(Brick brick)
        {
            if (!brickList.Contains(brick))
                brickList.Add(brick);

            brick.SetBrickParent(transform);
        }
        private void RotateGround()
        {
            StartCoroutine(RotateCube());
        }

        IEnumerator RotateCube()
        {
            isRotating = true;

            float rotationPerFrame = m_rotationAmount / (m_roteteDuration / Time.deltaTime);

            float rotatedAmount = 0f;
            while (rotatedAmount < m_rotationAmount)
            {
                transform.Rotate(0f, rotationPerFrame, 0f);
                rotatedAmount += rotationPerFrame;
                yield return null;
            }

            isRotating = false;
            
            EndRotation();
        }


        private void EndRotation()
        {
            var brick = brickList[brickList.Count - 1];
            OnEndRotation?.Invoke(brick);
        }
    }
}
