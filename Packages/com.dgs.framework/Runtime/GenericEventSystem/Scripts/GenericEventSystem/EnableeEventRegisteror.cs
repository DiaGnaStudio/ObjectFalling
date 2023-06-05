
namespace DiaGna.Framework.GenericEventSystem
{
    public class EnableeEventRegisteror : EventRegisteror
    {
        private void OnEnable()
        {
            RegisterEvents();
        }

        private void OnDisable()
        {
            UnregisterEvents();
        }
    }
}
