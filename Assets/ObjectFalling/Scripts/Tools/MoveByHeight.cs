using DiaGna.ObjectFalling.Gameplay;
using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace DiaGna.ObjectFalling.GroundUtility
{
    /// <summary>
    /// A compoennt to check the current hight of the brocks and move this object down or up.
    /// </summary>
    public class MoveByHeight : MonoBehaviour
    {
        [SerializeField] private float m_ViewHeight;
        [SerializeField] private float m_Duration;
        private float m_lastHeight;

        private void Start()
        {
            m_lastHeight = m_ViewHeight;
        }

        private void OnEnable()
        {
            HeightController.Instance.OnChangeHeight += Check;
        }

        private void OnDisable()
        {
            if (HeightController.IsAlive)
            {
                HeightController.Instance.OnChangeHeight -= Check;
            }
        }
       
        private void Check(float currentHight)
        {
            if (currentHight > m_lastHeight)
            {
                var diff = (currentHight - m_lastHeight);
                Move(diff);
                m_lastHeight = currentHight;
            }
        }

        private void Move(float newHeight)
        {
            transform.DOMoveY(transform.position.y + newHeight, m_Duration);
        }
    }
}
