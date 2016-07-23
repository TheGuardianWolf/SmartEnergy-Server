using System.Web.Http;
using System.Web.Http.Batch;

namespace SmartEnergy_Server
{
    public class HttpBatchHandler : DefaultHttpBatchHandler
    {
        public HttpBatchHandler(HttpServer httpServer) : base(httpServer)
        {
            this.ExecutionOrder = BatchExecutionOrder.NonSequential;
        }
    }
}