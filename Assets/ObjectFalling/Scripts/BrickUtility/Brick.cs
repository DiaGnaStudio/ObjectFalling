using DiaGna.ObjectFalling.CraneManaging;
using System;
using UnityEngine;

namespace DiaGna.ObjectFalling.BrickUtility
{
    /// <summary>
    /// A class to provides a brick
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class Brick : MonoBehaviour
    {
        [SerializeField,Min(0)] private float m_Height;

        private bool m_OnGrounded;

        private Rigidbody m_rigidbody;

        [SerializeField] private LayerMask m_GroundLayer;
        float m_DistanceToGround = 0;

        /// <summary>
        /// Reference of brick's rigidbody.
        /// </summary>
        public Rigidbody Rigidbody => m_rigidbody;

        /// <summary>
        /// Invokes when this brick collided with other object.
        /// </summary>
        public event Action<Brick, Collision> OnCollision;

        private void OnEnable()
        {
            Crane.Instance.Component.Hook.OnDrop += OnDrop;
        }

        private void OnDisable()
        {
            if (Crane.IsAlive)
            {
                Crane.Instance.Component.Hook.OnDrop -= OnDrop;
            }
        }

        public void Active()
        {
            m_rigidbody = GetComponent<Rigidbody>();
            SetAngularDrag(10f);
        }

        private void OnDrop(Brick brick)
        {
            SetAngularDrag(0.05f);
        }

        private void SetAngularDrag(float dragValue)
        {
            m_rigidbody.angularDrag = dragValue;
        }

        public float GetBrickHight()
        {
            if (Physics.Raycast(transform.position, -Vector3.up, out hitInfo, Mathf.Infinity, m_GroundLayer))
            {
                m_DistanceToGround = hitInfo.distance;
            }

            return Mathf.Ceil(m_DistanceToGround + m_Height);
        }
        RaycastHit hitInfo;

        private void OnCollisionEnter(Collision collision)
        {
            if (Physics.Raycast(transform.position, -Vector3.up, out hitInfo, Mathf.Infinity, m_GroundLayer))
            {
                m_DistanceToGround = hitInfo.distance;
            }

            if (m_OnGrounded) return;
            m_OnGrounded = true;
            transform.SetParent(collision.transform.root);
            OnCollision?.Invoke(this, collision);
            SFXPlayer.Instance.PlaySFX(SfxType.GroundCollision);
        }

        public bool IsStable { get; private set; }

        private void Update()
        {
            if(m_rigidbody.velocity.magnitude < 0.5f)
            {
                IsStable = true;
            }
            else
            {
                IsStable = false;
            }
        }
    }
}
