﻿using CoreLayer.DataAccess;
using CoreLayer.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFUserDal : EFEntityRepositoryBase<User, RentCarContext>, IUserDal
    {

        public List<OperationClaim> GetClaims(User user)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var query = from operationClaims in context.OperationClaims
                            join userOperationClaims in context.UserOperationClaims
                            on operationClaims.Id equals userOperationClaims.OperationClaimId
                            where user.Id == userOperationClaims.UserId
                            select new OperationClaim
                            {
                                Id = operationClaims.Id,
                                Name = operationClaims.Name,
                            };
                return query.ToList();

            }
        }
        public bool DefineCampaign(UserCampaign userCampaign)
        {
            using (var context = new RentCarContext())
            {
                var define = context.Entry(userCampaign);
                define.State = EntityState.Added;
              
                return  context.SaveChanges()>0;
           
            }
        }
    }
}
