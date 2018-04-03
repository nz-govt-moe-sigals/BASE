namespace App.Core.Infrastructure.Services.Implementations
{
    using System.Collections.Generic;
    using App.Core.Shared.Models.Entities;
    /// <summary>
    ///     Implementation of the
    ///     <see cref="IDiagnosticsTracingService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.IDiagnosticsTracingService" />
    public class DiagnosticsTracingService : AppCoreServiceBase, IDiagnosticsTracingService
    {
        private static readonly Queue<TraceEntry> _cache = new Queue<TraceEntry>();
        private static TraceLevel _flushLevel;

        public DiagnosticsTracingService()
        {
            // Needs to be wired up to Application Settings to be dynamic in order to not need a restart
            // when errors start happening.
            _flushLevel = TraceLevel.Verbose;
        }

        public void Trace(TraceLevel traceLevel, string message, params object[] arguments)
        {
            _cache.Enqueue(new TraceEntry {TracelLevel = traceLevel, Message = message, Args = arguments});
            if (_cache.Count > 100)
            {
                lock (this)
                {
                    while (_cache.Count > 100)
                    {
                        _cache.Dequeue();
                    }
                }
            }
            if (traceLevel <= _flushLevel)
            {
                lock (this)
                {
                    while (_cache.Count > 0)
                    {
                        var x = _cache.Dequeue();
                        DirectTrace(x.TracelLevel, x.Message, x.Args);
                    }
                }
            }
        }

        private void DirectTrace(TraceLevel traceLevel, string message, params object[] arguments)
        {
            message = string.Format(message, arguments);

            switch (traceLevel)
            {
                case TraceLevel.Critical:
                    System.Diagnostics.Trace.TraceError(message);
                    System.Diagnostics.Trace.WriteLine($"CRITICAL: {message}");
                    break;
                case TraceLevel.Error:
                    System.Diagnostics.Trace.TraceError(message);
                    System.Diagnostics.Trace.WriteLine($"ERROR...: {message}");
                    break;
                case TraceLevel.Warn:
                    //System.Diagnostics.Trace.TraceWarning(message);
                    System.Diagnostics.Trace.WriteLine($"WARN....: {message}");
                    break;
                case TraceLevel.Info:
                    System.Diagnostics.Trace.WriteLine($"INFO....: {message}");
                    //System.Diagnostics.Trace.TraceInformation(message);
                    break;
                case TraceLevel.Debug:
                    System.Diagnostics.Trace.WriteLine($"DEBUG...: {message}");
                    break;
            }

        }

        private class TraceEntry
        {
            public object[] Args;
            public string Message;
            public TraceLevel TracelLevel;
        }
    }
}