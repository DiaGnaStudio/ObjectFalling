using DiaGna.ObjectFalling.Gameplay;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiaGna.ObjectFalling.UserInterface.Tools
{
    [RequireComponent(typeof(Animator))]
    public class CloudHover : MonoBehaviour
    {
        private Animator m_Animator;
        [SerializeField] private string m_ToGamePageParameter;
        [SerializeField] private string m_RetunrHomePageParameter;
        private void Awake()
        {
            m_Animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            GlobalEvent.OnStartGame += Open;
        }

        private void OnDisable()
        {
            GlobalEvent.OnStartGame -= Open;
        }

        private void Open()
        {
            m_Animator.SetTrigger(m_ToGamePageParameter);
        }
    }
}
