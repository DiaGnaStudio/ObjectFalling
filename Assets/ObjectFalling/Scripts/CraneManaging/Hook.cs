using DiaGna.ObjectFalling.BrickUtility;
using System;
using UnityEngine;

namespace DiaGna.ObjectFalling.CraneManaging
{
    [RequireComponent(typeof(Joint))]
    public class Hook : MonoBehaviour
    {
        [SerializeField] private Vector3 objectPosition;

        private Brick m_CurrentBrick;

        [Header("Components")]
        private Joint m_Joint;

        /// <summary>
        /// Invokes when an object start falling.
        /// </summary>
        public event Action<Brick> OnDrop;

        private void Awake()
        {
            m_Joint = GetComponent<Joint>();
        }

        public void AssignObject(Brick currentBrick)
        {
            currentBrick.transform.position = objectPosition;
            m_Joint.connectedBody = currentBrick.Rigidbody;
            m_CurrentBrick = currentBrick;
        }

        public void DropObject()
        {
            if (m_Joint.connectedBody == null) return;
            m_Joint.connectedBody = null;

            OnDrop?.Invoke(m_CurrentBrick);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DropObject();
            }
        }
    }
}
