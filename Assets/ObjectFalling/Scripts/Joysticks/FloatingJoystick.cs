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

        protected override void Start()
        {
            base.Start();
            background.gameObject.SetActive(false);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            helded = true;

            background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
            background.gameObject.SetActive(true);
            base.OnPointerDown(eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            helded = false;
            //controller.Blast();


            background.gameObject.SetActive(false);
            base.OnPointerUp(eventData);
        }
    }
}