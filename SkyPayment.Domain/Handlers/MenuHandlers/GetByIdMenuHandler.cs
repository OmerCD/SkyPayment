using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SkyPayment.Contract.ResponseModel;
using SkyPayment.Contract.ResponseModel.Restaurant;
using SkyPayment.Domain.Queries;
using SkyPayment.Infrastructure.Interface;

namespace SkyPayment.Domain.Handlers
{
    public class GetByIdMenuHandler:IBaseRequestHandler<GetByIdMenuQuery>
    {
        private readonly IMenuService _menuService;
        private readonly IMapper _mapper;

        public GetByIdMenuHandler(IMenuService menuService, IMapper mapper)
        {
            _menuService = menuService;
            _mapper = mapper;
        }

        public Task<BaseResponseModel> Handle(GetByIdMenuQuery request, CancellationToken cancellationToken)
        {
            var menuById = _menuService.GetById(request.ManagementUserId, request.MenuId);
            if (menuById == null)
            {
                return Task.FromResult<BaseResponseModel>(new BaseResponseModel
                {
                    Description = "Menu bulunamadı",
                    StatusCode = 400
                });
            }
            return Task.FromResult<BaseResponseModel>(new BaseResponseModel
            {
                Description = "Menu bilgisi",
                StatusCode = 200,
                Data = _mapper.Map<GetRestaurantByIdResponseModel>(menuById)
            });
        }
    }
}