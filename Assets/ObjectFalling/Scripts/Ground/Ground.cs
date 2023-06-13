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
        [SerializeField] private float m_moveDownDuration;
        private float m_lastHeight;

        /// <summary>
        /// <inheritdoc cref="GroundRotator.OnRotated"/>
        /// </summary>
        public event Action<Brick> OnRotated
        {
            add => m_groundRotator.OnRotated += value;
            remove => m_groundRotator.OnRotated -= value;
        }

        private void OnEnable()
        {
            FinishLine.OnChangeHeight += MoveDown;
        }

        private void OnDisable()
        {
            FinishLine.OnChangeHeight -= MoveDown;
        }

        private void MoveDown(float newHeight)
        {
            if (newHeight > m_lastHeight)
            {
                StartCoroutine(MoveDownCoroutine(newHeight));
            }
        }

        IEnumerator MoveDownCoroutine(float newHeight)
        {
            float moveAmount = newHeight - m_lastHeight;
            float movePerFrame = moveAmount / (m_moveDownDuration / Time.deltaTime);
            m_lastHeight = newHeight;


            float currentMoveAmount = 0f;
            while (currentMoveAmount < moveAmount)
            {
                transform.Translate(0f, movePerFrame, 0f);
                currentMoveAmount += movePerFrame;
                yield return null;
            }
        }
    }
}
