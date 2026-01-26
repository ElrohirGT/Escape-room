    using UnityEditor;
    using UnityEngine;
public static class Utils
    {
        public static void Crash(object msg)
        {
            Debug.LogError(msg);
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit(1);
#endif
        }

        public static void CrashIfNull(object obj, object msg)
        {
            if (obj is null)
                Crash(msg);
        }
    }