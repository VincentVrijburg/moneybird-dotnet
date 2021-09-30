using System;
using System.Collections.Generic;
using System.Linq;

namespace Moneybird.Net
{
    internal static class ArgumentGuard
    {
        /// <summary>
        /// Method to guard the null value of an argument object.
        /// </summary>
        /// <param name="value">The argument object to perform the null check for.</param>
        /// <param name="name">The name of the argument.</param>
        /// <typeparam name="T">Type of the argument object.</typeparam>
        /// <exception cref="ArgumentNullException">Throws an ArgumentNullException if the value is null.</exception>
        public static void NotNull<T>(T value, string name) where T : class
        {
            if (value is null)
            {
                throw new ArgumentNullException(name);
            }
        }

        /// <summary>
        /// Method to guard the null value and empty state of an argument collection.
        /// </summary>
        /// <param name="value">The argument collection to perform the null nor empty check for.</param>
        /// <param name="name">The name of the argument.</param>
        /// <param name="collectionName">The name of the collection.</param>
        /// <typeparam name="T">Type of the argument collection.</typeparam>
        /// <exception cref="ArgumentException">Throws an ArgumentNullException if the value is null or empty.</exception>
        public static void NotNullNorEmpty<T>(IEnumerable<T> value, string name, string collectionName = null)
        {
            NotNull(value, name);

            if (!value.Any())
            {
                throw new ArgumentException($"Must have one or more {collectionName ?? name}.", name);
            }
        }

        /// <summary>
        /// Method to guard the null value and empty state of an argument string.
        /// </summary>
        /// <param name="value">The argument string to perform the null nor empty check for.</param>
        /// <param name="name">The name of the string.</param>
        /// <exception cref="ArgumentException">Throws an ArgumentNullException if the value is null or empty.</exception>
        public static void NotNullNorEmpty(string value, string name)
        {
            NotNull(value, name);

            if (value == string.Empty)
            {
                throw new ArgumentException("String cannot be null or empty.", name);
            }
        }
    }
}