using DiaGna.ObjectFalling.CraneManaging;
using DiaGna.ObjectFalling.Gameplay;
using DiaGna.ObjectFalling.GroundUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiaGna.ObjectFalling.BrickUtility
{
    public class BrickCreator : MonoBehaviour
    {
        [SerializeField, Min(0)] private float m_Delay = 1;
        private Coroutine m_CreatingCoroutine;

        private List<Brick> m_BrickPrefabs = new List<Brick>();

        public void AddPrefab(Brick prefab)
        {
            if (m_BrickPrefabs.Contains(prefab)) return;
            m_BrickPrefabs.Add(prefab);
        }

        private void OnEnable()
        {
            GlobalEvent.OnStartGame += Creating;
            GlobalEvent.OnFinishGame += StopCreating;
            Ground.Instance.OnRotated += CheckCrating;
        }

        private void OnDisable()
        {
            GlobalEvent.OnStartGame -= Creating;
            if (Ground.IsAlive)
            {
                Ground.Instance.OnRotated -= CheckCrating;
            }
        }

        private void CheckCrating(Brick brick)
        {
            if (HeightController.Instance.IsWin) return;

            Creating();
        }

        [ContextMenu("Creating")]
        private void Creating()
        {
            m_CreatingCoroutine ??= StartCoroutine(WaitToCreate());
        }

        private IEnumerator WaitToCreate()
        {
            yield return new WaitForSeconds(m_Delay);

            Brick brick = GetBrick();
            Crane.Instance.Component.Hook.AssignObject(brick);
        }

        private Brick GetBrick()
        {
            if (m_BrickPrefabs.Count == 0)
            {
                Debug.LogError("No brick avaialbe!");
                return null;
            }

            var brick = Instantiate(m_BrickPrefabs[Random.Range(0, m_BrickPrefabs.Count)]);

            return brick;
        }
        private void StopCreating(bool obj)
        {
            if (m_CreatingCoroutine != null)
            {
                StopCoroutine(m_CreatingCoroutine);

                m_CreatingCoroutine = null;
            }
        }
    }
}
