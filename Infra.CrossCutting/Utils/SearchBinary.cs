namespace Infra.CrossCutting.Utils;

public static class SearchBinary
{
    #region Public Methods

    public static (T? Element, int Steps) BinarySearchFromArray<T, TKey>(IReadOnlyList<T> sortedList, Func<T, TKey[]> getKey, TKey[] key) where TKey : IComparable<TKey>
    {
        int left = 0;
        int right = sortedList.Count - 1;
        var count = 0;
        while (left <= right)
        {
            count++;
            int mid = left + (right - left) / 2;
            var midValue = getKey(sortedList[mid]);
            int comparison = CompareKeys(midValue, key);

            if (comparison == 0)
            {
                return (sortedList[mid], count); // Elemento encontrado
            }
            else if (comparison < 0)
            {
                left = mid + 1; // Procurar na metade direita
            }
            else
            {
                right = mid - 1; // Procurar na metade esquerda
            }
        }

        return (default(T), count); // Elemento não encontrado
        
    }

    public static (T? Element, int Steps) BinarySearch<T>(IReadOnlyList<T> lista, T key) where T : IComparable<T>
    {
        return BinarySearchFromArray(lista, x => new T[] { x }, new T[] { key });
    }

    #endregion

    #region Private Methods

    private static int CompareKeys<T>(T[] keys1, T[] keys2) where T : IComparable<T>
    {
        for (int i = 0; i < Math.Min(keys1.Length, keys2.Length); i++)
        {
            int comparison = keys1[i].CompareTo(keys2[i]);
            if (comparison != 0)
            {
                return comparison;
            }
        }

        return keys1.Length.CompareTo(keys2.Length);
    }
    #endregion

}