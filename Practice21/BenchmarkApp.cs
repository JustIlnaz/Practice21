using BenchmarkDotNet.Attributes;
using System;
using System.Linq;

namespace BenchmarkApp
{
    [MemoryDiagnoser]
    public class SearchTest
    {
        private int[] data;
        private int target = -1;

        public SearchTest()
        {
            data = new int[10000];
            for (int i = 0; i < data.Length; i++)
                data[i] = i;
        }

        // 1. Обычный цикл
        [Benchmark]
        public bool ForLoopSearch()
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == target)
                    return true;
            }
            return false;
        }

        // 2. LINQ
        [Benchmark]
        public bool LinqSearch()
        {
            return data.Contains(target);
        }

        // 3. Встроенный метод
        [Benchmark]
        public bool ArraySearch()
        {
            return Array.IndexOf(data, target) >= 0;
        }
    }
}