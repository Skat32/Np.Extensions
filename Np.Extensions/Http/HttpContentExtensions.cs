using Newtonsoft.Json;

namespace Np.Extensions.Http;

/// <summary>
/// Класс расширения для работы с HTTP ответом
/// </summary>
public static class HttpContentExtensions
{
    /// <summary>
    /// Попытаться считать объект ответа в необходимом типе
    /// </summary>
    /// <typeparam name="T">тип ответа</typeparam>
    /// <returns></returns>
    public static async Task<T?> TryReadAsAsync<T>(this HttpContent content)
    {
        var str = await content.ReadAsStringAsync();

        try
        {
            return JsonConvert.DeserializeObject<T>(str);
        }
        catch (JsonSerializationException e)
        {
            return default;
        }
    }
}