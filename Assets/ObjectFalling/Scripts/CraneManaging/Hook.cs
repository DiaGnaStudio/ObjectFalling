using System;
using UnityEngine;

namespace DiaGna.ObjectFalling.CraneManaging
{
    [RequireComponent(typeof(Joint))]
    public class Hook : MonoBehaviour
    {
        [SerializeField]private Vector3 objectPosition;

        [Header("Components")]
        private Joint m_Joint;

        public event Action OnDrop;

        private void Awake()
        {
            m_Joint = GetComponent<Joint>();
        }

        public void DropObject()
        {
            if (m_Joint.connectedBody == null) return;
            m_Joint.connectedBody = null;

            OnDrop?.Invoke();
        }

        public void AssignObject(Rigidbody target)
        {
            target.transform.position = objectPosition;
            m_Joint.connectedBody = target;
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
