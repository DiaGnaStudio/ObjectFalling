using DiaGna.ObjectFalling.Gameplay;
using System.Collections;
using UnityEngine;

namespace DiaGna.ObjectFalling.GroundUtility
{
    /// <summary>
    /// A compoennt to check the current hight of the brocks and move this object down or up.
    /// </summary>
    public class MoveByHeight : MonoBehaviour
    {
        [SerializeField] private float m_ViewHeight;
        [SerializeField] private float m_moveDownDuration;
        private float m_lastHeight;

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
            if (currentHight >= m_ViewHeight)
            {
                MoveDown(currentHight);
            }

            m_lastHeight = currentHight;
        }

        private void MoveDown(float newHeight)
        {
            StartCoroutine(MoveDownCoroutine(newHeight));
        }

        IEnumerator MoveDownCoroutine(float newHeight)
        {
            float moveAmount = newHeight - m_lastHeight;
            float movePerFrame = moveAmount / (m_moveDownDuration / Time.deltaTime);


            float currentMoveAmount = 0f;
            while (currentMoveAmount < moveAmount)
            {
                transform.Translate(0f, movePerFrame, 0f);
                currentMoveAmount += movePerFrame;
                yield return null;
            }
        }
    }
}
