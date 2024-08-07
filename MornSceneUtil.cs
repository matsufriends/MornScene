using UnityEngine;

namespace MornScene
{
    internal static class MornSceneUtil
    {
#if DISABLE_MORN_SCENE_LOG
        private const bool ShowLOG = false;
#else
        private const bool ShowLOG = true;
#endif
        private const string Prefix = "[<color=green>MornScene</color>] ";

        internal static void Log(string message)
        {
            if (ShowLOG)
            {
                Debug.Log(Prefix + message);
            }
        }

        internal static void LogError(string message)
        {
            if (ShowLOG)
            {
                Debug.LogError(Prefix + message);
            }
        }

        internal static void LogWarning(string message)
        {
            if (ShowLOG)
            {
                Debug.LogWarning(Prefix + message);
            }
        }
    }
}