using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SkyPayment.Contract.ResponseModel;
using SkyPayment.Contract.ResponseModel.Personnel;
using SkyPayment.Core.Entities;
using SkyPayment.Domain.CQ.Queries.PersonnelQueries;
using SkyPayment.Infrastructure.Interface;
using SkyPayment.Infrastructure.Services;

namespace SkyPayment.Domain.Handlers.PersonnelHandlers
{
    public class GetAllPersonnelsHandler : IBaseRequestHandler<GetAllPersonnelsQuery>
    {
        private readonly IPersonnelService _personnelService;
        private readonly IRestaurantService _restaurantService;
        private readonly IMapper _mapper;

        public GetAllPersonnelsHandler(IPersonnelService personnelService, IMapper mapper, IRestaurantService restaurantService)
        {
            _personnelService = personnelService;
            _mapper = mapper;
            _restaurantService = restaurantService;
        }

        public Task<BaseResponseModel> Handle(GetAllPersonnelsQuery request, CancellationToken cancellationToken)
        {
            var personnels = _personnelService.GetPersonnels(x =>
                !x.IsDeleted && x.ManagementUserId == request.ManagementUserId);
            var personnelUsers = personnels as PersonnelUser[] ?? personnels.ToArray();
            var restaurants = _restaurantService.GetByIds(request.ManagementUserId, personnelUsers.Select(x => x.RestaurantId).ToHashSet()).ToDictionary(x=>x.Id);
            var mapped = personnelUsers.Select(x => Build(x, restaurants));
            return Task.FromResult(new BaseResponseModel
            {
                Data = mapped,
                Description = "Personel Listesi",
                StatusCode = 200
            });
        }

        private static PersonnelViewModel Build(PersonnelUser personnelUser, IReadOnlyDictionary<string, Restaurant> restaurants)
        {
            return new PersonnelViewModel
            {
                Email = personnelUser.Email,
                Name = personnelUser.Name,
                LastName = personnelUser.LastName,
                UserName = personnelUser.UserName,
                Restaurant = restaurants.TryGetValue(personnelUser.RestaurantId, out var restaurant) ? restaurant.Name : string.Empty
            };
        }
    }
}