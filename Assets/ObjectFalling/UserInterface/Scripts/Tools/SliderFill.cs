using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DiaGna.ObjectFalling.UserInterface
{
    [RequireComponent(typeof(Slider))]
    public class SliderFill : MonoBehaviour
    {

        public float fillSpeed = 1.0f;

        private Slider slider;
        private RectTransform fillRect;
        private float targetValue = 0f;
        private float curValue = 0f;

        void Awake()
        {
            slider = GetComponent<Slider>();

            fillRect = slider.fillRect;
            targetValue = curValue = slider.value;
        }

        private void OnEnable()
        {
            //Adds a listener to the main slider and invokes a method when the value changes.
            slider.onValueChanged.AddListener(delegate { ValueChange(); });
        }

        private void OnDisable()
        {
            slider.onValueChanged.RemoveListener(delegate { ValueChange(); });
        }

        // Invoked when the value of the slider changes.
        public void ValueChange()
        {
            targetValue = slider.value;
        }

        // Update is called once per frame
        void Update()
        {
            curValue = Mathf.MoveTowards(curValue, targetValue, Time.deltaTime * fillSpeed);

            Vector2 fillAnchor = fillRect.anchorMax;
            fillAnchor.x = Mathf.Clamp01(curValue / slider.maxValue);
            fillRect.anchorMax = fillAnchor;
        }
    }
}
