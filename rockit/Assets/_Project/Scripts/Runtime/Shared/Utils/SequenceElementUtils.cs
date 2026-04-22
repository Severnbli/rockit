using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Runtime.Shared.Tools;

namespace _Project.Scripts.Runtime.Shared.Utils
{
    public static class SequenceElementUtils
    {
        public static bool TryCreateLoopedSequence<T>(List<T> data, out SequenceElement<T> first)
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
            
            if (prev == first) return true;
            
            prev.Next = first;
            first.Prev = prev;

            return true;
        }
    }
}