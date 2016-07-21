using System;
using System.Collections;
using System.Collections.Generic;

namespace Newtonsoft.Json.Utilities
{
    public class AotHelper
    {
        /// <summary>
        /// Don't run action but let a compiler detect the code in action as an executable block.
        /// </summary>
        public static void Ensure(Action action)
        {
            if (IsFalse())
            {
                try
                {
                    action();
                }
                catch (Exception e)
                {
                    throw new InvalidOperationException("", e);
                }
            }
        }

        /// <summary>
        /// Ensure(() => new T());
        /// </summary>
        public static void EnsureType<T>() where T : new()
        {
            Ensure(() => new T());
        }

        /// <summary>
        /// Ensure generic list type can be (de)deserializable on AOT environment.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list</typeparam>
        public static void EnsureList<T>()
        {
            Ensure(() =>
            {
                var a = new List<T>();
                var b = new HashSet<T>();
                var c = new CollectionWrapper<T>((IList)a);
                var d = new CollectionWrapper<T>((ICollection<T>)a);
            });
        }

        /// <summary>
        /// Ensure generic dictionary type can be (de)deserializable on AOT environment.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        public static void EnsureDictionary<TKey, TValue>()
        {
            Ensure(() =>
            {
                var a = new Dictionary<TKey, TValue>();
                var b = new DictionaryWrapper<TKey, TValue>((IDictionary)null);
                var c = new DictionaryWrapper<TKey, TValue>((IDictionary<TKey, TValue>)null);
            });
        }

        private static bool s_alwaysFalse = DateTime.UtcNow.Year < 0;

        /// <summary>
        /// Always return false but compiler doesn't know it.
        /// </summary>
        /// <returns>False</returns>
        public static bool IsFalse()
        {
            return s_alwaysFalse;
        }
    }
}
