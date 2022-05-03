namespace POne.Core.Extensions
{
    public static class StringExtensions
    {
        public static string HashPassword(this string value) => BCrypt.Net.BCrypt.HashPassword(value);
    }
}
