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
    public class SceneOpener : MonoBehaviour
    {
        [SerializeField] private string m_SceneName;
        private Button m_Button;

        private void Awake()
        {
            m_Button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            m_Button.onClick.AddListener(OpenScene);
        }

        private void OnDisable()
        {
            m_Button.onClick.RemoveListener(OpenScene);
        }

        private void OpenScene()
        {
            SceneManager.LoadScene(m_SceneName);
        }
    }
}
