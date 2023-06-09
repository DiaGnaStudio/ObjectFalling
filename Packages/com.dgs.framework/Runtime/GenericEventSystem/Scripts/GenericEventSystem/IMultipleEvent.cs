
namespace DiaGna.Framework.GenericEventSystem
{
    public interface IMultipleEvent
    {
        /// <summary>
        /// Add available events to the event list of registeror.
        /// </summary>
        /// <param name="list">The list which events are added to.</param>
        void AddEvents(EventList list);
    }
}