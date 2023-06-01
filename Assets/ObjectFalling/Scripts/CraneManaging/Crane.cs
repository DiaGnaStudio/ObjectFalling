using UnityEngine;

namespace DiaGna.ObjectFalling.CraneManaging
{
    /// <summary>
    /// A singelton class to manages the Crane.
    /// </summary>
    [RequireComponent(typeof(CraneComponent))]
    public class Crane : MonoBehaviour
    {
        public static Crane Instance { get; private set; }

        [SerializeField] private CraneComponent m_Component;

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public CraneComponent Component => m_Component;
    }
}
