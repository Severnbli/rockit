using System;
using _Project.Scripts.Runtime.Shared.Utils.Shared;

namespace _Project.Scripts.Runtime.Shared.Tools
{
    public class SequenceElementObserver<TElement>
    {
        public SequenceElement<TElement> Element;

        public void GoToNext()
        {
            if (Element?.Next == null) return;
            Element = Element.Next;
        }

        public void GoToPrev()
        {
            if (Element?.Prev == null) return;
            Element = Element.Prev;
        }

        public void GoTo(Func<TElement, bool> predicate)
        {
            if (!SequenceElementUtils.TryFind(Element, predicate, out var element)) return;
            Element = element;
        }
    }
}