using _Project.Scripts.Runtime.Features.Graphics.Animations.Shared.Types;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Configs
{
    public class WindowBodyConfig : ScriptableObject
    {
        [SerializeField] private FloatTweenSettings _openSetting;
        [SerializeField] private FloatTweenSettings _closeSettings;
        
        public FloatTweenSettings OpenSetting => _openSetting;
        public FloatTweenSettings CloseSettings => _closeSettings;
    }
}