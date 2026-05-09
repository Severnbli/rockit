using _Project.Scripts.Runtime.Features.Physics.Moving.Shared.Enums;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Components
{
    public struct CharacterMoveComponent
    {
        public MoveDirection Direction;
        public float WalkDeceleration;
        public float JumpDeceleration;
        public float MaxFallingVelocity;
    }
}