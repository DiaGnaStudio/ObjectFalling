using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace DiaGna.ObjectFalling
{
    public class HomeBackgroundAnimationController : MonoBehaviour
    {
        [SerializeField] private Transform m_parent;
        [SerializeField] private Transform m_StartPoint;
        [SerializeField] private Transform m_EndPointPoint;
        [SerializeField] private Transform[] m_Points;

        [Header("Creating")]
        [SerializeField] private HomeItemAnimationController[] m_Prefabs;
        [SerializeField] private float m_Scale = 0.5f;
        [SerializeField] private float m_MinDuration;
        [SerializeField] private float m_MaxDuration;

        [Header("Animation")]
        private HomeItemAnimationController m_CurrentController;

        private Transform[] m_SelectedPoints;
        private int m_Index;
        private Transform m_LastSelectedPoint;

        private void Start()
        {
            CreateMover();
        }

        private void CreateMover()
        {
            PointSelecting();
            m_Index = 0;
            m_LastSelectedPoint = null;

            var index = Random.Range(0, m_Prefabs.Length);
            var prefab = m_Prefabs[index];

            m_CurrentController = Instantiate(prefab, m_parent);
            m_CurrentController.SetPosition(m_StartPoint.localPosition);
            m_CurrentController.transform.localScale = Vector3.one * m_Scale;

            StartMove(m_CurrentController.transform);
        }

        private void PointSelecting()
        {
            var Length = Random.Range(1, m_Points.Length);
            m_SelectedPoints = new Transform[Length];

            for (int i = 0; i < Length; i++)
            {
                var index = Random.Range(0, m_Points.Length);
                m_SelectedPoints[i] = m_Points[index];
            }
        }

        private void StartMove(Transform target)
        {
            if (m_Index >= m_SelectedPoints.Length)
            {
                MoveToEnd(target);
                return;
            }

            Transform moveTarget = m_SelectedPoints[m_Index];


            if (m_LastSelectedPoint == moveTarget)
            {
                m_Index++;
                m_CurrentController.DoIdle(FinishIdle);
                return;
            }

            if (m_Index > 1 && Random.value > 0.7)
            {
                m_CurrentController.DoIdle(FinishIdle);
            }
            else
            {
                m_Index++;
                m_CurrentController.DOLookAt(moveTarget.position);
                m_CurrentController.DOMove(moveTarget.localPosition).OnComplete(() =>
                {
                    StartMove(target);
                });
            }

            m_LastSelectedPoint = moveTarget;
        }

        private void FinishIdle(Transform target)
        {
            StartMove(target);
        }

        private void MoveToEnd(Transform target)
        {
            m_CurrentController.DOLookAt(m_EndPointPoint.position);
            m_CurrentController.DOMove(m_EndPointPoint.localPosition).OnComplete(() =>
            {
                Destroy(target.gameObject);
                StartCoroutine(Delay());
            });
        }

        IEnumerator Delay()
        {
            yield return new WaitForSeconds(Random.Range(m_MinDuration, m_MaxDuration));
            CreateMover();
        }
    }
}
