using DiaGna.ObjectFalling.UserInterface.Tools;
using System.Collections;
using UnityEngine;

namespace DiaGna.ObjectFalling.CraneManaging
{
    /// <summary>
    /// A compoennt to resets the current position of object to its start position in spesific duration.
    /// </summary>
    public class ResetPosition : MonoBehaviour
    {
        private Vector3 m_StartPosition;
        [SerializeField, Min(0)] private float m_Duration;

        private void Start()
        {
            m_StartPosition = transform.localPosition;
        }

        private void OnEnable()
        {
            MoverEvent.OnPointerUp += Reseting;
            MoverJoystick.OnPointerUpEvent += Reseting;
        }

        private void OnDisable()
        {
            MoverEvent.OnPointerUp -= Reseting;
            MoverJoystick.OnPointerUpEvent -= Reseting;
        }

        private void Reseting()
        {
            StartCoroutine(MoveFromTo(transform.localPosition, m_StartPosition, m_Duration));
        }

        IEnumerator MoveFromTo(Vector3 a, Vector3 b, float duration)
        {
            var Distance = Vector3.Distance(a, b);

            if (Distance <= 0)
            {
                yield break;
            }

            float speed = Distance / duration;

            float step = (speed / (a - b).magnitude) * Time.fixedDeltaTime;
            float t = 0;
            while (t <= 1.0f)
            {
                t += step; // Goes from 0 to 1, incrementing by step each time
                transform.position = Vector3.Lerp(a, b, t); // Move objectToMove closer to b
                yield return new WaitForFixedUpdate();         // Leave the routine and return here in the next frame
            }
            transform.position = b;
        }
    }
}
