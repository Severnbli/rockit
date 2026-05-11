using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared.Monos
{
    public class OpenableClosableSprite : OpenableClosable
    {
        [SerializeField] private Sprite _opened;
        [SerializeField] private Sprite _closed;
        
        public Sprite Opened => _opened;
        public Sprite Closed => _closed;
    }
}