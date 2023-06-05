using System;

namespace DiaGna.Framework.GenericEventSystem
{
    public interface IInternalActionReference
    {
        Delegate InternalAction { get; }
    }
}
