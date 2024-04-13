using AutoMapper;
using Joby.Domain.Models;
using Jobyy.Core.Application.Dto_s;
using Jobyy.Core.Application.Interfaces.IRepository;
using Jobyy.Core.Application.Interfaces.IServices;
using JObyy.Core.Application.Dto_s;
using JObyy.Core.Application.Interfaces.IRepository;

namespace Jobyy.Core.Application.Services
{
    public class ReactService : IReactService
    {
        private readonly IReactRepository _reactrepository;
        private readonly IMapper _mapper;

        public ReactService( IReactRepository reactrepository , IMapper mapper)
        {
            _reactrepository = reactrepository;
            _mapper = mapper;
            
        }

        public void AddReact(ReactDto react)
        {
            var React = _mapper.Map<React>(react);
            _reactrepository.InsertReact(React);
            _reactrepository.Save();

        }

        public void DeleteReact(Guid Id)
        {
            _reactrepository.DeleteReact(Id);
            _reactrepository.Save();
        }

        public ReactDto GetReactById(Guid Id)
        {
         var react =  _reactrepository.GetReactById(Id) ;
            return _mapper.Map<ReactDto>(react);
        }

        public IEnumerable<ReactDto> GetReacts()
        {
            var reacts = _reactrepository.GetReacts();
            return _mapper.Map<IEnumerable<ReactDto>>(reacts);

        }

        public void UpdateReact(ReactDto react)
        {
            var reactModel = _mapper.Map<React>(react);
            _reactrepository.UpdateReact(reactModel);
            _reactrepository.Save();
        }
    }
}
