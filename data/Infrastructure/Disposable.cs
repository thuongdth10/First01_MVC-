using System;
namespace data.Infrastructure
{
    //xem da huy vung nho hay chua
    
    public class Disposable : IDisposable
    {
        private bool isDisposed;
        public Disposable()
        {
            Dispose(false);
        }
        private void Dispose(bool disposing)
        {
            if(!isDisposed && disposing)
            {
                DisposeCore();
            }
            isDisposed = true;
        }
        protected virtual void DisposeCore()
        {
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            //this: chi lai chinh class Disposable.
        }


    }
}
