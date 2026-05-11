using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared.Monos
{
    public class AnimatableOpenableClosable : OpenableClosable
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _openedBool = "Opened";
        
        private int OpenedBool => Animator.StringToHash(_openedBool);

        public override void Open()
        {
            base.Open();
            _animator.SetBool(OpenedBool, true);
        }

        public override void Close()
        {
            _animator.SetBool(OpenedBool, false);
            base.Close();
        }
    }
}