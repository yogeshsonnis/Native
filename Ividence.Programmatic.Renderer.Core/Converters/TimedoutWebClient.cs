using System;
using System.Net;

namespace Ividence.Programmatic.Renderer.Core.Converters
{
    internal class TimedoutWebClient : WebClient
    {
        public TimeSpan Timeout { get; set; }

        public TimedoutWebClient() : this(TimeSpan.FromSeconds(30)) { }
        public TimedoutWebClient(TimeSpan timeout) { this.Timeout = timeout; }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var r = base.GetWebRequest(address);
            if (r != null) r.Timeout = (int)this.Timeout.TotalMilliseconds;
            return r;
        }

    }
}
