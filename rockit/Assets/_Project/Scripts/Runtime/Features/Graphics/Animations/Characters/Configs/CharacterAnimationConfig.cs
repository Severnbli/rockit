using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Characters.Configs
{
    public class CharacterAnimationConfig : ScriptableObjectAutoInstaller<CharacterAnimationConfig>
    {
        [SerializeField] private string _deadBool = "Dead";
        [SerializeField] private string _jumpTrigger = "Jump";
        [SerializeField] private string _dashBool = "Dash";
        [SerializeField] private string _fallBool = "Fall";
        [SerializeField] private string _runBool = "Run";

        public int DeadBool => Animator.StringToHash(_deadBool);
        public int JumpTrigger => Animator.StringToHash(_jumpTrigger);
        public int DashBool => Animator.StringToHash(_dashBool);
        public int FallBool => Animator.StringToHash(_fallBool);
        public int RunBool => Animator.StringToHash(_runBool);
    }
}