
using System;
using System.Linq;
using System.Reflection;

namespace Maynor
{
    public static class EnumExtensions
    {

        /// <summary>
        /// Determines if the Enum is exactly equal to the tested Value
        /// </summary>
        /// <typeparam name="T">Type of Enum.</typeparam>
        /// <param name="instance">This enum</param>
        /// <param name="value">Enum value to test</param>
        /// <returns></returns>
        public static bool EqualsFlag<T>(this T instance, T value) where T: Enum
        {
            Guard.Against.Null(value);

            try
            {
                return (int)(object)instance == (int)(object)value;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Determines if the Enum has a Flag value set
        /// </summary>
        /// <typeparam name="T">Type of Enum.</typeparam>
        /// <param name="instance">This enum</param>
        /// <param name="value">Enum value to test</param>
        /// <returns></returns>
        public static bool HasFlag<T>(this T instance, T value) where T : Enum
        {
            Guard.Against.Null(value);

            try
            {
                int iInstance = (int)(object)instance;
                int iFlag = (int)(object)value;
                return (iInstance & iFlag) == iFlag;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Adds a flag to an enumeration.
        /// </summary>
        /// <typeparam name="T">Type of Enum</typeparam>
        /// <param name="instance">Enum to add to</param>
        /// <param name="value">Value to add</param>
        /// <returns></returns>
        public static T AddFlag<T>(this T instance, T value) where T : Enum
        {
            Guard.Against.Null(value);

            try
            {
                int iInstance = (int)(object)instance;
                int iFlag = (int)(object)value;
                T tRslt = (T)(object)(iInstance | iFlag);

                return tRslt;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    string.Format(
                        "Could not append value from enumerated type '{0}'.",
                        typeof(T).Name
                        ), ex);
            }
        }

        /// <summary>
        /// Removes a value from an enumeration
        /// </summary>
        /// <typeparam name="T">Type of Enum</typeparam>
        /// <param name="instance">Enum to add to</param>
        /// <param name="value">Value to remove</param>
        /// <returns></returns>
        public static T RemoveFlag<T>(this T instance, T value) where T : Enum
        {
            try
            {
                int iInstance = (int)(object)instance;
                int iFlag = (int)(object)value;
                int iResult = iInstance & ~iFlag;
                T tRslt = (T)(object)iResult;

                return tRslt;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(string.Format("Could not remove value from enumerated type '{0}'.", typeof(T).Name), ex);
            }
        }


        /// <summary>
        /// Returns the string name of the enum value. For the enum <see cref="ConsoleColor"/>
        /// the value of '0' will be returned as 'Black'.
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static string GetName(this Enum instance)
        {
            Guard.Against.Null(instance);

            return Enum.GetName(instance.GetType(), instance);
        }

        /// <summary>
        /// Returns the value of an enum's <see cref="System.ComponentModel.DescriptionAttribute"/> if the attribute exists. 
        /// If not it returns the Name.
        /// </summary>
        public static string GetDescription(this Enum enumValue)
        {
            Guard.Against.Null(enumValue);

            Type genericEnumType = enumValue.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(enumValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if (_Attribs != null && _Attribs.Count() > 0)
                {
                    return ((System.ComponentModel.DescriptionAttribute)_Attribs.ElementAt(0)).Description;
                }
            }
            return enumValue.ToString();
        }
    }
}
