using System;
using System.Collections.Generic;
using Towel;
using static Towel.Syntax;

namespace CommonLibrary
{
    public class ConsoleHandler
    {
        public static T GetInput<T>(
            TryParse<T> tryParse = null,
            string prompt = null,
            string invalidMessage = null,
            Predicate<T> validation = null)
        {

            if (tryParse is null && (typeof(T) != typeof(string) && !typeof(T).IsEnum && Meta.GetTryParseMethod<T>() is null))
            {
                throw new InvalidOperationException($"Using {nameof(ConsoleHandler)}.{nameof(GetInput)} without providing a {nameof(tryParse)} delegate for a non-supported type {typeof(T).Name}.");
            }

            tryParse ??= typeof(T) == typeof(string)
                ? (string s, out T v) => { v = (T)(object)s; return true; }
            : (TryParse<T>)TryParse;
            validation ??= v => true;


            GetInput:
            Console.Write(prompt ?? $"Input a {typeof(T).Name} value: ");

            if (!tryParse(Console.ReadLine(), out T value) || !validation(value))
            {
                Console.WriteLine(invalidMessage ?? $"Invalid input. Try again...");
                goto GetInput;
            }

            return value;
        }
    }
}
