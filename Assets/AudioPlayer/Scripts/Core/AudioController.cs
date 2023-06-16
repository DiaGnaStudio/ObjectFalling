using System.Collections.Generic;
using UnityEngine;

namespace DiaGna.AudioPlayer.Core
{
    public static class AudioController
    {
        private static Dictionary<AudioType, Data> m_CatchedSources;

        private struct Data
        {
            public Data(List<AudioSource> sources, bool isMute)
            {
                Sources = sources;
                IsMute = isMute;
            }

            public Data(List<AudioSource> sources) : this(sources, false)
            {
            }

            public List<AudioSource> Sources { get; private set; }
            public bool IsMute { get; private set; }

            public void Add(AudioSource source)
            {
                source.mute = IsMute;
                Sources.Add(source);
            }

            public void Remove(AudioSource source)
            {
                Sources.Remove(source);
            }

            public bool Contains(AudioSource source)
            {
                return Sources.Contains(source);
            }

            public void SetMute(bool mute)
            {
                foreach (var source in Sources)
                {
                    source.mute = mute;
                }
            }
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Reset()
        {
            m_CatchedSources = new Dictionary<AudioType, Data>();
        }

        public static void AddSource(AudioSource source, AudioType type)
        {
            m_CatchedSources ??= new Dictionary<AudioType, Data>();

            if (m_CatchedSources.ContainsKey(type))
            {
                m_CatchedSources[type].Add(source);
            }
            else
            {
                m_CatchedSources.Add(type, new Data(new List<AudioSource>() { source }));
            }
        }

        public static void RemoveSource(AudioSource source, AudioType type)
        {
            if (m_CatchedSources == null) return;

            if (m_CatchedSources.ContainsKey(type) && m_CatchedSources[type].Contains(source))
            {
                m_CatchedSources[type].Remove(source);
            }
        }

        public static void SetMute(AudioType type, bool isMute = true)
        {
            if (m_CatchedSources.ContainsKey(type))
            {
                m_CatchedSources[type].SetMute(isMute);
            }
        }

        public static bool GetMute(AudioType type)
        {
            if (m_CatchedSources.ContainsKey(type))
            {
                return m_CatchedSources[type].IsMute;
            }

            return false;
        }
    }
}
