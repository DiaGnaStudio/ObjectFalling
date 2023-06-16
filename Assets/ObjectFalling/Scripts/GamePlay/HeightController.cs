using DiaGna.Framework.Singletons;
using DiaGna.ObjectFalling.BrickUtility;
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
            Ground.Instance.OnRotated += AddBrick;
            LevelLoader.Instance.OnLoadLevel += SetHeight;
        }

        private void OnDisable()
        {
            if (Ground.IsAlive)
            {
                Ground.Instance.OnRotated -= AddBrick;
            }

            if (LevelLoader.IsAlive)
            {
                LevelLoader.Instance.OnLoadLevel -= SetHeight;
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


        //private void CheckBricksHeight(Brick brick)
        //{
        //    var lastHeight = brick.GetBrickHight();
        //    if (lastHeight > m_CurrentHight)
        //    {
        //        m_CurrentHight = lastHeight;

        //        OnChangeHeight?.Invoke(m_CurrentHight);

        //        if (IsWin)
        //        {
        //            GlobalEvent.FinishGame(m_CurrentHight >= WinHight);
        //        }
        //    }
        //}

        private void Update()
        {
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
