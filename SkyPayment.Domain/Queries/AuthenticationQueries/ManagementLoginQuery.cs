using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkyPayment.Contract.ResponseModel.Authentication;

namespace SkyPayment.Domain.Queries.AuthenticationQueries
{
    public class ManagementLoginQuery : IBaseRequest
    {
        public string Password { get; set; }
        public string UserName { get; set; }

        public ManagementLoginQuery(string password, string userName)
        {
            Password = password;
            UserName = userName;
        }
    }
}