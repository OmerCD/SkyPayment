using System;
using Microsoft.AspNetCore.Mvc;
using SkyPayment.Contract.ResponseModel;

namespace SkyPayment.API.Helper
{
    public static class Extensions
    {
        public static IActionResult ToActionResult(this BaseResponseModel responseModel)
        {
            return new ObjectResult(responseModel.Data)
            {
                StatusCode = responseModel.StatusCode
            };
        }
    }
}