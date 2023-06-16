using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiaGna.ObjectFalling
{
    public class AnimalBrick : MonoBehaviour
    {
        [SerializeField] private List<Rigidbody> childRigidbodies = new List<Rigidbody>();

        private void Awake()
        {
            var tmpArray = GetComponentsInChildren<Rigidbody>();

            foreach (var rb in tmpArray)
            {
                if (rb.gameObject != this.gameObject)
                    childRigidbodies.Add(rb);
            }

            SetChildRbIsKinematic(true);
        }


        public void SetChildRbIsKinematic(bool active)
        {
            foreach (var rb in childRigidbodies)
            {
                rb.isKinematic = active;
            }
        }
    }
}
