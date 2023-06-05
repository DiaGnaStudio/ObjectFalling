
namespace DiaGna.Framework.GenericEventSystem.CallingArguments
{
    internal struct Args<T>
    {
        public T m_Arg;

        public Args(T arg)
        {
            m_Arg = arg;
        }
    }
}
