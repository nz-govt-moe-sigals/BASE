﻿namespace App.Core.Infrastructure.Services
{
    using System;
    using App.Core.Shared.Services;

    /// <summary>
    /// Contract for an Infrastructure Service to 
    ///     to convert types to alternate types.
    ///     <para>
    ///         Refer to implementations of
    ///         <see cref="IHostSettingsService" />
    /// that use it to convert settings for persistence
    /// in datastores, and back again. It's used in other 
    /// places too (front end conversion).
    ///     </para>
    /// </summary>
    public interface IConversionService : IHasAppCoreService
    {
        /// <summary>
        ///     Convert one type to another, falling back to the
        ///     provided default Type if the value is null.
        /// </summary>
        /// <typeparam name="T">The target Type</typeparam>
        /// <param name="source">The source object</param>
        /// <param name="defaultValue">The default target value</param>
        /// <returns></returns>
        T ConvertTo<T>(object source, T defaultValue = default(T));

        /// <summary>
        ///     Get the default value of the provided Type.
        ///     If the Type is a Value object it will be its default value,
        ///     If it is an object, it will be null.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        object GetDefaultValue(Type type);
    }
}