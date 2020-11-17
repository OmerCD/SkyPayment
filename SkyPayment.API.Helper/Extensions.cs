using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkyPayment.Contract.ResponseModel;
using IBaseRequest = SkyPayment.Domain.CQ.IBaseRequest;

namespace SkyPayment.Management.API.Helper
{
    public static class Extensions
    {
        public static IActionResult ToActionResult(this BaseResponseModel responseModel)
        {
            return new ObjectResult(responseModel)
            {
                StatusCode = responseModel.StatusCode
            };
        }

        public static async Task<IActionResult> ToActionResult(this IMediator mediator, IBaseRequest request)
        {
            return (await mediator.Send(request)).ToActionResult();
        }
        public static async Task<IActionResult> ToActionResult(this Task<BaseResponseModel> responseModel)
        {
            return (await responseModel).ToActionResult();
        }
    }
}