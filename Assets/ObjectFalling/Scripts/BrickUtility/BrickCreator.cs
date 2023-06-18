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
            GlobalEvent.OnFinishGame += StopCreating;
            Ground.Instance.OnFinishRotating += Creating;
        }


        private void OnDisable()
        {
            GlobalEvent.OnFinishGame -= StopCreating;
            if (Ground.IsAlive)
            {
                Ground.Instance.OnFinishRotating -= Creating;
            }
        }

        private void Start()
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

        private void Creating()
        {
            if (!BrickCountAnnouncer.CanCreate())
            {
                GlobalEvent.FinishGame(false);
            }

            if (!m_CanCreate) return;
            m_CanCreate = true;

            m_CreatingCoroutine = StartCoroutine(WaitToCreate());
        }

        private IEnumerator WaitToCreate()
        {
            yield return new WaitForSeconds(m_Delay);

            IBrick brick = GetBrick();
            BrickCountAnnouncer.AddBrick(brick);
            Crane.Instance.Component.Hook.AssignObject(brick);
        }

        private IBrick GetBrick()
        {
            GameObject brick = null;
            if (m_BrickPrefabs.Count == 0)
            {
                var prefab = GetFromResource();
                if (prefab != null)
                {
                    brick = Instantiate(prefab.BrickObject);
                    brick.transform.rotation = Quaternion.Euler(0, 45, 0);
                }
            }
            else
            {
                brick = Instantiate(m_BrickPrefabs[Random.Range(0, m_BrickPrefabs.Count)].BrickObject);
                brick.transform.rotation = Quaternion.Euler(0, 45, 0);
            }

            if (brick != null)
            {
                var brickComponent = brick.GetComponent<IBrick>();
                return brickComponent;
            }
            else
            {
                Debug.LogError("No brick avaialbe!");
                return null;
            }
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
