using _Project.Scripts.Runtime.Features.Physics.Moving.Requests;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Components
{
    public struct JumpBufferingComponent
    {
        public JumpRequest Request;
        public float CreationTiming;
    }
}