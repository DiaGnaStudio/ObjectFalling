using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiaGna.ObjectFalling
{
    public class GroundTiles : MonoBehaviour
    {
        [SerializeField] private List<GameObject> m_Ttiles = new List<GameObject>();

        public List<GameObject> GetTtiles() => m_Ttiles;
    }
}
