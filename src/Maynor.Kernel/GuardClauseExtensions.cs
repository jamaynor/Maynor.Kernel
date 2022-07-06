
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Maynor
{
    /// <summary>
    /// A collection of common guard clauses, implemented as extensions.
    /// </summary>
    /// <example>
    /// Guard.Against.Null(input, nameof(input));
    /// </example>
    public static class GuardClauseExtensions
    {
        /// <summary>
        /// Throws an <see cref="ArgumentNullException" /> if <paramref name="input" /> is null.
        /// </summary>
        public static T Null<T>(this IGuardClause guardClause, T input, [CallerMemberName] string caller = "unknown")
        {
            if (input is null) throw new ArgumentNullException($"{caller} failed because the argument was null.");

            return input;
        }
        public static T Null<T>(this IGuardClause guardClause, T input, string message, [CallerMemberName] string caller = "unknown")
        {
            if (string.IsNullOrWhiteSpace(message)) message = $"{caller} failed because the argument was null.";

            if (input is null) throw new ArgumentNullException(message);

            return input;
        }



        /// <summary>
        /// Throws an <see cref="ArgumentNullException" /> if <paramref name="input" /> is null.
        /// Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is an empty string.
        /// </summary>
        /// <param name="guardClause"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message">A custom message to include in the exception.</param>
        /// <returns><paramref name="input" /> if the value is not an empty string or null.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static string NullOrEmpty(this IGuardClause guardClause, string input, [CallerMemberName] string caller = "unknown")
        {
            string message = $"{caller} failed because the input was empty.";

            if (input is null) throw new ArgumentNullException(message);
            if (input == string.Empty) throw new ArgumentException(message);

            return input;
        }
        /// <summary>
        /// Throws an <see cref="ArgumentNullException" /> if <paramref name="input" /> is null.
        /// Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is an empty string.
        /// </summary>
        /// <param name="guardClause"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="caller">Automatically populated by [CallerMemberName] attribute.</param>
        /// <returns><paramref name="input" /> if the value is not an empty string or null.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static string NullOrEmpty(this IGuardClause guardClause, string input, string message, [CallerMemberName] string caller = "unknown")
        {
            if (message.IsNullOrEmpty()) message = $"{caller} failed because the input was empty.";

            if (input is null) throw new ArgumentNullException(message);
            if (input == string.Empty) throw new ArgumentException(message);

            return input;
        }
        /// <summary>
        /// Throws an <see cref="ArgumentNullException" /> if <paramref name="input" /> is null.
        /// Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is an empty string.
        /// </summary>
        /// <param name="guardClause"></param>
        /// <param name="enumerable">The <see cref="IEnumerable{T}"/> to be inspected.</param>
        /// <param name="parameterName"></param>
        /// <param name="message">A custom message to include in the exception.</param>
        /// <returns><paramref name="input" /> if the value is not an empty string or null.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        
        public static IEnumerable<T> NullOrEmpty<T>(this IGuardClause guardClause, IEnumerable<T> enumerable, [CallerMemberName] string caller = "unknown")
        {
            string message = $"{ caller} failed because the {enumerable.GetType().Name} was null or empty.";

            if (enumerable is null) throw new ArgumentNullException(message);
            if (enumerable.Count() == 0) throw new ArgumentException(message);

            return enumerable;
        }
        /// <summary>
        /// Throws an <see cref="ArgumentNullException" /> if <paramref name="input" /> is null.
        /// Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is an empty string.
        /// </summary>
        /// <param name="guardClause"></param>
        /// <param name="enumerable">The <see cref="IEnumerable{T}"/> to be inspected.</param>
        /// <param name="parameterName"></param>
        /// <param name="message">A custom message to include in the exception.</param>
        /// <returns><paramref name="input" /> if the value is not an empty string or null.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static IEnumerable<T> NullOrEmpty<T>(this IGuardClause guardClause, IEnumerable<T> enumerable, string message, [CallerMemberName] string caller = "unknown")
        {
            if (message.IsNullOrWhitespace()) message = $"{ caller} failed because the {enumerable.GetType().Name} was null or empty.";

            if (enumerable is null) throw new ArgumentNullException(message);
            if (enumerable.Count() == 0) throw new ArgumentException(message);

            return enumerable;
        }


        /// <summary>
        /// Throws an <see cref="ArgumentNullException" /> if <paramref name="input" /> is null.
        /// Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is an empty or white space string.
        /// </summary>
        /// <param name="guardClause"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>        
        /// <returns><paramref name="input" /> if the value is not an empty or whitespace string.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static string NullOrWhiteSpace(this IGuardClause guardClause, string input, [CallerMemberName] string caller = "unknown")
        {
            string message = $"{caller} failed because the input was null or whitespace";

            if (input is null) throw new ArgumentNullException(message);
            if (input.Trim() == string.Empty) throw new ArgumentException(message);

            return input;
        }
        /// <summary>
        /// Throws an <see cref="ArgumentNullException" /> if <paramref name="input" /> is null.
        /// Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is an empty or white space string.
        /// </summary>
        /// <param name="guardClause"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message"></param>
        /// <returns><paramref name="input" /> if the value is not an empty or whitespace string.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static string NullOrWhiteSpace(this IGuardClause guardClause, string input, string message, [CallerMemberName] string caller = "unknown")
        {
            if (message.IsNullOrWhitespace()) message = $"{caller} failed because the input was null or whitespace";

            if (input is null) throw new ArgumentNullException(message);
            if (input.Trim() == string.Empty) throw new ArgumentException(message);

            return input;
        }



        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException" /> if <paramref name="input"/> is less than <paramref name="min"/> or greater than <paramref name="max"/>.
        /// </summary>
        public static T OutOfRange<T>(this IGuardClause guardClause, T input, T min, T max, string message)
        {
            Comparer<T> comparer = Comparer<T>.Default;

            if (comparer.Compare(input, min) < 0) throw new ArgumentException(message);
            else if (comparer.Compare(input, max) > 0) throw new ArgumentException(message);

            return input;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is zero.
        /// </summary>
        /// <param name="guardClause"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <returns><paramref name="input" /> if the value is not zero.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static T Zero<T>(this IGuardClause guardClause, T input, string message) where T : struct
        {
            if (EqualityComparer<T>.Default.Equals(input, default)) throw new ArgumentException(message);

            return input;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is default for that type.
        /// </summary>
        /// <param name="guardClause"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <returns><paramref name="input" /> if the value is not default for that type.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static T Default<T>(this IGuardClause guardClause, T input, [CallerMemberName] string caller = "")
        {
            string message = $"The value of {typeof(T).Name} cannot be dafault in the method {caller}.";

            if (EqualityComparer<T>.Default.Equals(input, default!) || input is null)
            {
                throw new ArgumentException(message);
            }
            return input;
        }
        public static T Default<T>(this IGuardClause guardClause, T input, string message, [CallerMemberName] string caller = "")
        {
            if (message.IsNullOrWhitespace()) message = $"The value of {typeof(T).Name} cannot be dafault in the method {caller}.";

            if (EqualityComparer<T>.Default.Equals(input, default!) || input is null)
            {
                throw new ArgumentException(message);
            }
            return input;
        }

        /// <summary>Throws an <see cref="ArgumentException" /> if the lambda function passed in returns false.</summary>
        public static void IsFalse(this IGuardClause guardClause, Func<bool> test, string message)
        {
            if (!test.Invoke()) throw new ArgumentException(message);
        }
        /// <summary>Throws an <see cref="ArgumentException" /> if the lambda function passed in returns true.</summary>
        public static void IsTrue(this IGuardClause guardClause, Func<bool> test, string message)
        {
            if (test.Invoke()) throw new ArgumentException(message);
        }

        /// <summary>Throws an <see cref="ArgumentException" /> if the lambda function passed in returns false.</summary>
        public static void MissingKey<TKey, TValue>(this IGuardClause guardClause, IDictionary<TKey, TValue> dictionary, TKey key, [CallerMemberName] string caller = "unknown")
        {
            string keyString = key.ToString() ?? "null";
            string message = $"{caller} failed because the IDictionary did not have an item with the key '{keyString}'.";

            if (!dictionary.ContainsKey(key)) throw new ArgumentException(message);
        }

        public static void MissingKey<TKey, TValue>(this IGuardClause guardClause, IDictionary<TKey, TValue> dictionary, TKey key, string message, [CallerMemberName] string caller = "unknown")
        {
            string keyString = key.ToString() ?? "null";
            if (message.IsNullOrWhitespace()) message = $"{caller} failed because the IDictionary did not have an item with the key '{keyString}'.";

            if (!dictionary.ContainsKey(key)) throw new ArgumentException(message);
        }

    }
}
