using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
 
using Ardalis.GuardClauses;

namespace Crm.SharedKernel.Domain.BaseEntities
{
    public abstract record Enumeration
    {
        public int Value { get; }
        public string Name { get; }

        public override string ToString() => Name;

        public override int GetHashCode() => Value.GetHashCode() ^ 31;

        protected Enumeration() => (Value, Name) = (0, string.Empty);

        protected Enumeration(int value, string name)
        {
            Guard.Against.NegativeOrZero(value);
            Guard.Against.NullOrEmpty(name);
            Guard.Against.NullOrWhiteSpace(name);

            (Value, Name) = (value, name);
        }

        public static IEnumerable<T> GetAll<T>()
            where T : Enumeration =>
            typeof(T)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Select(f => f.GetValue(null))
                .Cast<T>();

        public static Result<T> FromValue<T>(int value)
            where T : Enumeration
        {
            var item = GetAll<T>().FirstOrDefault(e => e.Value == value);
            return item is null
                ? Result.Failure<T>(Errors.InvalidEnumValueError<T>(value))
                : Result.Success(item);
        }

        public static Result<T> FromName<T>(string name)
            where T : Enumeration
        {
            var item = GetAll<T>().FirstOrDefault(e => e.Name.Equals(name));
            return item is null
                ? Result.Failure<T>(Errors.InvalidEnumNameError<T>(name))
                : Result.Success(item);
        }
    }
}
