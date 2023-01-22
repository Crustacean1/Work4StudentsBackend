using System.Text;

namespace W4S.ServiceBus.Package
{
    public sealed class PendingResponse : IDisposable
    {
        private readonly SemaphoreSlim semaphore;
        private string responseBody = string.Empty;
        private bool disposed;
        private TimeSpan timeout;

        public PendingResponse(int timeout)
        {
            semaphore = new SemaphoreSlim(0);
            this.timeout = TimeSpan.FromSeconds(timeout);
        }

        public async Task<string?> Get(CancellationToken cancellationToken)
        {
            if (disposed) { throw new ObjectDisposedException("Response.Get()"); }
            bool received = await semaphore.WaitAsync(timeout, cancellationToken);
            return received ? responseBody : null;
        }

        public void Set(ReadOnlySpan<byte> responseBody)
        {
            if (disposed) { throw new ObjectDisposedException("Response.Set()"); }
            this.responseBody = Encoding.UTF8.GetString(responseBody);
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
