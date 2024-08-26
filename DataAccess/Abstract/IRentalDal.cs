﻿using CoreLayer.Utilities.Results;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<RentalInfo>
    {
        void RentalAdd(RentalInfo rentalInfo);
    }
}