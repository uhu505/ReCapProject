﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDAL : EFEntityRepositoryBase<Car, ReCapDbContext>, ICarDAL
    {
        public List<CarDetailDto> GetCarDetailDtos(Expression<Func<Car, bool>> filter = null)
        {
            using (var context = new ReCapDbContext())
            {
                var result = from car in filter is null ? context.Cars : context.Cars.Where(filter)
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             select new CarDetailDto
                             {
                                 Id = car.Id,
                                 BrandName = brand.BrandName,
                                 BrandId = brand.Id,
                                 ColorId = color.Id,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear
                             };

                return result.ToList();
            }
        }
    }
}