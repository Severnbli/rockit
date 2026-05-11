using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared.Monos
{
    public class AnimatableOpenableClosable : OpenableClosable
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _openTrigger = "Open";
        [SerializeField] private string _closeTrigger = "Close";
        
        private int OpenTrigger => Animator.StringToHash(_openTrigger);
        private int CloseTrigger => Animator.StringToHash(_closeTrigger);

        public override void Open()
        {
            base.Open();
            _animator.SetTrigger(OpenTrigger);
        }

        public override void Close()
        {
            base.Close();
            _animator.SetTrigger(CloseTrigger);
        }
    }
}