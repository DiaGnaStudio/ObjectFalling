using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DiaGna.ObjectFalling
{ 
    public class FloatingJoystick : Joystick
    {
        public bool helded;
        public event Action OnPointerDownEvent;
        public event Action OnPointerUpEvent;

        protected override void Start()
        {
            base.Start();
            background.gameObject.SetActive(false);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            helded = true;
            OnPointerDownEvent?.Invoke();

            background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
            background.gameObject.SetActive(true);
            base.OnPointerDown(eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            helded = false;
            //controller.Blast();

            OnPointerUpEvent?.Invoke();

            background.gameObject.SetActive(false);
            base.OnPointerUp(eventData);
        }
    }
}