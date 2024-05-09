namespace EnaiumToolKit.Framework.Extensions;

public static class EnumerableExtension
{
    public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> source)
    {
        return source.Select((item, index) => (item, index));
    }
}