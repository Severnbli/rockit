using System.Text;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Services;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Project.Monos;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;

namespace _Project.Scripts.Runtime.Shared.Extensions.Features.Graphics.UI.Windows
{
    public static class ProjectWindowsExtensions
    {
        public static void UpdateInfo(this ControlsWindow cWindow, LocalizationService lService)
        {
            var sb = new StringBuilder();

            sb.Append(lService.GetString(LocalizationEntriesContracts.Controls.Run.Control));
            sb.Append(LocalizationEntriesContracts.Controls.Separator);
            sb.Append(lService.GetString(LocalizationEntriesContracts.Controls.Run.Info));
            sb.AppendLine();
            
            sb.AppendLine(lService.GetString(LocalizationEntriesContracts.Controls.Jump.Control));
            sb.Append(LocalizationEntriesContracts.Controls.Separator);
            sb.Append(lService.GetString(LocalizationEntriesContracts.Controls.Jump.Info));
            sb.AppendLine();
            
            sb.AppendLine(lService.GetString(LocalizationEntriesContracts.Controls.Dash.Control));
            sb.Append(LocalizationEntriesContracts.Controls.Separator);
            sb.Append(lService.GetString(LocalizationEntriesContracts.Controls.Dash.Info));
            sb.AppendLine();
            
            sb.AppendLine(lService.GetString(LocalizationEntriesContracts.Controls.Platforms.Position.Control));
            sb.Append(LocalizationEntriesContracts.Controls.Separator);
            sb.Append(lService.GetString(LocalizationEntriesContracts.Controls.Platforms.Position.Info));
            sb.AppendLine();
            
            sb.AppendLine(lService.GetString(LocalizationEntriesContracts.Controls.Platforms.Rotation.Control));
            sb.Append(LocalizationEntriesContracts.Controls.Separator);
            sb.Append(lService.GetString(LocalizationEntriesContracts.Controls.Platforms.Rotation.Info));
            sb.AppendLine();
            
            sb.AppendLine(lService.GetString(LocalizationEntriesContracts.Controls.Platforms.Scale.Control));
            sb.Append(LocalizationEntriesContracts.Controls.Separator);
            sb.Append(lService.GetString(LocalizationEntriesContracts.Controls.Platforms.Scale.Info));
            sb.AppendLine();
            
            sb.AppendLine(lService.GetString(LocalizationEntriesContracts.ClickToContinue));
            
            cWindow.InfoText.text = sb.ToString();
        }
    }
}