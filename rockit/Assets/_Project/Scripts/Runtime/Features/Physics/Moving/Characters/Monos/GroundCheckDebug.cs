using _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Components;
using _Project.Scripts.Runtime.Shared.Extensions;
using _Project.Scripts.Runtime.Shared.Monos;
using _Project.Scripts.Runtime.Shared.Tools;
using _Project.Scripts.Runtime.Shared.Utils;
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
                Gizmos.DrawWireSphere(
                    MovingUtils.GetGroundCheckPosition(gameObject.transform.position, component.Position),
                    component.Radius);
            });
        }
    }
}