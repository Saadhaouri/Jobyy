using Jobyy.Core.Application.Dto_s;

namespace Jobyy.Core.Application.Interfaces.IServices;

public interface IReactService
{
    public IEnumerable<ReactDto> GetReacts();
    public ReactDto GetReactById(Guid Id);
    public void AddReact(ReactDto react);
    public void UpdateReact(ReactDto react);
    public void DeleteReact(Guid Id);
}

