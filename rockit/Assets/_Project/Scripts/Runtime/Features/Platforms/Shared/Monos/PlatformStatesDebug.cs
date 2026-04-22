using System.Linq;
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
        [SerializeField] private Platform _platform;
        [SerializeField] private Collider2D _collider;

        private void OnDrawGizmos()
        {
            if (!_active || _platform is null || _collider is null) return;
            
            var pStates = _platform.PositionStates;
            if (!pStates.Any()) return;
            
            var rStates = _platform.RotationStates;
            if (!rStates.Any()) return;

            var sStates = _platform.ScaleStates;
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
                        
                        DrawState(_platform, pos, rot, scale);
                    }
                }
            }
        }
        
        private void DrawState(Platform platform, Vector3 pos, Quaternion rot, Vector3 scale)
        {
            DebugUtils.SetMatrix(pos, rot, scale);
            DebugUtils.DrawCollider(_collider, MainGizmoColor);
            DebugUtils.ResetMatrix();
        }
    }
}