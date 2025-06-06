

namespace Crm.SharedKernel.Domain.BaseEntities
{
    internal class Errors
    {
        protected Errors() { }

        public static Error InvalidEnumValueError<T>(int value)
            where T : Enumeration =>
            Error.Validation($"{typeof(T).Name}.Validation", $"Value ({value}) is not valid");

        public static Error InvalidEnumNameError<T>(string name)
            where T : Enumeration =>
            Error.Validation($"{typeof(T).Name}.Validation", $"Name ({name}) is not a valid");
    }
}
