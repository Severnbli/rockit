namespace _Project.Scripts.Runtime.Shared.Tools
{
    public class SequenceElement<T>
    {
        public SequenceElement<T> Next;
        public SequenceElement<T> Prev;
        public T Value;
    }
}