
namespace DiaGna.Framework.GenericEventSystem
{
    public class DestroyeeEventRegisteror : EventRegisteror
    {
        private void Awake()
        {
            RegisterEvents();
        }

        private void OnDestroy()
        {
            UnregisterEvents();
        }
    }
}
