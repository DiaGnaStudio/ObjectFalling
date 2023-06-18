using DiaGna.ObjectFalling.BrickUtility;
using DiaGna.ObjectFalling.UserInterface.Tools;
using System;
using UnityEngine;

namespace DiaGna.ObjectFalling.CraneManaging
{
    [RequireComponent(typeof(Joint))]
    public class Hook : MonoBehaviour
    {
        private IBrick m_CurrentBrick;

        [Header("Components")]
        [SerializeField] private Joint m_Joint;

        /// <summary>
        /// Invokes when an object start falling.
        /// </summary>
        public event Action<IBrick> OnDrop;
        public event Action<IBrick> OnCatch;

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

        private void DropObject()
        {
            if (m_Joint.connectedBody == null) return;
            m_Joint.connectedBody = null;

            m_CurrentBrick.Drop();
            OnDrop?.Invoke(m_CurrentBrick);
        }

        public void AssignObject(IBrick currentBrick)
        {
            if (currentBrick == null) return;
            currentBrick.BrickObject.transform.rotation = Quaternion.Euler(0, -135, 0);
            currentBrick.BrickObject.transform.position = m_Joint.transform.position - m_Joint.connectedAnchor;
            m_Joint.connectedBody = currentBrick.Rigidbody;
            m_CurrentBrick = currentBrick;

            OnCatch?.Invoke(currentBrick);
        }
    }
}
