using DiaGna.ObjectFalling.CraneManaging;
using DiaGna.ObjectFalling.Gameplay;
using DiaGna.ObjectFalling.GroundUtility;
using DiaGna.ObjectFalling.LevelUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiaGna.ObjectFalling.BrickUtility
{
    public class BrickCreator : MonoBehaviour
    {
        [SerializeField, Min(0)] private float m_Delay = 1;
        private bool m_CanCreate;

        private List<Brick> m_BrickPrefabs = new List<Brick>();

        private Coroutine m_CreatingCoroutine;

        public void AddPrefab(Brick prefab)
        {
            if (m_BrickPrefabs.Contains(prefab)) return;
            m_BrickPrefabs.Add(prefab);
        }

        private void OnEnable()
        {
            GlobalEvent.OnStartGame += StartCreating;
            GlobalEvent.OnFinishGame += StopCreating;
            Ground.Instance.OnRotated += CheckCrating;
        }


        private void OnDisable()
        {
            GlobalEvent.OnStartGame -= StartCreating;
            GlobalEvent.OnFinishGame -= StopCreating;
            if (Ground.IsAlive)
            {
                Ground.Instance.OnRotated -= CheckCrating;
            }
        }

        private void StartCreating()
        {
            m_CanCreate = true;
            Creating();
        }

        private void StopCreating(bool isWin)
        {
            m_CanCreate = false;

            if (m_CreatingCoroutine != null)
            {
                StopCoroutine(m_CreatingCoroutine);
                m_CreatingCoroutine = null;
            }
        }

        private void CheckCrating(Brick brick)
        {
            Creating();
        }

        private void Creating()
        {
            if (!m_CanCreate) return;
            m_CanCreate = true;
            m_CreatingCoroutine = StartCoroutine(WaitToCreate());
        }

        private IEnumerator WaitToCreate()
        {
            yield return new WaitForSeconds(m_Delay);

            Brick brick = GetBrick();
            Crane.Instance.Component.Hook.AssignObject(brick);
        }

        private Brick GetBrick()
        {
            Brick brick;
            if (m_BrickPrefabs.Count == 0)
            {
                var prefab = GetFromResource();
                brick = Instantiate(prefab);
            }
            else
            {
                brick = Instantiate(m_BrickPrefabs[Random.Range(0, m_BrickPrefabs.Count)]);
            }

            if (brick == null)
            {
                Debug.LogError("No brick avaialbe!");
            }

            brick.Active();
            return brick;
        }

        private Brick GetFromResource()
        {
            if (LevelLoader.Instance.IsLevelActive)
            {
                return LevelLoader.Instance.ActiveLevel.GetRandomBricks();
            }
            return null;
        }
    }
}
