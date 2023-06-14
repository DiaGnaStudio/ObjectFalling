using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiaGna.ObjectFalling
{
    [RequireComponent(typeof(Collider))]
    public class GroundEnder : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            collision.gameObject.SetActive(false);
        }
    }
}
