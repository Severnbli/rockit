using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Constants.Configs
{
    public sealed class ConstantsDisplaysAnimationsConfig : ScriptableObjectAutoInstaller<ConstantsDisplaysAnimationsConfig>
    {
        [SerializeField] private string _activeBool = "Active";
        [SerializeField] private string _investigatedBool = "Investigated";
        
        public int ActiveBool => Animator.StringToHash(_activeBool);
        public int InvestigatedBool => Animator.StringToHash(_investigatedBool);
    }
}