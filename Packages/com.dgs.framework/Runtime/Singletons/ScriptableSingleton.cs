using UnityEngine;

namespace DiaGna.Framework.Singletons
{
    /// <summary>
    /// Base manager class which is ScriptableObject and singleton.
    /// </summary>
    /// <typeparam name="T">Manager class type</typeparam>
    /// <typeparam name="K">Asset Path Plugin</typeparam>
    public abstract class ScriptableSingleton<T, K> : BaseScriptableSingleton where T : ScriptableSingleton<T, K> where K : AssetPathPlugin, new()
    {
        private static T m_Instance;
        private const string BasePath = "ScriptableObjects";
        private static BehaviourProxy m_Proxy;
        private bool m_IsAlive = true;

        protected static MonoBehaviour Proxy
        {
            get
            {
                if (m_Proxy == null)
                {
                    CreateBehaviourProxy();
                }

                return m_Proxy;
            }
        }

        /// <summary>
        /// Checks whether the given singleton is currently loaded, without creating one if it isn't.
        /// </summary>
        public static bool IsAlive => m_Instance != null && m_Instance.m_IsAlive;

        public static T Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    K pathPlugin = new K();
                    m_Instance = Resources.Load<T>(pathPlugin.Path);

                    //check for missing "ScriptableObjects root folder"
                    if(m_Instance == null)
                    {
                        string supportPath = BasePath + "/" + pathPlugin.Path;
                        m_Instance = Resources.Load<T>(supportPath);
                    }

                    //check for the type inside the Resources folder
                    if (m_Instance == null)
                    {
                        T[] allInstances = Resources.LoadAll<T>(BasePath);
                        if (allInstances != null && allInstances.Length > 0)
                        {
                            m_Instance = allInstances[0];
                        }
                    }

                    if(m_Instance == null)
                    {
                        m_Instance = CreateInstance<T>();
                        string message = string.Format("The scriptable singleton of type {0} was not found in the resources folder. It was " +
                            "created in the runtime which is not persistent.", typeof(T).ToString());
                        Debug.LogWarning(message);
                    }

                    if (m_Instance != null)
                    {
                        if (m_Instance.UseProxy)
                        {
                            CreateBehaviourProxy();
                        }
                        ScriptableSingleton<T, K> instance = m_Instance as ScriptableSingleton<T, K>;
                        instance.Initialize();
                    }
                    else
                    {
                        string message = string.Format("There is no asset file in the specified address {0} for ScriptableObject manager" +
                           " of type {1}. The class won't be loaded.", pathPlugin.Path, typeof(T));
                        Debug.LogError(message);
                    }
                }

                return m_Instance;
            }
        }

        protected override void Initialize() { }
        protected virtual void OnDisabled() { }
        protected virtual void OnDestroyed() { }

        private void OnDisable()
        {
            if (m_Instance == this)
            {
                m_Instance.m_IsAlive = false;
            }

            OnDisabled();
        }

        private void OnDestroy()
        {
            if (m_Instance == this)
            {
                m_Instance.m_IsAlive = false;
            }

            OnDestroyed();
        }

        private static void CreateBehaviourProxy()
        {
            if(m_Proxy == null && m_Instance != null)
            {
                //Create a new game object to use as proxy for all the MonoBehaviour methods
                GameObject proxyObject = new GameObject(m_Instance.name + "_Proxy");
                //Deactivate it before adding the proxy component. This avoids the execution of the Awake method when the the proxy component is added.
                proxyObject.SetActive(false);
                //Add the proxy, set the instance as the parent and move to DontDestroyOnLoad scene
                m_Proxy = proxyObject.AddComponent<BehaviourProxy>();
                m_Proxy.m_Parent = m_Instance;
                //Hide proxy in hierarchy
                proxyObject.hideFlags |= HideFlags.HideInHierarchy;
                //Make proxy persistent between scenes as the scriptable object
                DontDestroyOnLoad(proxyObject);
                //Activate the proxy. This will trigger the MonoBehaviourAwake. 
                m_Proxy.gameObject.SetActive(true);
            }
        }
    }
}