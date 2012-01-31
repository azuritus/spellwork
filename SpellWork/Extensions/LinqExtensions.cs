using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;

namespace SpellWork
{
    public enum CompareType
    {
        [FullName("x != y")]
        NotEqual,
        [FullName("x == y")]
        Equal,

        [FullName("x > y")]
        GreaterThan,
        [FullName("x >= y")]
        GreaterOrEqual,
        [FullName("x < y")]
        LowerThan,
        [FullName("x <= y")]
        LowerOrEqual,

        [FullName("x & y == y")]
        AndStrict,
        [FullName("x & y != 0")]
        And,
        [FullName("x & y == 0")]
        NotAnd,

        [FullName("x Starts With y")]
        StartsWith,
        [FullName("x Ends With y")]
        EndsWith,
        [FullName("x Contains y")]
        Contains,
    }

    public static class LinqExtensions
    {
        /// <summary>
        /// Compares two values object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entry"></param>
        /// <param name="field">Value Type is MemberInfo</param>
        /// <param name="value"></param>
        /// <param name="compareType">comparison type</param>
        /// <returns></returns>
        public static bool CreateFilter<T>(this T entry, MemberInfo field, object value, CompareType compareType)
        {
            Contract.Requires(field != null);
            Contract.Requires(value != null);

            var basicValue = GetValue(entry, field);

            switch (basicValue.GetType().Name)
            {
                case "UInt32":
                    return Compare(basicValue.ToUInt32(), value.ToUInt32(), compareType);
                case "Int32":
                    return Compare(basicValue.ToInt32(), value.ToInt32(), compareType);
                case "Single":
                    return Compare(basicValue.ToFloat(), value.ToFloat(), compareType);
                case "UInt64":
                    return Compare(basicValue.ToUlong(), value.ToUlong(), compareType);
                case "String":
                    return Compare(basicValue.ToString(), value.ToString(), compareType);
                case @"UInt32[]":
                    {
                        var val = value.ToUInt32();
                        return ((uint[]) basicValue).Any(el => Compare(el, val, compareType));
                    }
                case @"Int32[]":
                    {
                        var val = value.ToInt32();
                        return ((int[]) basicValue).Any(el => Compare(el, val, compareType));
                    }
                case @"Single[]":
                    {
                        var val = value.ToFloat();
                        return ((float[]) basicValue).Any(el => Compare(el, val, compareType));
                    }
                case @"UInt64[]":
                    {
                        var val = value.ToUlong();
                        return ((ulong[]) basicValue).Any(el => Compare(el, val, compareType));
                    }
                default:
                    return false;
            }
        }

        #region Specific Compares

        private static bool Compare(string baseValue, string value, CompareType compareType)
        {
            Contract.Requires(baseValue != null);
            Contract.Requires(value != null);

            switch (compareType)
            {
                case CompareType.StartsWith:
                    return baseValue.StartsWith(value);
                case CompareType.EndsWith:
                    return baseValue.EndsWith(value);

                case CompareType.Contains:
                    return baseValue.ContainsText(value);

                case CompareType.NotEqual:
                    return !baseValue.Equals(value, StringComparison.CurrentCultureIgnoreCase);
                case CompareType.Equal:
                default:
                    return baseValue.Equals(value, StringComparison.CurrentCultureIgnoreCase);
            }
        }

        private static bool Compare(float baseValue, float value, CompareType compareType)
        {
            switch (compareType)
            {
                case CompareType.GreaterOrEqual:
                    return baseValue >= value;
                case CompareType.GreaterThan:
                    return baseValue > value;
                case CompareType.LowerOrEqual:
                    return baseValue <= value;
                case CompareType.LowerThan:
                    return baseValue < value;

                case CompareType.NotEqual:
                    return baseValue != value;
                case CompareType.Equal:
                default:
                    return baseValue == value;
            }
        }

        private static bool Compare(UInt64 baseValue, UInt64 value, CompareType compareType)
        {
            switch (compareType)
            {
                case CompareType.GreaterOrEqual:
                    return baseValue >= value;
                case CompareType.GreaterThan:
                    return baseValue > value;
                case CompareType.LowerOrEqual:
                    return baseValue <= value;
                case CompareType.LowerThan:
                    return baseValue < value;

                case CompareType.AndStrict:
                    return (baseValue & value) == value;
                case CompareType.And:
                    return (baseValue & value) != 0;
                case CompareType.NotAnd:
                    return (baseValue & value) == 0;

                case CompareType.NotEqual:
                    return baseValue != value;
                case CompareType.Equal:
                default:
                    return baseValue == value;
            }
        }

        private static bool Compare(Int32 baseValue, Int32 value, CompareType compareType)
        {
            switch (compareType)
            {
                case CompareType.GreaterOrEqual:
                    return baseValue >= value;
                case CompareType.GreaterThan:
                    return baseValue > value;
                case CompareType.LowerOrEqual:
                    return baseValue <= value;
                case CompareType.LowerThan:
                    return baseValue < value;

                case CompareType.AndStrict:
                    return (baseValue & value) == value;
                case CompareType.And:
                    return (baseValue & value) != 0;
                case CompareType.NotAnd:
                    return (baseValue & value) == 0;

                case CompareType.NotEqual:
                    return baseValue != value;
                case CompareType.Equal:
                default:
                    return baseValue == value;
            }
        }

        private static bool Compare(UInt32 baseValue, UInt32 value, CompareType compareType)
        {
            switch (compareType)
            {
                case CompareType.GreaterOrEqual:
                    return baseValue >= value;
                case CompareType.GreaterThan:
                    return baseValue > value;
                case CompareType.LowerOrEqual:
                    return baseValue <= value;
                case CompareType.LowerThan:
                    return baseValue < value;

                case CompareType.AndStrict:
                    return (baseValue & value) == value;
                case CompareType.And:
                    return (baseValue & value) != 0;
                case CompareType.NotAnd:
                    return (baseValue & value) == 0;

                case CompareType.NotEqual:
                    return baseValue != value;
                case CompareType.Equal:
                default:
                    return baseValue == value;
            }
        }

        #endregion

        private static object GetValue<T>(T entry, MemberInfo field)
        {
            Contract.Requires(entry != null);
            Contract.Requires(field != null);

            if (field is FieldInfo)
                return typeof(T).GetField(field.Name).GetValue(entry);
            else if (field is PropertyInfo)
                return typeof(T).GetProperty(field.Name).GetValue(entry, null);
            else
                return null;
        }
    }
}
