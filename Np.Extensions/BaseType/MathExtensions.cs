namespace Np.Extensions.BaseType;

/// <summary>
/// Класс расширение для математических ф-ий
/// </summary>
public static class MathExtensions
{
    /// <summary>
    /// Computes the sum of the sequence of Single values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <returns>The sum of the projected values.</returns>
    /// <exception cref="ArgumentNullException">source or selector is null.</exception>
    public static ulong Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, ulong> selector)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        if (selector == null)
            throw new ArgumentNullException(nameof(selector));
        
        checked
        {
            return source.Aggregate<TSource, ulong>(0, (current, item) => current + selector(item));
        }
    }
    
    /// <summary>
    /// Computes the sum of a sequence of UInt64 values.
    /// </summary>
    /// <param name="source">A sequence of UInt64 values to calculate the sum of.</param>
    /// <returns>The sum of the values in the sequence.</returns>
    public static ulong Sum(this IEnumerable<ulong> source)
    {
        ulong sum = 0;
        checked
        {
            sum = source.Aggregate(sum, (current, v) => current + v);
        }

        return sum;
    }
}
