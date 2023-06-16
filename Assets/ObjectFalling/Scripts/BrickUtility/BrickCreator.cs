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

        private List<IBrick> m_BrickPrefabs = new List<IBrick>();

        private Coroutine m_CreatingCoroutine;

        public void AddPrefab(IBrick prefab)
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

        private void CheckCrating(IBrick brick)
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

            IBrick brick = GetBrick();
            Crane.Instance.Component.Hook.AssignObject(brick);
        }

        private IBrick GetBrick()
        {
            GameObject brick;
            if (m_BrickPrefabs.Count == 0)
            {
                var prefab = GetFromResource();
                brick = Instantiate(prefab.BrickObject);
                brick.transform.rotation = Quaternion.Euler(0, 45, 0);
            }
            else
            {
                brick = Instantiate(m_BrickPrefabs[Random.Range(0, m_BrickPrefabs.Count)].BrickObject);
                brick.transform.rotation = Quaternion.Euler(0, 45, 0);
            }

            if (brick == null)
            {
                Debug.LogError("No brick avaialbe!");
            }

            var brickComponent = brick.GetComponent<IBrick>();
            return brickComponent;
        }

        private IBrick GetFromResource()
        {
            if (LevelLoader.Instance.IsLevelActive)
            {
                return LevelLoader.Instance.ActiveLevel.GetRandomBricks();
            }
            return null;
        }
    }
}
