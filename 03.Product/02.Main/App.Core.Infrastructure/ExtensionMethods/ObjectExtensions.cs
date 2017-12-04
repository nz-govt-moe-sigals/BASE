// Extensions are always put in root namespace
// for maximum usability from elsewhere:

namespace App
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public static class ObjectExtensions
    {
        public static bool IsDefault<T>(this T value)
        {
            return EqualityComparer<T>.Default.Equals(value);
        }

        [DebuggerHidden]
        public static bool IsDefaultOrNotInitialized(this object argument)
        {
            bool isNullOrEmpty;

            if (argument == null)
            {
                return true;
            }


            var t = argument.GetType();

            if (!t.IsValueType)
            {
                //String:
                isNullOrEmpty = argument is string && ((string) argument).Length == 0;
            }
            else
            {
                var defaultValue = Activator.CreateInstance(t);
                isNullOrEmpty = defaultValue.Equals(argument);
            }

            return isNullOrEmpty;
        }


        public static TTarget ConvertTo<TTarget>(this object source, TTarget defaultValue = default(TTarget))
        {
            if (source == null)
            {
                return defaultValue;
            }
            return (TTarget) source.ConvertTo(typeof(TTarget));
        }


        /// <summary>
        ///     Convert a type to another type.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <returns></returns>
        public static object ConvertTo(this object source, Type targetType)
        {
            if (source.IsDefault())
            {
                //The pre-generics equivalent of default(T):
                //Remark: strings are not ValueType, so are returned as null.
                //Remark: guid are ValueType, so are returned as Guid.Empty.
                //Remark: int are ValueType, so are returned as Int32.Empty.
                return targetType.IsValueType
                    ? Activator.CreateInstance(targetType)
                    : null;
            }

            //Value is not null, so safe to get type:
            var srcType = source.GetType();

            if (srcType == typeof(string))
            {
                if (targetType == typeof(string))
                {
                    //Don'type change the normal behavior then...
                    //AND 
                    //Might as well get out early...
                    return source;
                }
                // ReSharper disable ConvertIfStatementToConditionalTernaryExpression
                if (string.IsNullOrEmpty((string) source))
                    // ReSharper restore ConvertIfStatementToConditionalTernaryExpression
                {
                    //Empty string... Hum...
                    //But being converted to a string, or something else?
                    //But if going to be converted........
                    //Much better results to let it decide from a null, 
                    //rather than choke on an empty string:
                    source = null;
                }
                else
                {
                    //we know its not going to be a string
                    //so trim it:
                    source = ((string) source).Trim();
                }
            }


            try
            {
                return Convert.ChangeType(source, targetType, null);
            }
            // ReSharper disable EmptyGeneralCatchClause
            catch
                // ReSharper restore EmptyGeneralCatchClause
            {
            }

            //Ok  so we failed doing it the simplest way...
            //But is there a constructor that we can use?
            //For example, Version (which is a class) 
            //can take a string arg:
            var constructorInfo =
                targetType.GetConstructor(new[] {srcType});
            if (constructorInfo != null)
            {
                try
                {
                    return constructorInfo.Invoke(new[] {source});
                }
                catch
                {
                }
            }
            return targetType.IsValueType
                ? Activator.CreateInstance(targetType)
                : null;
        }
    }
}