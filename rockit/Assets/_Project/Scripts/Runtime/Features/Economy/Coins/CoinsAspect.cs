using _Project.Scripts.Runtime.Features.Economy.Coins.Components;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Components;
using _Project.Scripts.Runtime.Features.Graphics.UI.Shared.Tags;
using _Project.Scripts.Runtime.Features.Graphics.UI.Text.Shared.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Economy.Coins
{
    public sealed class CoinsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<CoinComponent> CoinComponentPool;
        public readonly ProtoPool<CoinsAmountComponent> CoinsAmountComponentPool;
        public readonly ProtoIt Coins = new (It.Inc<CoinComponent>());
        public readonly ProtoIt CoinsAmountTextUis = new (It.Inc<CoinsAmountComponent, TextUiComponent>());
        public readonly ProtoIt CoinsAmountButtons = new (It.Inc<CoinsAmountComponent, ButtonComponent>());
        public readonly ProtoIt ClickedCoinsAmounts = new (It.Inc<ClickedTag, CoinsAmountComponent>());
    }
}