﻿using Store.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Models.Domain
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public RecordStatusEnum RecordStatus { get; set; }
        public string CreateUserId { get; set; }


    }

    public class CreateCustomerModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTimeOffset BirthDate { get; set; }
    }

    public class UpdateCustomerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTimeOffset BirthDate { get; set; }
    }

    public class DeleteCustomerModel
    {
        public int Id { get; set; }
    }

}
