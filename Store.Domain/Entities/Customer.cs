﻿using Store.Domain.Entities.Base;
using Store.Domain.Entities.Enums;

namespace Store.Domain.Entities
{
    public class Customer : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTimeOffset BirthDate { get; set; }

    }
}
