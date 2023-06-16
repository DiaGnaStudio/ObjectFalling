using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

namespace DiaGna.ObjectFalling
{
    [RequireComponent(typeof(Animator))]
    public class HomeItemAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator m_Animator;

        [Header("Movement")]
        [SerializeField] private string m_WalkParameter;
        [SerializeField] private float m_Speed;
        [SerializeField] private float m_y = 2.9f;

        [Header("Idle")]
        [SerializeField] private string[] m_IdleParameters;
        [SerializeField] private float m_MinDuration;
        [SerializeField] private float m_MaxDuration;


        private void Awake()
        {
            m_Animator = GetComponent<Animator>();
        }

        public void SetPosition(Vector3 position)
        {
            transform.localPosition = new Vector3(position.x, m_y, position.z);
        }

        private void WalkAnimation()
        {
            m_Animator.SetTrigger(m_WalkParameter);
        }

        public void IdleAnimation()
        {
            m_Animator.SetTrigger(m_IdleParameters[Random.Range(0, m_IdleParameters.Length)]);
        }

        public void DoIdle(Action<Transform> action)
        {
            StartCoroutine(Delay(action));
        }

        private IEnumerator Delay(Action<Transform> action)
        {
            IdleAnimation();
            yield return new WaitForSeconds(Random.Range(m_MinDuration, m_MaxDuration));
            action?.Invoke(transform);
        }

        public TweenerCore<Vector3, Vector3, VectorOptions> DOMove(Vector3 moveTarget)
        {
            var duration = GetDuration(transform.localPosition, moveTarget);
            return transform.DOLocalMove(new Vector3(moveTarget.x, m_y, moveTarget.z), duration).OnStart(() =>
            {
                WalkAnimation();
            });
        }

        public void DOLookAt(Vector3 target)
        {
            transform.DOLookAt(target, 0.5f);
        }

        private float GetDuration(Vector3 current, Vector3 destination)
        {
            var Distance = Vector3.Distance(current, destination);
            return Distance / m_Speed;
        }
    }
}
