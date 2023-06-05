using System.Reflection;
using UnityEngine;
using System;

namespace DiaGna.Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class EditorModifiableAttribute : PropertyAttribute
    {
        public int FieldID { get ; set; }
        public string FieldName { get; set; }

        /// <summary>
        /// Returns tha property name of the first matched field which has the EditorModifiableAttribute attribute with the provided FieldName.
        /// </summary>
        /// <typeparam name="T">The class which contains the field</typeparam>
        /// <param name="attributeFieldName">The name that has been set for EditorModifiableAttribute.FieldName</param>
        public static string GetPropertyName<T>(string attributeFieldName)
        {
            foreach(FieldInfo field in typeof(T).GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
            {
                EditorModifiableAttribute attribute = field.GetCustomAttribute<EditorModifiableAttribute>();
                if(attribute != null && attribute.FieldName.Equals(attributeFieldName))
                {
                    return field.Name;
                }
            }

            return null;
        }

        /// <summary>
        /// Returns tha property name of the first matched field which has the EditorModifiableAttribute attribute with the provided FieldID.
        /// </summary>
        /// <typeparam name="T">The class which contains the field</typeparam>
        /// <param name="attributeFieldID">The ID that has been set for EditorModifiableAttribute.FieldID</param>
        public static string GetPropertyName<T>(int attributeFieldID)
        {
            foreach (FieldInfo field in typeof(T).GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
            {
                EditorModifiableAttribute attribute = field.GetCustomAttribute<EditorModifiableAttribute>();
                if (attribute != null && attribute.FieldID.Equals(attributeFieldID))
                {
                    return field.Name;
                }
            }

            return null;
        }
    }
}