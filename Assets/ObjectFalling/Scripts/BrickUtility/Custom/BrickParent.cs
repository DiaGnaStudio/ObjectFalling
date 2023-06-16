using System;
using UnityEngine;

namespace DiaGna.ObjectFalling.BrickUtility
{
    [RequireComponent(typeof(Rigidbody))]
    public class BrickParent : MonoBehaviour, IBrick
    {
        private Brick[] m_CachedBricks;

        public event Action<IBrick[]> OnCollided;

        public bool m_Collided = false;

        public float Height => 0;
        
        public GameObject BrickObject => gameObject;

        public Rigidbody Rigidbody { get; private set; }

        public bool IsStable { get; private set; }

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            m_CachedBricks = GetComponentsInChildren<Brick>();

            foreach(var brick in m_CachedBricks)
            {
                brick.SetParent(this);
            }
        }

        private void Start()
        {
            m_Collided = false;
            SetKinematic(true);
        }

        /// <summary>
        /// Changes all chiled brick's rigidbody to <paramref name="isKinematic"/>
        /// </summary>
        /// <param name="isKinematic"></param>
        public void SetKinematic(bool isKinematic)
        {
            foreach (var brick in m_CachedBricks)
            {
                brick.Rigidbody.isKinematic = isKinematic;
            }
        }

        public float GetDistanceToGround()
        {
            float max = 0;
            foreach (var brick in m_CachedBricks)
            {
                var h = brick.GetDistanceToGround();
                if (h > max)
                {
                    max = h;
                }
            }
            return max;
        }

        public void Colliding(Brick brick)
        {
            if (m_Collided) return;
            m_Collided = true;

            OnCollided?.Invoke(m_CachedBricks);
        }

        private void Update()
        {
            var stableCount = 0;
            foreach(var brick in m_CachedBricks)
            {
                if (brick.IsStable)
                {
                    stableCount++;
                }
            }

            IsStable = stableCount == m_CachedBricks.Length;
        }
    }
}
