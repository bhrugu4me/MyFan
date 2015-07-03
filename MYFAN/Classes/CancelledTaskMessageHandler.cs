using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
public class CancelledTaskMessageHandler : DelegatingHandler
{
    protected override async System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
    {
        HttpResponseMessage response;
        response = await base.SendAsync(request, cancellationToken);
        if (cancellationToken.IsCancellationRequested)
        {
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
        return response;
    }
}
