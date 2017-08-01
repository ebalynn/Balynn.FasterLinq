  
  
  
  
using System.Collections.Generic;
using FasterLinq;
// ReSharper disable ForCanBeConvertedToForeach
// ReSharper disable SuggestVarOrType_BuiltInTypes
// ReSharper disable InvertIf
// ReSharper disable PossibleNullReferenceException
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace System.Linq
{
    public static class IListExtensions
    {
        #region Aggregate
        public static TSource Aggregate<TSource>(this IList<TSource> items, Func<TSource, TSource, TSource> func)
        {
            if (object.ReferenceEquals(func, null))
            {
                throw Error.ArgumentNull(nameof(func));
            }

            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            
            var result = default(TSource);
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                result = func(result, element);
            }
            return result;
        }
        #endregion Aggregate

        #region Any
        public static bool Any<TSource>(this IList<TSource> items)
        {
            return items.Count > 0;
        }

        public static bool Any<TSource>(this IList<TSource> items, Func<TSource, bool> predicate)
        {
            if (object.ReferenceEquals(predicate, null))
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (predicate(element))
                {
                    return true;
                }                    
            }
            return false;
        }

        public static bool All<TSource>(this IList<TSource> items, Func<TSource, bool> predicate)
        {
            if (object.ReferenceEquals(predicate, null))
            {
                throw Error.ArgumentNull(nameof(predicate));    
            }
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (predicate(element) == false)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Average
        public static double Average(this IList<int> items)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }

            long sum = 0;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                sum += element;
            }

            return (double) sum / items.Count;
        }

        public static double? Average(this IList<int?> items)
        {
            if (items.Count != 0)
            {
                long sum = 0;
                int count = 0;

                checked
                {
                    for (var i = 0; i < items.Count; i++)
                    {
                        var element = items[i];
                        if (element.HasValue)
                        {
                            count++;
                            sum += element.Value;
                        }
                    }
                }

                return (double) sum / count;
            }
            else
            {
                return null;
            }
        }

        public static double Average(this IList<long> items)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }

            long sum = 0;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                sum += element;
            }

            return (double) sum / items.Count;
        }

        public static double? Average(this IList<long?> items)
        {
            if (items.Count != 0)
            {
                long sum = 0;
                int count = 0;

                checked
                {
                    for (var i = 0; i < items.Count; i++)
                    {
                        var element = items[i];
                        if (element.HasValue)
                        {
                            count++;
                            sum = element.Value;
                        }
                    }
                }
                return (double) sum / count;
            }
            else
            {
                return null;
            }
        }

        public static float Average(this IList<float> items)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }

            double sum = 0;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                sum += element;
            }

            return (float) (sum / items.Count);
        }

        public static float? Average(this IList<float?> items)
        {
            if (items.Count != 0)
            {
                double sum = 0;
                int count = 0;
                checked
                {
                    for (var i = 0; i < items.Count; i++)
                    {
                        var element = items[i];
                        if (element.HasValue)
                        {
                            count++;
                            sum += element.Value;
                        }
                    }
                    return (float)(sum / count);
                }
            }
            else
            {
                return null;
            }
        }

        public static double Average(this IList<double> items)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            double sum = 0;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                sum += element;
            }

            return sum / items.Count;
        }

        public static double? Average(this IList<double?> items)
        {
            if (items.Count != 0)
            {
                checked
                {
                    double sum = 0;
                    int count = 0;
                    for (var i = 0; i < items.Count; i++)
                    {
                        var element = items[i];
                        if (element.HasValue)
                        {
                            sum += element.Value;
                            count++;
                        }
                    }
                    return sum / count;
                }
            }
            else
            {
                return null;
            }
        }

        public static decimal Average(this IList<decimal> items)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            decimal sum = 0;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                sum += element;
            }

            return sum / items.Count;
        }

        public static decimal? Average(this IList<decimal?> items)
        {
            if (items.Count != 0)
            {
                decimal sum = 0;
                int count = 0;
                for (var i = 0; i < items.Count; i++)
                {
                    var element = items[i];
                    if (element.HasValue)
                    {
                        sum += element.Value;
                        count++;
                    }
                }
                return sum / count;
            }
            else
            {
                return null;
            }
        }

        public static double Average<TSource>(this IList<TSource> items, Func<TSource, int> selector)
        {
            if (object.ReferenceEquals(selector, null))
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            if (items.Count == 0)
            {
                throw Error.NoElements();
            }

            long sum = 0;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                sum += selector(element);
            }

            return (double)sum / items.Count;
        }

        public static double? Average<TSource>(this IList<TSource> items, Func<TSource, int?> selector)
        {
            if (object.ReferenceEquals(selector, null))
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            if (items.Count != 0)
            {
                long sum = 0;
                int count = 0;

                checked
                {
                    for (var i = 0; i < items.Count; i++)
                    {
                        var element = items[i];
                        var converted = selector(element);
                        if (converted.HasValue)
                        {
                            count++;
                            sum += converted.Value;
                        }
                    }
                }

                return (double)sum / count;
            }
            else
            {
                return null;
            }
        }

        public static double Average<TSource>(this IList<TSource> items, Func<TSource, long> selector)
        {
            if (object.ReferenceEquals(selector, null))
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            if (items.Count == 0)
            {
                throw Error.NoElements();
            }

            long sum = 0;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                sum += selector(element);
            }

            return (double)sum / items.Count;
        }

        public static double? Average<TSource>(this IList<TSource> items, Func<TSource, long?> selector)
        {
            if (object.ReferenceEquals(selector, null))
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            if (items.Count != 0)
            {
                long sum = 0;
                int count = 0;

                checked
                {
                    for (var i = 0; i < items.Count; i++)
                    {
                        var element = selector(items[i]);
                        if (element.HasValue)
                        {
                            count++;
                            sum = element.Value;
                        }
                    }
                }
                return (double)sum / count;
            }
            else
            {
                return null;
            }
        }

        public static float Average<TSource>(this IList<TSource> items, Func<TSource, float> selector)
        {
            if (object.ReferenceEquals(selector, null))
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            if (items.Count == 0)
            {
                throw Error.NoElements();
            }

            double sum = 0;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                sum += selector(element);
            }

            return (float)(sum / items.Count);
        }

        public static float? Average<TSource>(this IList<TSource> items, Func<TSource, float?> selector)
        {
            if (object.ReferenceEquals(selector, null))
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            if (items.Count != 0)
            {
                double sum = 0;
                int count = 0;
                checked
                {
                    for (var i = 0; i < items.Count; i++)
                    {
                        var element = selector(items[i]);
                        if (element.HasValue)
                        {
                            count++;
                            sum += element.Value;
                        }
                    }
                    return (float)(sum / count);
                }
            }
            else
            {
                return null;
            }
        }

        public static double Average<TSource>(this IList<TSource> items, Func<TSource, double> selector)
        {
            if (object.ReferenceEquals(selector, null))
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            if (items.Count == 0)
            {
                throw Error.NoElements();
            }

            double sum = 0;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                sum += selector(element);
            }

            return sum / items.Count;
        }

        public static double? Average<TSource>(this IList<TSource> items, Func<TSource, double?> selector)
        {
            if (object.ReferenceEquals(selector, null))
            {
                throw Error.ArgumentNull(nameof(selector));
            }
            
            if (items.Count != 0)
            {
                checked
                {
                    double sum = 0;
                    int count = 0;
                    for (var i = 0; i < items.Count; i++)
                    {
                        var element = items[i];
                        var converted = selector(element);
                        if (converted.HasValue)
                        {
                            sum += converted.Value;
                            count++;
                        }
                    }
                    return sum / count;
                }
            }
            else
            {
                return null;
            }
        }

        public static decimal Average<TSource>(this IList<TSource> items, Func<TSource, decimal> selector)
        {
            if (object.ReferenceEquals(selector, null))
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            if (items.Count == 0)
            {
                throw Error.NoElements();
            }

            decimal sum = 0;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                sum += selector(element);
            }

            return sum / items.Count;
        }

        public static decimal? Average<TSource>(this IList<TSource> items, Func<TSource, decimal?> selector)
        {
            if (object.ReferenceEquals(selector, null))
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            if (items.Count != 0)
            {
                decimal sum = 0;
                int count = 0;
                for (var i = 0; i < items.Count; i++)
                {
                    var element = items[i];
                    var converted = selector(element);
                    if (converted.HasValue)
                    {
                        sum += converted.Value;
                        count++;
                    }
                }
                return sum / count;
            }
            else
            {
                return null;
            }
        }

        #endregion Average

        #region Contains
        public static bool Contains<TSource>(this IList<TSource> items, TSource value, IEqualityComparer<TSource> equalityComparer)
        {
            if (object.ReferenceEquals(equalityComparer, null))
            {
                throw Error.ArgumentNull(nameof(items));
            }

            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (equalityComparer.Equals(element, value))
                {
                    return true;
                }    
            }
            return false;
        }

        public static bool Contains<TSource>(this IList<TSource> items, TSource value)
        {
            var equalityComparer = EqualityComparer<TSource>.Default;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (equalityComparer.Equals(element, value))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion Contains

        #region Count
        public static int Count<TSource>(this IList<TSource> items)
        {
            if (object.ReferenceEquals(items, null))
            {
                throw Error.ArgumentNull(nameof(items));
            }
            return items.Count;
        }

        public static long LongCount<TSource>(this IList<TSource> items)
        {
            if (object.ReferenceEquals(items, null))
            {
                throw Error.ArgumentNull(nameof(items));
            }
            return items.Count;
        }

        public static int Count<TSource>(this IList<TSource> items, Func<TSource, bool> predicate)
        {
            if (object.ReferenceEquals(predicate, null))
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            int count = 0;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                checked
                {
                    if (predicate(element))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        public static long LongCount<TSource>(this IList<TSource> items, Func<TSource, bool> predicate)
        {
            if (object.ReferenceEquals(predicate, null))
            {
                throw Error.ArgumentNull(nameof(predicate));
            }
            int count = 0;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                checked
                {
                    if (predicate(element))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        #endregion Count

        #region Distinct

        public static IEnumerable<TSource> Distinct<TSource>(this IList<TSource> items)
        {
            var set = new HashSet<TSource>();
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (set.Add(element) == false)
                {
                    yield return element;
                }
            }
        }

        public static IEnumerable<TSource> Distinct<TSource>(this IList<TSource> items, IEqualityComparer<TSource> equalityComparer)
        {
            if (object.ReferenceEquals(equalityComparer, null))
            {
                throw Error.ArgumentNull(nameof(equalityComparer));
            }

            var set = new HashSet<TSource>(equalityComparer);
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (set.Add(element) == false)
                {
                    yield return element;
                }
            }
        }
        #endregion Distinct

        #region ElementAt
        public static TSource ElementAt<TSource>(this IList<TSource> items, int index)
        {
            return items[index];
        }

        public static TSource ElementAtOrDefault<TSource>(this IList<TSource> items, int index)
        {
            if (index < items.Count)
            {
                return items[index];
            }

            return default(TSource);
        }
        #endregion ElementAt

        #region First

        public static TSource First<TSource>(this IList<TSource> items)
        {
            if (items.Count != 0)
            {
                return items[0];
            }

            throw Error.NoElements();
        }

        public static TSource First<TSource>(this IList<TSource> items, Func<TSource, bool> predicate)
        {
            if (object.ReferenceEquals(predicate, null))
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (predicate(element))
                {
                    return element;
                }
            }

            throw Error.NoMatch();
        }

        public static TSource FirstOrDefault<TSource>(this IList<TSource> items)
        {
            if (items.Count != 0)
            {
                return items[0];
            }
            return default(TSource);
        }

        public static TSource FirstOrDefault<TSource>(this IList<TSource> items, Func<TSource, bool> predicate)
        {
            if (object.ReferenceEquals(predicate, null))
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (predicate(element))
                {
                    return element;
                }
            }
            return default(TSource);
        }
        #endregion First
        #region Last

        public static TSource Last<TSource>(this IList<TSource> items)
        {
            if (items.Count != 0)
            {
                return items[items.Count - 1];
            }

            throw Error.NoElements();
        }
        public static TSource Last<TSource>(this IList<TSource> items, Func<TSource, bool> predicate)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }

            TSource result = default(TSource);
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (predicate(element))
                {
                    result = element;
                }
            }
            return result;
        }
        public static TSource LastOrDefault<TSource>(this IList<TSource> items)
        {
            if (items.Count != 0)
            {
                return items[items.Count - 1];
            }

            return default(TSource);
        }

        public static TSource LastOrDefault<TSource>(this IList<TSource> items, Func<TSource, bool> predicate)
        {
            TSource result = default(TSource);
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (predicate(element))
                {
                    result = element;
                }
            }
            return result;
        }
        #endregion Last

        #region Max

        public static int Max(this IList<int> items)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            int result = int.MinValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (element > result)
                {
                    result = element;
                }
            }
            return result;
        }
        public static int? Max(this IList<int?> items)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            int? result = default(int?);
            int value = int.MinValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (element.HasValue && element.Value > value)
                {
                    result = element;
                    value = element.Value;
                }
            }
            return result;
        }

        public static long Max(this IList<long> items)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            long result = long.MinValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (element > result)
                {
                    result = element;
                }
            }
            return result;
        }

        public static long? Max(this IList<long?> items)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            long? result = default(long?);
            long value = long.MinValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (element.HasValue && element.Value > value)
                {
                    result = element;
                    value = element.Value;
                }
            }
            return result;
        }

        public static double Max(this IList<double> items)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            double result = double.MinValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (element > result)
                {
                    result = element;
                }
            }
            return result;
        }

        public static double? Max(this IList<double?> items)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            double? result = default(double?);
            double value = double.MinValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (element.HasValue && element.Value > value)
                {
                    result = element;
                    value = element.Value;
                }
            }
            return result;
        }

        public static float Max(this IList<float> items)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            float result = float.MinValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (element > result)
                {
                    result = element;
                }
            }
            return result;
        }

        public static float? Max(this IList<float?> items)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            float? result = default(float?);
            float value = float.MinValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (element.HasValue && element.Value > value)
                {
                    result = element;
                    value = element.Value;
                }
            }
            return result;
        }

        public static decimal Max(this IList<decimal> items)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            decimal result = decimal.MinValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (element > result)
                {
                    result = element;
                }
            }
            return result;
        }

        public static decimal? Max(this IList<decimal?> items)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            decimal? result = default(decimal?);
            decimal value = decimal.MinValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (element.HasValue && element.Value > value)
                {
                    result = element;
                    value = element.Value;
                }
            }
            return result;
        }

        public static TSource Max<TSource>(this IList<TSource> items)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            var result = default(TSource);
            var comparer = Comparer<TSource>.Default;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (comparer.Compare(element, result) > 0)
                {
                    result = element;
                }
            }
            return result;
        }

        public static int Max<TSource>(this IList<TSource> items, Func<TSource, int> selector)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            int result = int.MinValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                var converted = selector(element);
                if (converted > result)
                {
                    result = converted;
                }
            }
            return result;
        }

        public static int? Max<TSource>(this IList<TSource> items, Func<TSource, int?> selector)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            int? result = default(int?);
            int value = int.MinValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                var converted = selector(element);
                if (converted.HasValue && converted.Value > value)
                {
                    result = converted;
                    value = converted.Value;
                }
            }
            return result;
        }

        public static long Max<TSource>(this IList<TSource> items, Func<TSource, long> selector)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            long result = long.MinValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = selector(items[i]);
                if (element > result)
                {
                    result = element;
                }
            }
            return result;
        }

        public static long? Max<TSource>(this IList<TSource> items, Func<TSource, long?> selector)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            long? result = default(long?);
            long value = long.MinValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                var converted = selector(element);
                if (converted.HasValue && converted.Value > value)
                {
                    result = converted;
                    value = converted.Value;
                }
            }
            return result;
        }

        public static float Max<TSource>(this IList<TSource> items, Func<TSource, float> selector)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            float result = float.MinValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                var converted = selector(element);
                if (converted > result)
                {
                    result = converted;
                }
            }
            return result;
        }

        public static float? Max<TSource>(this IList<TSource> items, Func<TSource, float?> selector)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            float? result = default(float?);
            float value = float.MinValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                var converted = selector(element);
                if (converted.HasValue && converted.Value > value)
                {
                    result = converted;
                    value = converted.Value;
                }
            }
            return result;
        }

        public static double Max<TSource>(this IList<TSource> items, Func<TSource, double> selector)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }

            double result = double.MinValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                var converted = selector(element);
                if (converted > result)
                {
                    result = converted;
                }
            }
            return result;
        }

        public static double? Max<TSource>(this IList<TSource> items, Func<TSource, double?> selector)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            double? result = default(double?);
            double value = double.MinValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                var converted = selector(element);
                if (converted.HasValue && converted.Value > value)
                {
                    result = converted;
                    value = converted.Value;
                }
            }
            return result;
        }

        public static decimal Max<TSource>(this IList<TSource> items, Func<TSource, decimal> selector)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            decimal result = decimal.MinValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                var converted = selector(element);
                if (converted > result)
                {
                    result = converted;
                }
            }
            return result;
        }

        public static decimal? Max<TSource>(this IList<TSource> items, Func<TSource, decimal?> selector)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }

            decimal? result = default(decimal?);
            decimal value = decimal.MinValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = selector(items[i]);
                if (element.HasValue && element.Value > value)
                {
                    result = element;
                    value = element.Value;
                }
            }
            return result;
        }

        public static TResult Max<TSource, TResult>(this IList<TSource> items, Func<TSource, TResult> selector)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            TResult result = default(TResult);
            var comparer = Comparer<TResult>.Default;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                var converted = selector(element);
                if (comparer.Compare(converted, result) > 0)
                {
                    result = converted;
                }
            }
            return result;
        }
        #endregion Max

        #region Min
        public static int Min(this IList<int> items)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            int result = int.MaxValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (element < result)
                {
                    result = element;
                }
            }
            return result;
        }
        public static int? Min(this IList<int?> items)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            int? result = default(int?);
            int value = int.MaxValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (element.HasValue && element.Value < value)
                {
                    result = element;
                    value = element.Value;
                }
            }
            return result;
        }

        public static long Min(this IList<long> items)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            long result = long.MaxValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (element < result)
                {
                    result = element;
                }
            }
            return result;
        }

        public static long? Min(this IList<long?> items)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            long? result = default(long?);
            long value = long.MaxValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (element.HasValue && element.Value < value)
                {
                    result = element;
                    value = element.Value;
                }
            }
            return result;
        }

        public static double Min(this IList<double> items)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            double result = double.MaxValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (element < result)
                {
                    result = element;
                }
            }
            return result;
        }

        public static double? Min(this IList<double?> items)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            double? result = default(double?);
            double value = double.MaxValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (element.HasValue && element.Value < value)
                {
                    result = element;
                    value = element.Value;
                }
            }
            return result;
        }

        public static float Min(this IList<float> items)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            float result = float.MaxValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (element < result)
                {
                    result = element;
                }
            }
            return result;
        }

        public static float? Min(this IList<float?> items)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            float? result = default(float?);
            float value = float.MinValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (element.HasValue && element.Value < value)
                {
                    result = element;
                    value = element.Value;
                }
            }
            return result;
        }

        public static decimal Min(this IList<decimal> items)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            decimal result = decimal.MaxValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (element < result)
                {
                    result = element;
                }
            }
            return result;
        }

        public static decimal? Min(this IList<decimal?> items)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            decimal? result = default(decimal?);
            decimal value = decimal.MaxValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (element.HasValue && element.Value < value)
                {
                    result = element;
                    value = element.Value;
                }
            }
            return result;
        }

        public static TSource Min<TSource>(this IList<TSource> items)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            TSource result = default(TSource);
            var comparer = Comparer<TSource>.Default;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                if (comparer.Compare(element, result) < 0)
                {
                    result = element;
                }
            }
            return result;
        }

        public static int Min<TSource>(this IList<TSource> items, Func<TSource, int> selector)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            int result = int.MaxValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = selector(items[i]);
                if (element < result)
                {
                    result = element;
                }
            }
            return result;
        }

        public static int? Min<TSource>(this IList<TSource> items, Func<TSource, int?> selector)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            int? result = default(int?);
            int value = int.MaxValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                var converted = selector(element);
                if (converted.HasValue && converted.Value < value)
                {
                    result = converted;
                    value = converted.Value;
                }
            }
            return result;
        }

        public static long Min<TSource>(this IList<TSource> items, Func<TSource, long> selector)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            long result = long.MaxValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                var converted = selector(element);
                if (converted < result)
                {
                    result = converted;
                }
            }
            return result;
        }

        public static long? Min<TSource>(this IList<TSource> items, Func<TSource, long?> selector)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            long? result = default(long?);
            long value = long.MaxValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                var converted = selector(element);
                if (converted.HasValue && converted.Value < value)
                {
                    result = converted;
                    value = converted.Value;
                }
            }
            return result;
        }

        public static float Min<TSource>(this IList<TSource> items, Func<TSource, float> selector)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            float result = float.MaxValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                var converted = selector(element);
                if (converted < result)
                {
                    result = converted;
                }
            }
            return result;
        }

        public static float? Min<TSource>(this IList<TSource> items, Func<TSource, float?> selector)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            float? result = default(float?);
            float value = float.MaxValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                var converted = selector(element);
                if (converted.HasValue && converted.Value < value)
                {
                    result = converted;
                    value = converted.Value;
                }
            }
            return result;
        }

        public static double Min<TSource>(this IList<TSource> items, Func<TSource, double> selector)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            double result = double.MaxValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = selector(items[i]);
                if (element < result)
                {
                    result = element;
                }
            }
            return result;
        }

        public static double? Min<TSource>(this IList<TSource> items, Func<TSource, double?> selector)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            double? result = default(double?);
            double value = double.MaxValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                var converted = selector(element);
                if (converted.HasValue && converted.Value < value)
                {
                    result = converted;
                    value = converted.Value;
                }
            }
            return result;
        }

        public static decimal Min<TSource>(this IList<TSource> items, Func<TSource, decimal> selector)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            decimal result = decimal.MaxValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                var converted = selector(element);
                if (converted < result)
                {
                    result = converted;
                }
            }
            return result;
        }

        public static decimal? Min<TSource>(this IList<TSource> items, Func<TSource, decimal?> selector)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            decimal? result = default(decimal?);
            decimal value = decimal.MaxValue;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                var converted = selector(element);
                if (converted.HasValue && converted.Value < value)
                {
                    result = converted;
                    value = converted.Value;
                }
            }
            return result;
        }

        public static TResult Min<TSource, TResult>(this IList<TSource> items, Func<TSource, TResult> selector)
        {
            if (items.Count == 0)
            {
                throw Error.NoElements();
            }
            TResult result = default(TResult);
            var comparer = Comparer<TResult>.Default;
            for (var i = 0; i < items.Count; i++)
            {
                var element = items[i];
                var converted = selector(element);
                if (comparer.Compare(converted, result) < 0)
                {
                    result = converted;
                }
            }
            return result;
        }
        #endregion Min

    }
}
    