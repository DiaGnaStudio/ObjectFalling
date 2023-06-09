
namespace DiaGna.Framework.GenericEventSystem.CallingArguments
{
    internal struct Args<T1, T2, T3>
    {
        public T1 m_Arg1;
        public T2 m_Arg2;
        public T3 m_Arg3;

        public Args(T1 arg1, T2 arg2, T3 arg3)
        {
            m_Arg1 = arg1;
            m_Arg2 = arg2;
            m_Arg3 = arg3;
        }
    }
}
