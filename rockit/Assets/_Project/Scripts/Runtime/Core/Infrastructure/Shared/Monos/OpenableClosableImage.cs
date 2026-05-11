using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared.Monos
{
    public class OpenableClosableImage : OpenableClosableSprite
    {
        [SerializeField] private Image _image;

        public override void Open()
        {
            base.Open();
            _image.sprite = Opened;
        }

        public override void Close()
        {
            _image.sprite = Closed;
            base.Close();
        }
    }
}