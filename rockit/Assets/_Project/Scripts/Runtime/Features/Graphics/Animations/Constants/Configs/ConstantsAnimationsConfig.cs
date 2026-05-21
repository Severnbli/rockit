using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Constants.Configs
{
    public sealed class ConstantsAnimationsConfig : ScriptableObjectAutoInstaller<ConstantsAnimationsConfig>
    {
        [SerializeField] private string _collectTrigger = "Collect";
        
        public int CollectTrigger => Animator.StringToHash(_collectTrigger);
    }
}