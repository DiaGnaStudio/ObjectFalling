using DiaGna.Framework.Singletons;
using DiaGna.ObjectFalling.BrickUtility;
using DiaGna.ObjectFalling.LevelUtility;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DiaGna.ObjectFalling.Gameplay
{
    public class HeightController : ComponentSingleton<HeightController>
    {
        [SerializeField] private LayerMask m_BrickLayer;
        [SerializeField] private LayerMask m_GroundLayer;

        private float m_CurrentDistance;
        private float m_WinDistance;

        private List<IBrick> m_CatchedBricks = new List<IBrick>();

        public event Action<float> OnChangeHeight;

        private void OnEnable()
        {
            LevelLoader.Instance.OnLoadLevel += SetHeight;

            if (LevelLoader.Instance.IsLevelActive)
            {
                SetHeight(LevelLoader.Instance.ActiveLevel);
            }

            BrickCountAnnouncer.OnCollidedBrick += AddBrick;
        }

        private void OnDisable()
        {
            if (LevelLoader.IsAlive)
            {
                LevelLoader.Instance.OnLoadLevel -= SetHeight;
            }

            BrickCountAnnouncer.OnCollidedBrick -= AddBrick;
        }

        private void SetHeight(LevelData data)
        {
            m_WinDistance = data.WinHeight;
        }

        private void AddBrick(IBrick brick, List<IBrick> list)
        {
            if (!m_CatchedBricks.Contains(brick))
            {
                m_CatchedBricks.Add(brick);
            }
        }

        private void Update()
        {
            float maxDistance = 0;
            foreach (var brick in m_CatchedBricks)
            {
                var distanceToGround = brick.GetDistanceToGround();

                if (distanceToGround > maxDistance)
                {
                    maxDistance = distanceToGround;
                }
            }

            if (m_CurrentDistance != maxDistance)
            {
                m_CurrentDistance = maxDistance;
                OnChangeHeight?.Invoke(m_CurrentDistance);

                if (m_WinDistance <= m_CurrentDistance)
                {
                    GlobalEvent.FinishGame(true);
                }
            }
        }

        private void OnDrawGizmos()
        {
#if UNITY_EDITOR
            Gizmos.color = Color.green;
            var hightPosition = transform.position + Vector3.up * m_WinDistance;
            Gizmos.DrawLine(transform.position, hightPosition);
            UnityEditor.Handles.color = Color.green;
            UnityEditor.Handles.DrawWireDisc(hightPosition, Vector3.up, 5);
#endif
        }
    }
}
