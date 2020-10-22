using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SkyPayment.Core.BindingModel;
using SkyPayment.Core.Entities;
using SkyPayment.Infrastructure.Interface;

namespace SkyPayment.Infrastructure.Services
{
    public interface IPersonnelService : IService
    {
        PersonnelUser GetPersonnelUser(string userName);
        PersonnelUser CreatePersonnelUser(PersonnelBindingModel model);
        IEnumerable<PersonnelUser> GetPersonnels(Expression<Func<PersonnelUser, bool>> whereClause);

    }
}