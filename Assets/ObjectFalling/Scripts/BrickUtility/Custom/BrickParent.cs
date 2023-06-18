using System;
using UnityEngine;

namespace DiaGna.ObjectFalling.BrickUtility
{
    [RequireComponent(typeof(Rigidbody))]
    public class BrickParent : MonoBehaviour, IBrick
    {
        private Brick[] m_CachedBricks;

        public event Action<IBrick> OnCollided
        {
            add
            {
                foreach (var brick in m_CachedBricks)
                {
                    brick.OnCollided += value;
                }
            }
            remove
            {
                foreach (var brick in m_CachedBricks)
                {
                    brick.OnCollided += value;
                }
            }
        }

        public bool m_Collided = false;

        public float Height => 0;
        
        public GameObject BrickObject => gameObject;

        public Rigidbody Rigidbody { get; private set; }

        public bool IsStable
        {
            get
            {
                var stableCount = 0;
                foreach (var brick in m_CachedBricks)
                {
                    if (brick.IsStable)
                    {
                        stableCount++;
                    }
                }

                return stableCount == m_CachedBricks.Length;
            }
        }

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            m_CachedBricks = GetComponentsInChildren<Brick>();
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

        public void Drop()
        {
            foreach (var brick in m_CachedBricks)
            {
                brick.Drop();
                brick.Rigidbody.isKinematic = false;
            }
        }
    }
}
