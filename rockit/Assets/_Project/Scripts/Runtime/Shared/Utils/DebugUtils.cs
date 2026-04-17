using System;
using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Utils
{
    public static class DebugUtils
    {
        public static void DrawGizmosWithColorBackup(Color color, Action action)
        {
            var backupColor = Gizmos.color;
            Gizmos.color = color;
            action();
            Gizmos.color = backupColor;
        }
    }
}