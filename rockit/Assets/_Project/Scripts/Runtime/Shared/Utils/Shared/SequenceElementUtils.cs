using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Runtime.Shared.Tools;

namespace _Project.Scripts.Runtime.Shared.Utils.Shared
{
    public static class SequenceElementUtils
    {
        public static bool TryCreateSequence<T>(IReadOnlyList<T> data, out SequenceElement<T> first, bool looped = false)
        {
            first = null;
            if (!data.Any()) return false;

            first = new SequenceElement<T>(data[0]);
            var prev = first;
            
            for (var i = 1; i < data.Count; i++)
            {
                var curr = new SequenceElement<T>(data[i]);
                prev.Next = curr;
                curr.Prev = prev;
                prev = curr;
            }

            if (!looped) return true;
            
            prev.Next = first;
            first.Prev = prev;

            return true;
        }
        
        public static bool TryCreateMappedSequence<TSource, TElement>(
            IReadOnlyList<TSource> data,
            Func<TSource, int, TElement> mapper,
            out SequenceElement<TElement> first)
        {
            var elementsData = new List<TElement>(); 
            
            for (var i = 0; i < data.Count; i++)
            {
                elementsData.Add(mapper(data[i], i));
            }

            return TryCreateSequence(elementsData, out first);
        }
        
        public static bool TryCreateMappedSequenceWithNull<TSource, TElement>(
            IReadOnlyList<TSource> data,
            Func<TSource, int, TElement> elementFactory,
            Func<TElement> nullElementFactory,
            out SequenceElement<TElement> first, 
            bool nullOnEmpty = false)
        {
            if (!TryCreateMappedSequence(data, elementFactory, out first) && !nullOnEmpty) return false;

            var nullElement = new SequenceElement<TElement>
            {
                Value = nullElementFactory(),
                Next = first
            };

            first = nullElement;

            return true;
        }
    }
}