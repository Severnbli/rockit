using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Monos;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Monos
{
    public class LevelButton : OpenableClosable
    {
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _idText;
        [SerializeField] private GameObject _starsContainer;
        [SerializeField] private GameObject _unlockInfoArea;
        [SerializeField] private TextMeshProUGUI _starsToUnlockText;
        
        public TextMeshProUGUI IdText => _idText;
        public GameObject StarsContainer => _starsContainer;
        public TextMeshProUGUI StarsToUnlockText => _starsToUnlockText;

        public override void Open()
        {
            base.Open();
            _button.interactable = true;
            _idText.gameObject.SetActive(true);
            _starsContainer.gameObject.SetActive(true);
            _unlockInfoArea.gameObject.SetActive(false);
        }

        public override void Close()
        {
            base.Close();
            _button.interactable = false;
            _idText.gameObject.SetActive(false);
            _starsContainer.gameObject.SetActive(false);
            _unlockInfoArea.gameObject.SetActive(true);
        }
    }
}