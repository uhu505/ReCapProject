﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCustomerDAL : EFEntityRepositoryBase<Customer, ReCapDbContext>, ICustomerDAL
    {
    }
}