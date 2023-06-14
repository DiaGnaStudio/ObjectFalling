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
            var worldPosition = transform.TransformPoint(Vector3.zero);
            return worldPosition.y;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (m_OnGrounded) return;
            m_OnGrounded = true;
            transform.SetParent(collision.transform.root);
            OnCollision?.Invoke(this, collision);
        }
    }
}
