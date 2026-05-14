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
    }
}