using System;

namespace Squazz.Sugar
{
    public static class StringExtensions
    {
        public static StringEqual Equal(this string a, string b)
        {
            return new StringEqual(a, b);
        }

        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static string EmptyIfNull(this string value)
        {
            return value ?? string.Empty;
        }

        public static string NullIfEmpty(this string value)
        {
            return IsNullOrEmpty(value) ? null : value;
        }

        public static string NullIfWhiteSpace(this string value)
        {
            return IsNullOrWhiteSpace(value) ? null : value;
        }

        public static string EmptyIfWhiteSpace(this string value)
        {
            return IsNullOrWhiteSpace(value) ? string.Empty : value;
        }

        public static string Replace(this string str, string oldValue, string newValue, StringComparison comparison)
        {
            newValue = newValue ?? "";
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(oldValue) || oldValue.Equals(newValue, comparison))
                return str;

            int foundAt = 0;
            while ((foundAt = str.IndexOf(oldValue, foundAt, comparison)) != -1)
            {
                str = str.Remove(foundAt, oldValue.Length).Insert(foundAt, newValue);
                foundAt += newValue.Length;
            }
            return str;
        }

        public static Guid? StringToGuid(this string str)
        {
            if (!Guid.TryParse(str, out var guid))
            {
                return (Guid?)null;
            }

            return guid;
        }

        public static Guid StringConvertToGuid(this string str)
        {
            if (!Guid.TryParse(str, out var guid))
            {
                throw new Exception("Error Can not convert string to guid");
            }

            return guid;
        }

        public static bool IsStringGuid(this string str)
        {
            if (!Guid.TryParse(str, out var guid))
            {
                return false;
            }

            return true;
        }
    }

    public struct StringEqual
    {
        private readonly Lazy<bool> _lazyCurrentCultureIgnoreCase;
        private readonly Lazy<bool> _lazyCurrentCulture;
        private readonly Lazy<bool> _lazyInvariantCulture;
        private readonly Lazy<bool> _lazyInvariantCultureIgnoreCase;
        private readonly Lazy<bool> _lazyOrdinal;
        private readonly Lazy<bool> _lazyOrdinalIgnoreCase;
        private readonly Lazy<bool> _lazyEquals;

        internal StringEqual(string a, string b)
        {
            _lazyEquals = new Lazy<bool>(() => string.Equals(a, b));

            _lazyCurrentCulture = new Lazy<bool>(() => string.Equals(a, b, StringComparison.CurrentCulture));
            _lazyCurrentCultureIgnoreCase = new Lazy<bool>(() => string.Equals(a, b, StringComparison.CurrentCultureIgnoreCase));

            _lazyInvariantCulture = new Lazy<bool>(() => string.Equals(a, b, StringComparison.InvariantCulture));
            _lazyInvariantCultureIgnoreCase = new Lazy<bool>(() => string.Equals(a, b, StringComparison.InvariantCultureIgnoreCase));

            _lazyOrdinal = new Lazy<bool>(() => string.Equals(a, b, StringComparison.Ordinal));
            _lazyOrdinalIgnoreCase = new Lazy<bool>(() => string.Equals(a, b, StringComparison.OrdinalIgnoreCase));
        }

        public bool CurrentCulture => _lazyCurrentCulture.Value;
        public bool CurrentCultureIgnoreCase => _lazyCurrentCultureIgnoreCase.Value;
        public bool InvariantCulture => _lazyInvariantCulture.Value;
        public bool InvariantCultureIgnoreCase => _lazyInvariantCultureIgnoreCase.Value;
        public bool Ordinal => _lazyOrdinal.Value;
        public bool OrdinalIgnoreCase => _lazyOrdinalIgnoreCase.Value;

        public static implicit operator bool(StringEqual obj)
        {
            return obj._lazyEquals.Value;
        }
    }
}
