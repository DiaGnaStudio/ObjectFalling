using DiaGna.ObjectFalling.CraneManaging;
using System;
using UnityEngine;
using DiaGna.ObjectFalling.GroundUtility;

namespace DiaGna.ObjectFalling.BrickUtility
{
    public class Brick : MonoBehaviour
    {
        [SerializeField, Min(0)] private float m_Hight;

        public float Hight => m_Hight;

        private Rigidbody m_rigidbody;
        public Rigidbody Rigidbody => m_rigidbody;

        private bool isGrounded;

        private void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody>();
            SetAngularDrag(10f);
        }

        private void OnEnable()
        {
            Crane.Instance.Component.Hook.OnDrop += OnDrop;
        }

        private void OnDisable()
        {
            Crane.Instance.Component.Hook.OnDrop -= OnDrop;
        }
        private void OnDrop()
        {
            SetAngularDrag(0.05f);
        }

        private void SetAngularDrag(float dragValue)
        {
            m_rigidbody.angularDrag = dragValue;
        }

        private void OnCollidedToGround()
        {
            isGrounded = true;
            Ground.Instance.GroundRotator.ConnectFallingObject(this);
        }

        public void SetBrickParent(Transform parentTransform)
        {
            transform.parent = parentTransform;
        }

        public float GetBrickHight()
        {
            var worldPosition = transform.TransformPoint(Vector3.zero);
            m_Hight = worldPosition.y;

            return m_Hight;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(!isGrounded)
                OnCollidedToGround();
        }
    }
}
