using _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Components;
using _Project.Scripts.Runtime.Shared.Extensions.Shared;
using _Project.Scripts.Runtime.Shared.Monos;
using _Project.Scripts.Runtime.Shared.Tools;
using _Project.Scripts.Runtime.Shared.Utils.Features.Physics.Moving;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Monos
{
    [DebugOnlyBehaviour]
    public class GroundCheckDebug : DebugBehaviour
    {
        private void OnDrawGizmos()
        {
            if (!gameObject.TryGetAuthored(out GroundCheckComponent component)) return;
            
            DrawGizmoWithMainColor(() =>
            {
                Gizmos.DrawWireCube(
                    CharactersMovingUtils.GetGroundCheckPosition(gameObject.transform.position, component.Position),
                    component.Size);
            });
        }
    }
}