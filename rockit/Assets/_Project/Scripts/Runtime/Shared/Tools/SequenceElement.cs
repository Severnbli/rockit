namespace _Project.Scripts.Runtime.Shared.Tools
{
    public class SequenceElement<T>
    {
        public SequenceElement<T> Next;
        public SequenceElement<T> Prev;
        public T Value;
        
        public SequenceElement() {}

        public SequenceElement(T value = default, SequenceElement<T> next = null, SequenceElement<T> prev = null)
        {
            Next = next;
            Prev = prev;
            Value = value;
        }
    }
}