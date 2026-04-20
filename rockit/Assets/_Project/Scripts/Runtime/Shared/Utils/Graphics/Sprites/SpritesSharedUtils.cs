using _Project.Scripts.Runtime.Features.Graphics.Sprites.Shared.Enums;
using _Project.Scripts.Runtime.Features.Physics.Moving.Shared.Enums;

namespace _Project.Scripts.Runtime.Shared.Utils.Graphics.Sprites
{
    public static class SpritesSharedUtils
    {
        public static bool FacingDirectionMatchedWithMoveDirection(FacingDirection facingDirection,
            MoveDirection moveDirection)
        {
            return (facingDirection, moveDirection) switch
            {
                (FacingDirection.Left, MoveDirection.Left) or (FacingDirection.Right, MoveDirection.Right) => true,
                _ => false
            };
        }
    }
}