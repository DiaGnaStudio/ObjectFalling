using DiaGna.ObjectFalling.Gameplay;
using DiaGna.ObjectFalling.GroundUtility;
using System;
using UnityEngine;

namespace DiaGna.ObjectFalling.BrickUtility
{
    /// <summary>
    /// A class to provides a brick
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class Brick : MonoBehaviour, IBrick
    {
        [SerializeField, Min(0)] private float m_Height;
        [SerializeField, Min(0)] private float m_RayDistance;

        private bool m_OnGrounded;

        private Rigidbody m_rigidbody;

        [SerializeField] private LayerMask m_GroundLayer;
        private float m_DistanceToGround = 0;

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
        public event Action<IBrick> OnCollided;

        public void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody>();
            SetAngularDrag(10f);
        }

        public void Drop()
        {
            SetAngularDrag(0.05f);

            m_rigidbody.isKinematic = false;
        }

        private void SetAngularDrag(float dragValue)
        {
            m_rigidbody.angularDrag = dragValue;
        }

        public float GetDistanceToGround()
        {
            if (!m_OnGrounded) return -1;
            if (transform.position.y < Ground.Instance.transform.position.y) return -1;

            m_DistanceToGround = Vector3.Distance(transform.position, new Vector3(transform.position.x, Ground.Instance.transform.position.y, transform.position.z));

            return Mathf.Ceil(m_DistanceToGround + m_Height);
        }

        //private void OnCollisionEnter(Collision collision)
        //{
        //    CollisionChecking();
        //}

        //private void OnCollisionStay(Collision collision)
        //{
        //    CollisionChecking();
        //}

        private void CollisionChecking()
        {
            if (m_OnGrounded) return;
            if (Physics.Raycast(transform.position, -Vector3.up, out RaycastHit hit, m_RayDistance))
            {
                if (hit.transform.CompareTag(Ground.Instance.tag))
                {
                    m_OnGrounded = true;

                    OnCollided?.Invoke(this);

                    BrickCountAnnouncer.AddCollidedBrick(this);

                    transform.SetParent(Ground.Instance.transform);

                    SetAngularDrag(10);
                    m_rigidbody.mass = 10000;

                    gameObject.tag = Ground.Instance.tag;
                }
            }
        }

        private void Update()
        {
            if (m_rigidbody.velocity.magnitude < 0.1f)
            {
                IsStable = true;
            }
            else
            {
                IsStable = false;
            }

            CollisionChecking();
        }
    }
}
