using System.Linq;

namespace Common
{
    public static class CommonExtensions
    {
        public static bool IsUpperCase(this string @this)
        {
            return @this != null && @this.All(t => !char.IsLetter(t) || char.IsUpper(t));
        }

        public static bool IsNotUpperCase(this string @this)
        {
            return !IsUpperCase(@this);
        }
    }
}