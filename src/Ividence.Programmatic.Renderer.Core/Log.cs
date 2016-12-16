using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Ividence.Programmatic.Renderer.Core
{
    public static class Log
    {
        public static EventLog EventLog { get; } = new EventLog("Application", ".", typeof(Log).Assembly.GetName().Name);

        public static void Error(string tag, string msg, Exception exc, int eventId)
        {
            WriteEntry(tag, msg, exc, EventLogEntryType.Error, eventId);
        }

        [SuppressMessage("ReSharper", "EmptyGeneralCatchClause")]
        private static void WriteEntry(string tag, string msg, Exception e, EventLogEntryType type, int eventId)
        {
#if !DEBUG
            try
            {
                EventLog.WriteEntry($"{tag}\n{msg}\n{e}", type, eventId);
            }
            catch
            {
            }
#endif
        }
    }
}
