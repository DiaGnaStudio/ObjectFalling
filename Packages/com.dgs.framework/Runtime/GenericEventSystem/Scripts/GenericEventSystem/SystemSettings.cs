
using UnityEngine;

namespace DiaGna.Framework.GenericEventSystem
{
    public static class SystemSettings
    {
        /// <summary>
        /// If true all CustomEvents catch and debug the exceptions occure while invoking events.
        /// </summary>
        public static bool m_CatchExceptions = true;
        private static int m_InitialEventSize = 2;

        public static int InitialEventSize
        {
            get => m_InitialEventSize;
            set
            {
                m_InitialEventSize = Mathf.Clamp(value, 1, int.MaxValue);
            }
        }
    }
}
