namespace Np.Extensions.Exceptions;

/// <summary>
/// Класс расширения для проверки удачности запроса
/// </summary>
public static class HttpResponseMessageExtensions
{
    /// <summary>
    /// Выкинуть ошибку, если ответ пришел с ошибкой
    /// </summary>
    /// <exception cref="HttpStatusCodeException"></exception>
    public static async Task ThrowIfNotSuccessStatusCode(this HttpResponseMessage message)
    {
        if (!message.IsSuccessStatusCode)
            throw new HttpStatusCodeException(message.StatusCode, await message.Content.ReadAsStringAsync());
    }
}