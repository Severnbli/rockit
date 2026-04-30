using _Project.Scripts.Runtime.Features.Graphics.Animations.Shared.Types;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Configs
{
    public class WindowBodyConfig : ScriptableObject
    {
        [SerializeField] private FloatTweenSettings _openAnimation;
        [SerializeField] private FloatTweenSettings _closeAnimation;
        
        public FloatTweenSettings OpenAnimation => _openAnimation;
        public FloatTweenSettings CloseAnimation => _closeAnimation;
    }
}