namespace PassLock.Handler.Data.Diagnostics
{
    public static class RunModeHandler
    {
        /// <summary>
        /// Returns if the application runs in debug mode or not
        /// </summary>
        /// <returns>If the application runs in debug mode</returns>
        public static bool IsDebugMode()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }
    }
}
