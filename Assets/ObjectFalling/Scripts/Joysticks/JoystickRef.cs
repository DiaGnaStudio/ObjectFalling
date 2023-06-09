using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiaGna.ObjectFalling
{
    public class JoystickRef : MonoBehaviour
    {
        [SerializeField] private FloatingJoystick m_joystick;
        public FloatingJoystick Joystick => m_joystick;
    }
}
