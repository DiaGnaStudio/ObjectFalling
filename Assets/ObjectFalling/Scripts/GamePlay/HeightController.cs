using DiaGna.Framework.Singletons;
using DiaGna.ObjectFalling.BrickUtility;
using DiaGna.ObjectFalling.GroundUtility;
using DiaGna.ObjectFalling.LevelUtility;
using System;
using UnityEngine;

namespace DiaGna.ObjectFalling.Gameplay
{
    public class HeightController : ComponentSingleton<HeightController>
    {
        private float m_CurrentHight;

        public float CurrentHight => m_CurrentHight;

        public bool IsWin => m_CurrentHight >= WinHight;

        public float WinHight { get; private set; }

        public event Action<float> OnChangeHeight;

        private void OnEnable()
        {
            Ground.Instance.OnRotated += CheckBricksHeight;
            LevelLoader.Instance.OnLoadLevel += SetHeight;
        }

        private void OnDisable()
        {
            if (Ground.IsAlive)
            {
                Ground.Instance.OnRotated -= CheckBricksHeight;
            }

            if (LevelLoader.IsAlive)
            {
                LevelLoader.Instance.OnLoadLevel -= SetHeight;
            }
        }

        private void SetHeight(LevelData data)
        {
            WinHight = data.WinHeight;
        }

        private void CheckBricksHeight(Brick brick)
        {
            var lastHeight = brick.GetBrickHight();
            if (lastHeight > m_CurrentHight)
            {
                m_CurrentHight = lastHeight;

                OnChangeHeight?.Invoke(m_CurrentHight);

                if (IsWin)
                {
                    GlobalEvent.FinishGame(true);
                }
            }
        }

        private void OnDrawGizmos()
        {
#if UNITY_EDITOR
            Gizmos.color = Color.green;
            var hightPosition = transform.position + Vector3.up * WinHight;
            Gizmos.DrawLine(transform.position, hightPosition);
            UnityEditor.Handles.color = Color.green;
            UnityEditor.Handles.DrawWireDisc(hightPosition, Vector3.up, 5);
#endif
        }
    }
}
