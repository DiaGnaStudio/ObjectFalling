using DiaGna.ObjectFalling.CraneManaging;
using DiaGna.ObjectFalling.GroundUtility;
using System;
using UnityEngine;

namespace DiaGna.ObjectFalling.BrickUtility
{
    public interface IBrick
    {
        public GameObject BrickObject { get; }
        public Rigidbody Rigidbody { get; }
        public float Height { get; }
        public bool IsStable { get; }

        /// <summary>
        /// Invokes when this brick collided with other object.
        /// </summary>
        public event Action<IBrick[]> OnCollided;

        public float GetDistanceToGround();
    }

    /// <summary>
    /// A class to provides a brick
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class Brick : MonoBehaviour, IBrick
    {
        [SerializeField, Min(0)] private float m_Height;

        private bool m_OnGrounded;

        private Rigidbody m_rigidbody;

        [SerializeField] private LayerMask m_GroundLayer;
        private float m_DistanceToGround = 0;

        private BrickParent m_Parent;

        /// <summary>
        /// Reference of brick's rigidbody.
        /// </summary>
        public Rigidbody Rigidbody => m_rigidbody;

        public bool IsStable { get; private set; }

        public float Height => m_Height;

        public GameObject BrickObject => gameObject;

        /// <summary>
        /// Invokes when this brick collided with other object.
        /// </summary>
        public event Action<IBrick[]> OnCollided
        {
            add => m_Parent.OnCollided += value;
            remove => m_Parent.OnCollided -= value;
        }

        public void Awake()
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
            if (Crane.IsAlive)
            {
                Crane.Instance.Component.Hook.OnDrop -= OnDrop;
            }
        }

        public void SetParent(BrickParent parent)
        {
            m_Parent = parent;
        }

        private void OnDrop(IBrick brick)
        {
            SetAngularDrag(0.05f);

            m_rigidbody.isKinematic = false;
            m_Parent.SetKinematic(false);
        }

        private void SetAngularDrag(float dragValue)
        {
            m_rigidbody.angularDrag = dragValue;
        }

        public float GetDistanceToGround()
        {
            if (Physics.Raycast(transform.position, -Vector3.up, out RaycastHit hitInfo, Mathf.Infinity, m_GroundLayer))
            {
                m_DistanceToGround = hitInfo.distance;
            }

            return Mathf.Ceil(m_DistanceToGround + m_Height);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (m_OnGrounded) return;
            m_OnGrounded = true;

            m_Parent.Colliding(this);

            transform.SetParent(Ground.Instance.transform);

            SetAngularDrag(10);
            m_rigidbody.mass = 10000;
        }

        private void Update()
        {
            if (!m_OnGrounded) return;

            if (m_rigidbody.velocity.magnitude < 0.1f)
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
