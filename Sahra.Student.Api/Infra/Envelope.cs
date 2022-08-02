using System;

namespace Sahra.Student.Api.Infra
{
    public class Envelope<T>
    {
        public T Result { get; private set; }
        public ErrorInfo Error { get; private set; }
        public DateTime ResponseTime { get; private set; }
        public void OK()
        {
            Clear();
        }

        public void OK(T result)
        {
            Clear();
            Result = result;
        }

        public void SetError(ErrorInfo error)
        {
            Clear();
            Error = error;
        }

        private void Clear()
        {
            Result = default(T);
            Error = null;
            ResponseTime = DateTime.Now;
        }
    }
}
