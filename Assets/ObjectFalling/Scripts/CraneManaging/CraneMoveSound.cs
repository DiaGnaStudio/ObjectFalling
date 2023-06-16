using DiaGna.ObjectFalling.UserInterface.Tools;
using UnityEngine;

namespace DiaGna.ObjectFalling.CraneManaging
{
    [RequireComponent(typeof(AudioSource))]
    public class CraneMoveSound : MonoBehaviour
    {
        private AudioSource m_Source;

        private SoundState m_CurrentState = SoundState.Stop;

        private void Awake()
        {
            m_Source = GetComponent<AudioSource>();
            m_Source.loop = true;
        }

        private void OnEnable()
        {
            MoverEvent.OnDrag += PlaySound;
            MoverJoystick.OnDrag += PlaySound;
        }

        private void OnDisable()
        {
            MoverEvent.OnDrag -= PlaySound;
            MoverJoystick.OnDrag -= PlaySound;
        }

        private enum SoundState
        {
            Play,
            Stop
        }

        Vector3 lastPosition;

        private void Start()
        {
            lastPosition = transform.position;
        }

        private void Update()
        {
            PlaySound(transform.position != lastPosition);

            lastPosition = transform.position;
        }

        private void PlaySound(Vector2 vector)
        {
            if (vector.magnitude > 0 && m_CurrentState == SoundState.Stop)
            {
                m_CurrentState = SoundState.Play;
                m_Source.Play();
                Debug.Log("PLAY");
            }
            else if(vector.magnitude <= 0 && m_CurrentState == SoundState.Play)
            {
                m_CurrentState = SoundState.Stop;
                m_Source.Stop();
                Debug.Log("STOP");
            }
        }

        private void PlaySound(bool play)
        {
            if (play && m_CurrentState == SoundState.Stop)
            {
                m_CurrentState = SoundState.Play;
                m_Source.Play();
                Debug.Log("PLAY");
            }
            else if (!play && m_CurrentState == SoundState.Play)
            {
                m_CurrentState = SoundState.Stop;
                m_Source.Stop();
                Debug.Log("STOP");
            }
        }
    }
}
