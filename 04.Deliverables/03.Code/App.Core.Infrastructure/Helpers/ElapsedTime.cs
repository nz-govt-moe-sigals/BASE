using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    /// <summary>
    /// A Disposable class to help with logging the durations of operations.
    /// <para>
    /// Of value during the startup stage when tracing how long operations
    /// took, and what can be optimized.
    /// </para>
    /// <para>
    /// Also of use when recording integration operations. Again, useful
    /// for optimisation objectives.
    /// </para>
    /// </summary>
    public class ElapsedTime : IDisposable
    {
        public readonly DateTimeOffset Start;

        public ElapsedTime()
        {
            this.Start = DateTimeOffset.UtcNow;
        }
        public TimeSpan Elapsed
        {
            get { return DateTimeOffset.UtcNow.Subtract(this.Start); }
        } 
        public string ElapsedText
        {
            get
            {
                TimeSpan elapsed = Elapsed;
                if (elapsed.TotalSeconds < 1)
                {
                    return $"{elapsed.TotalMilliseconds} ms";
                }
                if (elapsed.TotalSeconds < 10)
                {
                    return $"{elapsed.TotalSeconds} secs, {elapsed.Milliseconds} ms";
                }
                if (elapsed.TotalMinutes < 1)
                {
                    return $"{elapsed.TotalSeconds} secs";
                }
                if (elapsed.TotalMinutes < 10)
                {
                    return $"{elapsed.TotalMinutes} mins, {elapsed.TotalSeconds} secs";
                }
                if (elapsed.TotalHours < 1)
                {
                    return $"{elapsed.TotalMinutes} mins";
                }
                return $"{elapsed.TotalHours} hours, {elapsed.TotalMinutes} mins";
            }
        }
        public void Dispose()
        {
        }
    }
}
