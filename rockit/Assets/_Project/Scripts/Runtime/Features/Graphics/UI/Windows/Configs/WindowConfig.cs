using _Project.Scripts.Runtime.Features.Graphics.Animations.Shared.Types;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Configs
{
    public class WindowConfig : ScriptableObject
    {
        [SerializeField] private FloatTweenSettings _openBodyAnimation;
        [SerializeField] private FloatTweenSettings _closeBodyAnimation;
        
        public FloatTweenSettings OpenBodyAnimation => _openBodyAnimation;
        public FloatTweenSettings CloseBodyAnimation => _closeBodyAnimation;
    }
}