using UnityEngine;

namespace Services
{
    public class UnityLogger : ILogger
    {
        public void Log(string log)
        {
            if (!Debug.isDebugBuild)
                return;

            Debug.Log(log);
        }

        public void LogWarning(string log)
        {
            if (!Debug.isDebugBuild)
                return;

            Debug.LogWarning(log);
        }

        public void LogError(string log)
        {
            if (!Debug.isDebugBuild)
                return;

            Debug.LogError(log);
        }
    }
}