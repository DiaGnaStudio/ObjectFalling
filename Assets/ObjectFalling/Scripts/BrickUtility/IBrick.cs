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
        public event Action<IBrick> OnCollided;

        public float GetDistanceToGround();

        public void Drop();
    }
}
