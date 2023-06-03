using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiaGna.ObjectFalling.GroundUtility
{
    public class Ground : MonoBehaviour
    {
        public static Ground Instance { get; private set; }

        [SerializeField] private GroundRotator m_groundRotator;
        public GroundRotator GroundRotator => m_groundRotator;

        private void Awake()
        {
            if (!Instance)
                Instance = this;
            else
                Destroy(gameObject);
        }
    }
}
