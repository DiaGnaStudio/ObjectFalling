
namespace DiaGna.Framework.GenericEventSystem.CallingArguments
{
    internal struct Args<T1, T2, T3, T4, T5>
    {
        public T1 m_Arg1;
        public T2 m_Arg2;
        public T3 m_Arg3;
        public T4 m_Arg4;
        public T5 m_Arg5;

        public Args(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            m_Arg1 = arg1;
            m_Arg2 = arg2;
            m_Arg3 = arg3;
            m_Arg4 = arg4;
            m_Arg5 = arg5;
        }
    }
}
