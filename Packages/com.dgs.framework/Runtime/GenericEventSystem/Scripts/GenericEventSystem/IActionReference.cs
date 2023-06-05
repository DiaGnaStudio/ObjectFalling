using System;

namespace DiaGna.Framework.GenericEventSystem
{
    public interface IActionReference<TAction> : IEquatable<IActionReference<TAction>>, IInternalActionReference
    {
        TAction Action { get; }
    }
}
