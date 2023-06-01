using UnityEngine;

namespace DiaGna.ObjectFalling.BrickUtility
{
    public class Brick : MonoBehaviour
    {
        [SerializeField, Min(0)] private float m_Hight;

        public float Hight => m_Hight;
    }
}
