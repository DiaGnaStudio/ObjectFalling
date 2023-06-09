using UnityEngine;
using DiaGna.Framework.GenericEventSystem;

namespace DiaGna.Framework.Singletons
{
    /// <summary>
    /// A Unity component singleton
    /// </summary>
    /// <typeparam name="T">The class that inherits from singleton.</typeparam>
    public abstract class ComponentSingleton<T> : EventableBehaviour where T : ComponentSingleton<T>
    {
        /// <summary>
        /// The private field corresponding to the Instance property.
        /// </summary>
        private static T m_Instance;

        [SerializeField] private bool m_DontDestroyOnLoad = true;
        private bool m_IsInitialized = false;

        /// <summary>
        /// <para>Gets the current instance of the singleton. If no instance is found, one will be attempted to be created.</para>
        /// <para>Note: In any OnDestroy method access the Instance property if only singleton is alive, otherwise it may cause the singleton
        /// be created in decommissioning phase of unity and it won't be cleaned by unity.</para>
        /// </summary>
        /// <value>
        /// The instance of the Manager.
        /// </value>
        public static T Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = FindObjectOfType<T>();
                    if(m_Instance == null)
                    {
                        m_Instance = CreateSingleton();
                    }

                    m_Instance.InitializeSingleton();
                }

                return m_Instance;
            }
        }

        /// <summary>
        /// <para>Checks whether the given singleton is currently instantiated and alive.</para>
        /// <para>Note: In any OnDestroy method access the Instance property if only singleton is alive, otherwise it may cause the singleton
        /// be created in decommissioning phase of unity and it won't be cleaned by unity.</para>
        /// </summary>
        public static bool IsAlive => m_Instance != null;
         
        private static T CreateSingleton()
        {
            T instance = null;
            T[] instances = Resources.LoadAll<T>("Prefabs");
            if (instances != null && instances.Length > 0)
            {
                T prefab = instances[0];
                instance = Instantiate(prefab, prefab.transform.position, prefab.transform.rotation);
                string message = string.Format("The singleton was instantiated by prefab in Prefabs folder.", instance.name);
                Debug.Log(message);
            }

            if (instance == null)
            {
                GameObject instanceGameObject = new GameObject(typeof(T).Name);
                instance = instanceGameObject.AddComponent<T>();
                string warning = string.Format("The singleton was not instantiated by a prefab. It was created from scratch which may" +
                    " not have vairables with desired values.", instance.name);
                Debug.LogWarning(warning);
            }

            return instance;
        }

        private void Awake()
        {
            if (m_Instance == null)
            {
                m_Instance = this as T;
                InitializeSingleton();
            }
            else if (m_Instance != this)
            {
                string warning = string.Format("Singleton of type {0} already exists. This {1} is redundant and will be destroyed", typeof(T).Name, name);
                Debug.LogWarning(warning);
                Destroy(this.gameObject);
            }
        }

        private void InitializeSingleton()
        {
            if (!m_IsInitialized)
            {
                m_IsInitialized = true;
                if (m_DontDestroyOnLoad)
                {
                    transform.SetParent(null, true);
                    DontDestroyOnLoad(gameObject);
                }

                AwakeInitialize();
            }
        }

        protected virtual void AwakeInitialize() { }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            string message = string.Format("Singleton {0} was destroyed", name);
            Debug.Log(message);
            if (m_Instance == this)
            {
                m_Instance = null;
            }
        }
    }
}