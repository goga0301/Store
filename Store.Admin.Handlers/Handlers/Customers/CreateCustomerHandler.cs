﻿using MediatR;
using Store.Admin.Handlers.Commands.Customers;
using Store.Domain.Entities;
using Store.Domain.Entities.Enums;
using Store.Domain.Repository;
using Store.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Store.Admin.Handlers.Handlers.Customers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, IApiResponse<int>>
    {
        private readonly ICustomerRepository _customerRepository;
        public CreateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<IApiResponse<int>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            using(var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var customer = new Customer
                {
                    FirstName = request.Model.FirstName,
                    LastName = request.Model.LastName,
                    Address = request.Model.Address,
                    PhoneNumber = request.Model.PhoneNumber,
                    Email = request.Model.Email,
                    UserName = request.Model.UserName,
                    Password = request.Model.Password,
                    Gender = request.Model.Gender,
                    BirthDate = request.Model.BirthDate,
                    RecordStatus = RecordStatusEnum.Active,
                    CreateDate = DateTime.Now,
                    CreateUserId = "test"
                    
                };
                _customerRepository.Create(customer);
                await _customerRepository.SaveChangesAsync();
                scope.Complete();
                return ApiResponse<int>.Success(customer.Id, "კლიენტი წარმატებით შეიქმნა");
                
            }
        }
    }
}
