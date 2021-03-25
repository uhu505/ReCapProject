using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFRentalDAL : EFEntityRepositoryBase<Rental, ReCapDbContext>, IRentalDAL
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (var context = new ReCapDbContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarID equals car.Id
                             join customer in context.Customers
                             on rental.CustomerID equals customer.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join user in context.Users
                             on customer.UserId equals user.Id
                             select new RentalDetailDto
                             {
                                 RentalID = rental.Id,
                                 CarName = brand.BrandName,
                                 CompanyName = customer.CompanyName,
                                 UserName = user.FirstName + " " + user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}