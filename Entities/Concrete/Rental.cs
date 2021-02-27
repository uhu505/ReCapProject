﻿using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Rental : IEntity
    {
        public int Id { get; set; }
        public int CarID { get; set; }
        public int CustomerID { get; set; }
        public DateTime? RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}