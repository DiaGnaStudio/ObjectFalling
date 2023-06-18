using DiaGna.UserInterface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DiaGna.ObjectFalling.UserInterface
{
    /// <summary>
    /// An <see cref="UIElement"/> that is a button to open a scene.
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class SceneOpener : UIElement
    {
        [SerializeField] private string m_SceneName;
        private Button m_Button;

        public override void OnLoadElement()
        {
            m_Button = GetComponent<Button>();
        }

        public override void OnEnableElement()
        {
            m_Button.onClick.AddListener(OpenScene);
        }

        public override void OnDisableElement()
        {
            m_Button.onClick.RemoveListener(OpenScene);
        }
        private void OpenScene()
        {
            SceneManager.LoadScene(m_SceneName);
        }

    }
}
