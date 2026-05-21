using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Teleporters.Configs
{
    public sealed class TeleportersAnimationsConfig : ScriptableObjectAutoInstaller<TeleportersAnimationsConfig>
    {
        [SerializeField] private string _activateTrigger = "Activate";
        
        public int ActivateTrigger => Animator.StringToHash(_activateTrigger);
    }
}