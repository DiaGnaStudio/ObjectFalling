using DiaGna.Framework.Singletons;
using DiaGna.ObjectFalling.BrickUtility;
using DiaGna.ObjectFalling.Gameplay;
using System;
using System.Collections;
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
        [SerializeField] private GroundTiles m_Tiles;

        public GroundTiles Tiles => m_Tiles;

        /// <summary>
        /// <inheritdoc cref="GroundRotator.OnFinishRotating"/>
        /// </summary>
        public event Action OnFinishRotating
        {
            add => m_groundRotator.OnFinishRotating += value;
            remove => m_groundRotator.OnFinishRotating -= value;
        }
    }
}
