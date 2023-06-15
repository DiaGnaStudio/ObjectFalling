using DiaGna.ObjectFalling.Gameplay;
using UnityEngine;

namespace DiaGna.ObjectFalling.UserInterface.Tools
{
    [RequireComponent(typeof(Animator))]
    public class CloudHover : MonoBehaviour
    {
        private Animator m_Animator;
        [SerializeField] private string m_ToGamePageParameter;
        [SerializeField] private string m_RetunrHomePageParameter;
        [SerializeField] private string m_FinishParameter;

        private void Awake()
        {
            m_Animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            GlobalEvent.OnStartGame += Open;
            GlobalEvent.OnFinishGame += Stay;
            HomePage.OnPageLoaded += RetunHome;
        }

        private void OnDisable()
        {
            GlobalEvent.OnStartGame -= Open;
            GlobalEvent.OnFinishGame -= Stay;
            HomePage.OnPageLoaded -= RetunHome;
        }

        private void Open()
        {
            m_Animator.SetTrigger(m_ToGamePageParameter);
        }

        private void Stay(bool obj)
        {
            m_Animator.SetTrigger(m_FinishParameter);
        }

        private void RetunHome()
        {
            m_Animator.SetTrigger(m_RetunrHomePageParameter);
        }
    }
}
