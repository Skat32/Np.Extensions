using System.ComponentModel;

namespace Np.Extensions.BaseType
{
    /// <summary>
    /// Расширение для Enum типов
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Returns Description attribute value
        /// </summary>
        public static string GetDescription(this Enum enumValue)
        {
            var type = enumValue.GetType();
            var field = type.GetField(enumValue.ToString());

            if (field == null)
                return string.Empty;

            var attributes = (DescriptionAttribute[]) field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}