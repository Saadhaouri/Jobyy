using Joby.Domain.Models;

namespace Jobyy.Core.Application.Interfaces.IRepository
{
    public interface IReactRepository : IDisposable
    {
        IEnumerable<React> GetReacts();
        React GetReactById(Guid reactId);
        void InsertReact(React react);
        void DeleteReact(Guid react );
        void UpdateReact (React react);
        void Save();
    }
}
