using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Checkpoints.Configs
{
    public sealed class CheckpointsAnimationsConfig : ScriptableObjectAutoInstaller<CheckpointsAnimationsConfig>
    {
        [SerializeField] private string _activatedBool = "Activated";
        
        public int ActivatedBool => Animator.StringToHash(_activatedBool);
    }
}