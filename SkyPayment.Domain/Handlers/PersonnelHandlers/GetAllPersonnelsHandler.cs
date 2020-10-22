using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SkyPayment.Contract.ResponseModel;
using SkyPayment.Contract.ResponseModel.Personnel;
using SkyPayment.Domain.CQ.Queries.PersonnelQueries;
using SkyPayment.Infrastructure.Services;

namespace SkyPayment.Domain.Handlers.PersonnelHandlers
{
    public class GetAllPersonnelsHandler : IBaseRequestHandler<GetAllPersonnelsQuery>
    {
        private readonly IPersonnelService _personnelService;
        private readonly IMapper _mapper;

        public GetAllPersonnelsHandler(IPersonnelService personnelService, IMapper mapper)
        {
            _personnelService = personnelService;
            _mapper = mapper;
        }

        public Task<BaseResponseModel> Handle(GetAllPersonnelsQuery request, CancellationToken cancellationToken)
        {
            var personnels = _personnelService.GetPersonnels(x =>
                !x.IsDeleted && x.ManagementUserId == request.ManagementUserId);
            return Task.FromResult(new BaseResponseModel
            {
                Data = _mapper.Map<IEnumerable<PersonnelViewModel>>(personnels),
                Description = "Personel Listesi",
                StatusCode = 200
            });
        }
    }
}