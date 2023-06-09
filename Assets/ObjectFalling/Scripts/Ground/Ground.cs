using DiaGna.Framework.Singletons;
using DiaGna.ObjectFalling.BrickUtility;
using System;
using UnityEngine;

namespace DiaGna.ObjectFalling.GroundUtility
{
    /// <summary>
    /// A Ground class to provides ground's components.
    /// </summary>
    public class Ground : ComponentSingleton<Ground>
    {
        [Header("Components")]
        [SerializeField] private GroundRotator m_groundRotator;

        /// <summary>
        /// <inheritdoc cref="GroundRotator.OnRotated"/>
        /// </summary>
        public event Action<Brick> OnRotated
        {
            add => m_groundRotator.OnRotated += value;
            remove => m_groundRotator.OnRotated -= value;
        }
    }
}
