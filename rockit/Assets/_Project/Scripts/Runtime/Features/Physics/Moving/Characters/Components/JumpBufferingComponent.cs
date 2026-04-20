using _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Requests;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Components
{
    public struct JumpBufferingComponent
    {
        public JumpRequest Request;
        public float CreationTiming;
    }
}