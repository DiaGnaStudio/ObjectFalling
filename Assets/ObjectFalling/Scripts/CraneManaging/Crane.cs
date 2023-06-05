using DiaGna.Framework.Singletons;
using UnityEngine;

namespace DiaGna.ObjectFalling.CraneManaging
{
    /// <summary>
    /// A singelton class to manages the Crane.
    /// </summary>
    [RequireComponent(typeof(CraneComponent))]
    public class Crane : ComponentSingleton<Crane>
    {
        [SerializeField] private CraneComponent m_Component;

        public CraneComponent Component => m_Component;
    }
}
