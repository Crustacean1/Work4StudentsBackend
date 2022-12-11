using System;

namespace ServiceBus.Package
{
    public sealed class PendingResponse : IDisposable
    {
        private readonly SemaphoreSlim semaphore;
        private string? responseBody;
        private bool disposed;

        public PendingResponse()
        {
            semaphore = new SemaphoreSlim(0);
        }

        public async Task<string> Get(CancellationToken cancellationToken)
        {
            if (disposed) { throw new ObjectDisposedException("Response.Get()"); }
            await semaphore.WaitAsync(cancellationToken);
            return responseBody!;
        }

        public void Set(string responseBody)
        {
            if (disposed) { throw new ObjectDisposedException("Response.Set()"); }
            this.responseBody = responseBody;
            _ = semaphore.Release();
        }

        public void Dispose()
        {
            if (!disposed)
            {
                disposed = true;
                semaphore.Dispose();
            }
        }
    }
}
