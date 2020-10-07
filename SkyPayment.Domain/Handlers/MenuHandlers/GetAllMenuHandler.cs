using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SkyPayment.Contract.ResponseModel;
using SkyPayment.Domain.Queries;
using SkyPayment.Infrastructure.Interface;
using SkyPayment.Infrastructure.Services;

namespace SkyPayment.Domain.Handlers
{
    public class GetAllMenuHandler:IBaseRequestHandler<GetAllMenuQueries>
    {
        private readonly IMenuService _menuService;
        private readonly IMapper _mapper;

        public GetAllMenuHandler(IMenuService menuService, IMapper mapper)
        {
            _menuService = menuService;
            _mapper = mapper;
        }

        public Task<BaseResponseModel> Handle(GetAllMenuQueries request, CancellationToken cancellationToken)
        {
            var menus = _menuService.GetAll(request.UserId);
            if (menus == null)
            {
                return Task.FromResult<BaseResponseModel>(new BaseResponseModel
                {
                    Description = "Menü bulunamadı",
                    StatusCode = 404
                });
            }

            return Task.FromResult<BaseResponseModel>(new BaseResponseModel()
            {
                Data = _mapper.Map<MenuResponseModel>(menus),
                Description = "Menüler",
                StatusCode = 200
            });
        }
    }
}