using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022
{
    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> SlidingWindow<T>(this IEnumerable<T> e, int size, int stepSize=1)
        {
            var arr = e.ToArray();
            for(int i = 0; i < arr.Length; i+=stepSize)
            {
                var window = new T[size];
                for(int j = 0; j < size; j++)
                {
                    window[j] = arr[i + j];
                }
                yield return window;
            }
        }
    }
}
