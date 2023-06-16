using DiaGna.Framework.Singletons;
using DiaGna.ObjectFalling.BrickUtility;
using DiaGna.ObjectFalling.CraneManaging;
using DiaGna.ObjectFalling.GroundUtility;
using DiaGna.ObjectFalling.LevelUtility;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DiaGna.ObjectFalling.Gameplay
{
    public class HeightController : ComponentSingleton<HeightController>
    {
        private float m_CurrentHight;
        public float m_WinHight;

        private List<IBrick> m_CatchedBricks = new List<IBrick>();

        public bool IsWin => m_CurrentHight >= m_WinHight;

        public event Action<float> OnChangeHeight;

        private void OnEnable()
        {
            Crane.Instance.Component.Hook.OnDrop += OnDropBrick;
            LevelLoader.Instance.OnLoadLevel += SetHeight;
        }

        private void OnDisable()
        {
            if (Crane.IsAlive)
            {
                Crane.Instance.Component.Hook.OnDrop -= OnDropBrick;
            }

            if (LevelLoader.IsAlive)
            {
                LevelLoader.Instance.OnLoadLevel -= SetHeight;
            }
        }

        private void OnDropBrick(IBrick brick)
        {
            brick.OnCollided += ConnectFallingObject;
        }

        private void ConnectFallingObject(IBrick[] bricks)
        {
            foreach (IBrick brick in bricks)
            {
                brick.OnCollided -= ConnectFallingObject;
                AddBrick(brick);
            }
        }

        private void SetHeight(LevelData data)
        {
            m_WinHight = data.WinHeight;
        }

        private void AddBrick(IBrick brick)
        {
            m_CatchedBricks.Add(brick);
        }

        private void Update()
        {
            if (m_CatchedBricks.Count == 0) return;

            var stableCount = 0;
            foreach(var brist in m_CatchedBricks)
            {
                if (brist.IsStable)
                {
                    stableCount++;
                }
            }

            if(stableCount == m_CatchedBricks.Count)
            {
                float maxHieght = 0;
                foreach (var bricck in m_CatchedBricks)
                {
                    var height = bricck.GetDistanceToGround();
                    if (height > maxHieght)
                    {
                        maxHieght = height;
                    }
                }

                if (m_CurrentHight != maxHieght)
                {
                    m_CurrentHight = maxHieght;
                    Debug.Log(m_CurrentHight);
                    OnChangeHeight?.Invoke(m_CurrentHight);

                    if (IsWin)
                    {
                        GlobalEvent.FinishGame(true);
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
#if UNITY_EDITOR
            Gizmos.color = Color.green;
            var hightPosition = transform.position + Vector3.up * m_WinHight;
            Gizmos.DrawLine(transform.position, hightPosition);
            UnityEditor.Handles.color = Color.green;
            UnityEditor.Handles.DrawWireDisc(hightPosition, Vector3.up, 5);
#endif
        }
    }
}
