using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Bson;
using SkyPayment.Contract.ResponseModel;
using SkyPayment.Core.Entities;
using SkyPayment.Domain.CQ.Commands.RestaurantCommand;
using SkyPayment.Infrastructure.Interface;
using SkyPayment.Infrastructure.Services;

namespace SkyPayment.Domain.Handlers
{
    public class CreateRestaurantHandler:IBaseRequestHandler<CreateRestaurantCommand>
    {
        private readonly IRestaurantService _restaurantService;

        public CreateRestaurantHandler(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public Task<BaseResponseModel> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = _restaurantService.CreateRestaurant(new Restaurant()
            {
                Address = request.Address,
                Email = request.Email,
                Name = request.Name,
                CreateDate = DateTime.Now,
                PhoneNumber = request.PhoneNumber,
                Website = request.Website,
                ManagementUserId = request.ManagementUserId,
                Id = ObjectId.GenerateNewId().ToString()
            });
            if (restaurant != null)
            {
                return Task.FromResult<BaseResponseModel>(new BaseResponseModel
                {
                    Description = "Kayıt Başarılı",
                    StatusCode = 201
                });
            }
            return Task.FromResult<BaseResponseModel>(new BaseResponseModel
            {
                Description = "Bir hata oluştu",
                StatusCode = 400
            });


        }
    }
}