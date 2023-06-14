using DiaGna.UserInterface;
using DiaGna.UserInterface.Controller;
using UnityEngine;
using UnityEngine.UI;

namespace DiaGna.ObjectFalling.UserInterface.Element
{
    [RequireComponent(typeof(Button))]
    public class BackButton : UIElement
    {
        private Button m_Button;

        public override void OnLoadElement()
        {
            m_Button = GetComponent<Button>();
        }

        public override void OnEnableElement()
        {
            m_Button.onClick.AddListener(Returning);
        }

        public override void OnDisableElement()
        {
            m_Button.onClick.RemoveListener(Returning);
        }

        private void Returning()
        {
            UserInterfaceUtility.OnBackPressed();
        }
    }
}
