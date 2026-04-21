using System.Linq;
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

            foreach (var pState in pStates)
            {
                var pos = pState.position;
                
                foreach (var rState in rStates)
                {
                    var rot = rState.rotation;
                    
                    foreach (var sState in sStates)
                    {
                        var scale = sState.localScale;
                        
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