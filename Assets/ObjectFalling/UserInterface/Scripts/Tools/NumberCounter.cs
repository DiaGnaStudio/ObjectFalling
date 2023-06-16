using System.Collections;
using TMPro;
using UnityEngine;

namespace DiaGna.ObjectFalling.UserInterface
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class NumberCounter : MonoBehaviour//numberCounter
    {
        public TextMeshProUGUI Text;
        public int CountFPS = 30;
        public float Duration = 1;
        private int m_Value;

        private Coroutine m_CountingCoroutine;

        public int Value
        {
            get => m_Value;
            set
            {
                UpdateText(value);
                m_Value = value;
            }
        }

        private void Awake()
        {
            Text = GetComponent<TextMeshProUGUI>();
        }

        private void UpdateText(int newValue)
        {
            if (m_CountingCoroutine != null)
            {
                StopCoroutine(m_CountingCoroutine);
            }

            m_CountingCoroutine = StartCoroutine(CountText(newValue));
        }

        private IEnumerator CountText(int newValue)
        {
            WaitForSeconds wait = new WaitForSeconds(1 / CountFPS);
            int previousValue = m_Value;
            int stepAmount;

            if (newValue - previousValue < 0)
            {
                stepAmount = Mathf.FloorToInt((newValue - previousValue) / (CountFPS * Duration));
            }
            else
            {
                stepAmount = Mathf.CeilToInt((newValue - previousValue) / (CountFPS * Duration));
            }

            if (previousValue < newValue)
            {
                while (previousValue < newValue)
                {
                    previousValue += stepAmount;

                    if (previousValue > newValue)
                    {
                        previousValue = newValue;
                    }

                    Text.SetText(previousValue.ToString("N0"));

                    yield return wait;
                }
            }
            else
            {

                while (previousValue > newValue)
                {
                    previousValue += stepAmount;

                    if (previousValue < newValue)
                    {
                        previousValue = newValue;
                    }

                    Text.SetText(previousValue.ToString("N0"));

                    yield return wait;
                }
            }
        }
    }
}
