using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DiaGna.ObjectFalling.UserInterface.Tools
{
    [RequireComponent(typeof(Slider))]
    public class SliderPercentDisplayer : MonoBehaviour
    {
        private Slider m_Slider;
        [SerializeField] private TMP_Text m_PercentText;
        [SerializeField] private float m_FillSpeed = 1.0f;
        private float m_TargetValue = 0f;
        private float m_CurValue = 0f;
        private float m_MaxValue = 0f;

        private void Awake()
        {
            m_Slider = GetComponent<Slider>();
            m_TargetValue = m_CurValue = m_Slider.value;
            m_MaxValue = m_Slider.maxValue;
        }

        private void OnEnable()
        {
            m_Slider.onValueChanged.AddListener(delegate { ValueChange(); });
        }

        private void OnDisable()
        {
            m_Slider.onValueChanged.RemoveListener(delegate { ValueChange(); });
        }

        public void ValueChange()
        {
            m_TargetValue = m_Slider.value;
        }

        void Update()
        {
            m_CurValue = Mathf.MoveTowards(m_CurValue, m_TargetValue, Time.deltaTime * m_FillSpeed);

            var value = Mathf.Clamp01(m_CurValue / m_Slider.maxValue);
            ValueChange(value);
        }

        private void ValueChange(float value)
        {
            var percent = (value / m_MaxValue) * 100;
            m_PercentText.SetText(string.Format("{0:0.0}%", percent));
        }
    }
}
