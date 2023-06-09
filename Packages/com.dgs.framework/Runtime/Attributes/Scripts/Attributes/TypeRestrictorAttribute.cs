using System;
using UnityEngine;

namespace DiaGna.Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class TypeRestrictorAttribute : PropertyAttribute
    {
        private Type m_Type;
        public Type ChosenType => m_Type;

        public TypeRestrictorAttribute(Type type)
        {
            m_Type = type;
        }
    }
}