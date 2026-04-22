using _Project.Scripts.Runtime.Shared.Tools;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Platforms.Shared.Components
{
    public struct PlatformStatesComponent
    {
        public SequenceElement<Vector3> StartPosState;
        public SequenceElement<Vector3> CurrPosState;
        public SequenceElement<Quaternion> StartRotState;
        public SequenceElement<Quaternion> CurrRotState;
        public SequenceElement<Vector3> StartScaleState;
        public SequenceElement<Vector3> CurrScaleState;
    }
}