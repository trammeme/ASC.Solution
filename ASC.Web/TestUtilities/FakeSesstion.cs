using System.Diagnostics.CodeAnalysis;

namespace ASC.Web.TestUtilities
{
    public class FakeSesstion : ISession
    {
        public bool IsAvailable => throw new NotImplementedException();

        public string Id => throw new NotImplementedException();

        public IEnumerable<string> Keys => throw new NotImplementedException();

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public Task CommitAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task LoadAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void Set(string key, byte[] value)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(string key, [NotNullWhen(true)] out byte[]? value)
        {
            throw new NotImplementedException();
        }
    }
}
