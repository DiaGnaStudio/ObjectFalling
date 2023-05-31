using UnityEngine;

namespace DiaGna.ObjectFalling.CraneManaging
{
    /// <summary>
    /// A Crane class to provides crane's components.
    /// </summary>
    public class CraneComponent : MonoBehaviour
    {
        [SerializeField] private Hook m_Hook;

        /// <summary>
        /// Returns a refrence of <see cref="CraneManaging.Hook"/>
        /// </summary>
        public Hook Hook => m_Hook;
    }
}
