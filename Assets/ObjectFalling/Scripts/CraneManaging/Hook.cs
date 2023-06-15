﻿using DiaGna.ObjectFalling.BrickUtility;
using DiaGna.ObjectFalling.UserInterface.Tools;
using System;
using UnityEngine;

namespace DiaGna.ObjectFalling.CraneManaging
{
    [RequireComponent(typeof(Joint))]
    public class Hook : MonoBehaviour
    {
        [SerializeField] private float m_Offset;

        private Brick m_CurrentBrick;

        [Header("Components")]
        [SerializeField] private Joint m_Joint;

        /// <summary>
        /// Invokes when an object start falling.
        /// </summary>
        public event Action<Brick> OnDrop;
        public event Action<Brick> OnCatch;

        private void OnEnable()
        {
            MoverEvent.OnPointerUp += DropObject;
            MoverJoystick.OnPointerUpEvent += DropObject;
        }

        private void OnDisable()
        {
            MoverEvent.OnPointerUp -= DropObject;
            MoverJoystick.OnPointerUpEvent -= DropObject;
        }

        public void AssignObject(Brick currentBrick)
        {
            currentBrick.transform.rotation = Quaternion.Euler(0, 180, 0);
            currentBrick.transform.position = new Vector3(0, m_Joint.transform.localPosition.y -m_Offset, 0);
            m_Joint.connectedBody = currentBrick.Rigidbody;
            m_CurrentBrick = currentBrick;

            OnCatch?.Invoke(currentBrick);
        }

        private void DropObject()
        {
            if (m_Joint.connectedBody == null) return;
            m_Joint.connectedBody = null;

            OnDrop?.Invoke(m_CurrentBrick);
        }
    }
}
