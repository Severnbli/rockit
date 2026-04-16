using _Project.Scripts.Runtime.Features.Moving.Components;
using _Project.Scripts.Runtime.Shared.Extensions;
using _Project.Scripts.Runtime.Shared.Monos;
using _Project.Scripts.Runtime.Shared.Tools;
using _Project.Scripts.Runtime.Shared.Utils;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Moving.Monos
{
    [DebugOnlyBehaviour]
    public class GroundCheckVisualizer : DebugBehaviour
    {
        private void OnDrawGizmos()
        {
            if (!gameObject.TryGetAuthored(out GroundCheckComponent component)) return;
            
            Gizmos.DrawWireSphere(
                MovingUtils.GetGroundCheckPosition(gameObject.transform.position, component.Position),
                component.Radius);
        }
    }
}