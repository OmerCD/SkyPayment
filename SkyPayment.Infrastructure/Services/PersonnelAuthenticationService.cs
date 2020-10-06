using System;
using SkyPayment.Core.BindingModel;
using SkyPayment.Core.Entities;
using SkyPayment.Repository.Interfaces;

namespace SkyPayment.Infrastructure.Services
{
    public class PersonnelAuthenticationService:IPersonnelService
    {
        private readonly IRepository<PersonnelUser> _repository;

        public PersonnelAuthenticationService(IRepository<PersonnelUser> repository)
        {
            _repository = repository;
        }

        public PersonnelUser GetPersonnelUser(string userName)
        {
            var normalizedName = userName.ToUpper().ToUpper().Trim();
            return _repository.FindOne(x => x.NormalizedUserName == normalizedName);
        }

        public PersonnelUser CreatePersonnelUser(PersonnelBindingModel model)
        {
            return _repository.InsertOne(Build(model));
        }

        private PersonnelUser Build(PersonnelBindingModel model)
        {
            return new PersonnelUser
            {
                Email = model.Email.Trim(),
                Name = model.Name.Trim(),
                LastName = model.LastName.Trim(),
                UserName = model.UserName.Trim(),
                Password = model.Password.Trim(),
                RestaurantId = model.RestaurantId.Trim(),
                ManagementUserId = model.ManagementUserId.Trim(),
                NormalizedUserName = model.NormalizedUserName.Trim().ToUpper(),
                CreateDate = DateTime.Today,

            };
        }
    }
}