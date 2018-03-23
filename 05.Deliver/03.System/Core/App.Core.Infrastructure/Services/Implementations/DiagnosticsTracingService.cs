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
    public class DiagnosticsTracingService : IDiagnosticsTracingService
    {
        private readonly Queue<TraceEntry> _cache = new Queue<TraceEntry>();
        private readonly TraceLevel _flushLevel;

        public DiagnosticsTracingService()
        {
            // Needs to be wired up to Application Settings to be dynamic in order to not need a restart
            // when errors start happening.
            this._flushLevel = TraceLevel.Error;
        }

        public void Trace(TraceLevel traceLevel, string message, params object[] arguments)
        {
            this._cache.Enqueue(new TraceEntry {TracelLevel = traceLevel, Message = message, Args = arguments});
            if (this._cache.Count > 100)
            {
                lock (this)
                {
                    while (this._cache.Count > 100)
                    {
                        this._cache.Dequeue();
                    }
                }
            }
            if (traceLevel <= this._flushLevel)
            {
                lock (this)
                {
                    while (this._cache.Count > 0)
                    {
                        var x = this._cache.Dequeue();
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
                    break;
                case TraceLevel.Error:
                    System.Diagnostics.Trace.TraceError(message);
                    break;
                case TraceLevel.Warn:
                    System.Diagnostics.Trace.TraceWarning(message);
                    break;
                case TraceLevel.Info:
                    System.Diagnostics.Trace.TraceInformation(message);
                    break;
                case TraceLevel.Debug:
                    System.Diagnostics.Trace.TraceInformation(message);
                    break;
            }

            System.Diagnostics.Trace.WriteLine(message);
        }

        private class TraceEntry
        {
            public object[] Args;
            public string Message;
            public TraceLevel TracelLevel;
        }
    }
}