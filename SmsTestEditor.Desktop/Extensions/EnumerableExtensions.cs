using System.Collections.ObjectModel;

namespace SmsTestEditor.Desktop.Extensions
{
    public static class EnumerableExtensions
    {
        public static ObservableCollection<T> ToObservable<T>(this IEnumerable<T> enumerable)
            => new ObservableCollection<T>(enumerable);
    }
}
