using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Runtime.Features.Platforms.Shared.Enums;
using _Project.Scripts.Runtime.Shared.Extensions;
using _Project.Scripts.Runtime.Shared.Monos;
using _Project.Scripts.Runtime.Shared.Tools;
using _Project.Scripts.Runtime.Shared.Utils;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Platforms.Shared.Monos
{
    [DebugOnlyBehaviour]
    public class PlatformStatesDebug : DebugBehaviour
    {
        [SerializeField] private bool _active;

        private void OnDrawGizmos()
        {
            if (!gameObject.TryGet(out Platform platform)) return;

            var pStates = platform.PositionStates;
            if (!pStates.Any()) return;
            
            var rStates = platform.RotationStates;
            if (!rStates.Any()) return;

            var sStates = platform.ScaleStates;
            if (!sStates.Any()) return;
            
            var types = new HashSet<PlatformType>(platform.Types);
            if (!types.Any()) return;

            var posCount = types.Contains(PlatformType.Position) ? pStates.Count : 1;
            var rotCount = types.Contains(PlatformType.Rotation) ? rStates.Count : 1;
            var scaleCount = types.Contains(PlatformType.Scale) ? sStates.Count : 1;
            
            for (var i = 0; i < posCount; i++)
            {
                var pos = pStates[i].position;

                for (var j = 0; j < rotCount; j++)
                {
                    var rot = rStates[j].rotation;

                    for (var k = 0; k < scaleCount; k++)
                    {
                        var scale = sStates[k].localScale;

                        DrawState(platform, pos, rot, scale);
                    }
                }
            }
        }
        
        private void DrawState(Platform platform, Vector3 pos, Quaternion rot, Vector3 scale)
        {
            if (!platform.gameObject.TryGet(out Collider2D coll)) return;
            
            DebugUtils.SetMatrix(pos, rot, scale);
            DebugUtils.DrawCollider(coll, MainGizmoColor);
            DebugUtils.ResetMatrix();
        }
    }
}