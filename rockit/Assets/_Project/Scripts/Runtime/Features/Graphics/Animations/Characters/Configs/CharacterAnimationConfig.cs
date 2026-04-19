using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Characters.Configs
{
    public class CharacterAnimationConfig : ScriptableObjectAutoInstaller<CharacterAnimationConfig>
    {
        [SerializeField] private string _deathTrigger = "Death";
        [SerializeField] private string _deadBool = "Dead";
        [SerializeField] private string _jumpTrigger = "Jump";
        [SerializeField] private string _dashTrigger = "Dash";
        [SerializeField] private string _dashedBool = "Dash";
        [SerializeField] private string _fallBool = "Fall";
        [SerializeField] private string _runBool = "Run";

        public int DeathTrigger => Animator.StringToHash(_deathTrigger);
        public int DeadBool => Animator.StringToHash(_deadBool);
        public int JumpTrigger => Animator.StringToHash(_jumpTrigger);
        public int DashTrigger => Animator.StringToHash(_dashTrigger);
        public int DashedBool => Animator.StringToHash(_dashedBool);
        public int FallBool => Animator.StringToHash(_fallBool);
        public int RunBool => Animator.StringToHash(_runBool);
    }
}